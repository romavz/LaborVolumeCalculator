using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.DTO;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirStageLaborVolumeController : ControllerBase<NirStageLaborVolume, NirStageLaborVolumeDto>
    {
        private readonly LVCContext _context;

        public NirStageLaborVolumeController(LVCContext context, IMapper mapper) : base(mapper)
        {
            this._context = context;
        }


        // GET: api/NirLaborVolumeController?stageID=23
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageLaborVolumeDto>>> GetNirLaborVolumes(int stageID)
        {
            var result = await ItemsRequest()
                .Where(m => m.StageID == stageID)
                .ToListAsync();

            var dto = ConvertToDto(result)
                .OrderBy(item => item.Labor.Code, CodeComparer.Instance)
                .ToArray();

            return dto;
        }

        private IQueryable<NirStageLaborVolume> ItemsRequest()
        {
            return _context.NirStageLaborVolumes
                .Include(item => item.Labor)
                .AsNoTracking();
        }

        // GET: api/NirLaborVolumeController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageLaborVolumeDto>> GetNirLaborVolume(int id)
        {
            var nirLaborVolume = await ItemsRequest().FirstOrDefaultAsync(t => t.ID == id);

            if (nirLaborVolume == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirLaborVolume);
        }

        // PUT: api/NirLaborVolumeController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutNirLaborVolume(int id, NirStageLaborVolumeChangeDto item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            var nirLaborVolume = ConvertToSource(item);
            _context.Entry(nirLaborVolume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborVolumeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/NirLaborVolumeController
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStageLaborVolumeDto>> PostNirLaborVolume(NirStageLaborVolumeCreateDto nirLaborVolumeDto)
        {
            var nirLaborVolume = ConvertToSource(nirLaborVolumeDto);
            
            _context.NirStageLaborVolumes.Add(nirLaborVolume);
            await _context.SaveChangesAsync();

            nirLaborVolume = await ItemsRequest().Include(m => m.Labor).FirstOrDefaultAsync(m => m.ID == nirLaborVolume.ID);

            return CreatedAtAction("GetNirLaborVolume", new { id = nirLaborVolume.ID }, ConvertToDto(nirLaborVolume));
        }

        // DELETE: api/NirLaborVolumeController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageLaborVolumeDto>> DeleteNirLaborVolume(int id)
        {
            var nirLaborVolume = await _context.NirStageLaborVolumes.FindAsync(id);
            if (nirLaborVolume == null)
            {
                return NotFound();
            }

            _context.NirStageLaborVolumes.Remove(nirLaborVolume);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirLaborVolume);
        }

        private bool NirLaborVolumeExists(int id)
        {
            return _context.NirStageLaborVolumes.Any(e => e.ID == id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<NirStageLaborVolumeDto>>> AddDefaultLabors(int nirID, int stageID)
        {
            var nir = await _context.Nirs
                .FirstAsync(nir => nir.ID == nirID);

            var stage = await _context.StagesForNir
                .FirstAsync(stage => stage.ID == stageID);

            var defaultLabors = _context.NirStageDefaultLabors
                .Include(item => item.Labor)
                .Where(item => item.StageID == stageID)
                .Select(item => item.Labor);

            if (nir == null || stage == null) return BadRequest();

            var regBuilder = new NirLaborVolumeBuilder(nir, stage, volumeRate: 0.8f);

            var registredLaborsIDs = _context.NirStageLaborVolumes.Include(reg => reg.Labor).Select(item => (int?)item.LaborID);

            var laborsRequest = (
                from defLabor in defaultLabors
                join registredID in registredLaborsIDs on defLabor.ID equals registredID into gReged
                from subLabor in gReged.DefaultIfEmpty()
                where subLabor == null
                select defLabor
                ).Distinct();

            var needToInsertLabors = await laborsRequest.ToListAsync();

            var laborVolumes = needToInsertLabors.Select(labor => regBuilder.Create(labor)).ToList();

            if (laborVolumes.Count() < 1) return Ok();

            try
            {
                await _context.AddRangeAsync(laborVolumes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            
            var inserted = await _context.NirStageLaborVolumes
                .Include(r => r.Labor)
                .Where(item => laborVolumes.Select(reg => reg.LaborID).Contains(item.LaborID))
                .ToListAsync();

            return CreatedAtAction("GetVolumes", new { stageID = stageID }, ConvertToDto(inserted));
        }
    }

    internal class NirLaborVolumeBuilder
    {
        private readonly Nir nir;
        private readonly StageForNir stage;

        private double volumeRate;

        public NirLaborVolumeBuilder(Nir nir, StageForNir stage, double volumeRate = 1.0)
        {
            this.nir = nir;
            this.stage = stage;
            this.volumeRate = volumeRate;
        }

        public NirStageLaborVolume Create(NirLabor labor)
        {
            var delta = labor.MaxVolume - labor.MinVolume;
            double volume = labor.MinVolume + delta * volumeRate;
            
            if (volume < labor.MinVolume) volume = labor.MinVolume;
            
            return new NirStageLaborVolume {
                StageID = stage.ID, 
                LaborID = labor.ID, 
                Labor = labor,
                Volume = volume
            };
        }
    }
}
