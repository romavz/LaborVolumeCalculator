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
using LaborVolumeCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborVolumeRegController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirLaborVolumeRegController(LVCContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        // GET: api/NirLaborVolumeRegController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeRegDto>>> GetNirLaborVolumeRegs()
        {
            var result = await _context.NirLaborVolumeRegs
                .Include(item => item.Labor)
                .Select(item => ConvertToDto(item))
                .AsNoTracking()
                .ToListAsync();
            
            return result.OrderBy(item => item.Labor.Code, CodeComparer.Instance).ToArray();
        }

        // GET: api/NirLaborVolumeRegController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirLaborVolumeRegDto>> GetNirLaborVolumeReg(int id)
        {
            var nirLaborVolumeReg = await _context.NirLaborVolumeRegs
                .Include(i => i.Labor)
                .AsNoTracking()
                .FirstAsync(t => t.ID == id);

            if (nirLaborVolumeReg == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirLaborVolumeReg);
        }

        //GET api/NirLaborVolumeReg/GetRegs? nirID = 3 & StageID = 1
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeRegDto>>> GetRegs(int nirID, int stageID)
        {
            var laborVolumeRegs = await _context.NirLaborVolumeRegs
                .Include(m => m.Labor)
                .Where(m =>
                    m.NirID == nirID
                    && m.StageID == stageID)
                .Select(item => ConvertToDto(item))
                .AsNoTracking()
                .ToListAsync();
            
            var orderedRegs = laborVolumeRegs.OrderBy(m => m.Labor.Code, CodeComparer.Instance);
            return orderedRegs.ToArray();
        }

        // PUT: api/NirLaborVolumeRegController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutNirLaborVolumeReg(int id, NirLaborVolumeRegDto item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            var nirLaborVolumeReg = ConvertFromDto(item);
            _context.Entry(nirLaborVolumeReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborVolumeRegExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NirLaborVolumeRegController
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirLaborVolumeRegDto>> PostNirLaborVolumeReg(NirLaborVolumeReg nirLaborVolumeRegDto)
        {
            var nirLaborVolumeReg = _mapper.Map<NirLaborVolumeReg>(nirLaborVolumeRegDto);
            
            _context.NirLaborVolumeRegs.Add(nirLaborVolumeReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirLaborVolumeReg", new { id = nirLaborVolumeRegDto.ID }, nirLaborVolumeRegDto);
        }

        // DELETE: api/NirLaborVolumeRegController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirLaborVolumeRegDto>> DeleteNirLaborVolumeReg(int id)
        {
            var nirLaborVolumeReg = await _context.NirLaborVolumeRegs.FindAsync(id);
            if (nirLaborVolumeReg == null)
            {
                return NotFound();
            }

            _context.NirLaborVolumeRegs.Remove(nirLaborVolumeReg);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirLaborVolumeReg);
        }

        private bool NirLaborVolumeRegExists(int id)
        {
            return _context.NirLaborVolumeRegs.Any(e => e.ID == id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeRegDto>>> AddDefaultLabors(int nirID, int stageID)
        {
            var nir = await _context.Nirs
                .Include(nir => nir.NirInnovationRate)
                .FirstAsync(nir => nir.ID == nirID);

            var stage = await _context.NirStages
                .FirstAsync(stage => stage.ID == stageID);

            var defaultLabors = _context.NirStageDefaultLabors
                .Include(item => item.Labor)
                .Where(item => item.StageID == stageID)
                .Select(item => item.Labor);

            if (nir == null || stage == null) return BadRequest();

            var regBuilder = new NirLaborVolumeRegBuilder(nir, stage, volumeRate: 0.8f);

            var registredLaborsIDs = _context.NirLaborVolumeRegs.Include(reg => reg.Labor).Select(item => (int?)item.LaborID);

            var laborsRequest = (
                from defLabor in defaultLabors
                join registredID in registredLaborsIDs on defLabor.ID equals registredID into gReged
                from subLabor in gReged.DefaultIfEmpty()
                where subLabor == null
                select defLabor
                ).Distinct();

            var needToInsertLabors = await laborsRequest.ToListAsync();

            var laborVolumeRegs = needToInsertLabors.Select(labor => regBuilder.Create(labor)).ToList();

            if (laborVolumeRegs.Count() < 1) return Ok();

            try
            {
                await _context.AddRangeAsync(laborVolumeRegs);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            
            var inserted = await _context.NirLaborVolumeRegs
                .Include(r => r.Labor)
                .Where(item => laborVolumeRegs.Select(reg => reg.LaborID).Contains(item.LaborID))
                .ToListAsync();
            
            var result = ConvertToDto(inserted);

            return CreatedAtAction("GetRegs", new { nirID = nirID, stageID = stageID }, result);
        }

        private NirLaborVolumeRegDto ConvertToDto(NirLaborVolumeReg item)
        {
            return _mapper.Map<NirLaborVolumeRegDto>(item);
        }

        private NirLaborVolumeReg ConvertFromDto(NirLaborVolumeRegDto item)
        {
            return _mapper.Map<NirLaborVolumeReg>(item);
        }

        private IEnumerable<NirLaborVolumeRegDto> ConvertToDto(IEnumerable<NirLaborVolumeReg> laborVolumeRegs)
        {
            return _mapper.Map<IEnumerable<NirLaborVolumeReg>, IEnumerable<NirLaborVolumeRegDto>>(laborVolumeRegs);
        }
    }

    internal class NirLaborVolumeRegBuilder
    {
        private readonly Nir nir;
        private readonly NirStage stage;

        private float volumeRate;

        public NirLaborVolumeRegBuilder(Nir nir, NirStage stage, float volumeRate = 1.0f)
        {
            this.nir = nir;
            this.stage = stage;
            this.volumeRate = volumeRate;
        }

        public NirLaborVolumeReg Create(NirLabor labor)
        {
            float volume = labor.MaxVolume * this.volumeRate;
            if (volume < labor.MinVolume) volume = labor.MinVolume;
            
            return new NirLaborVolumeReg {
                NirID = nir.ID, 
                StageID = stage.ID, 
                LaborID = labor.ID, 
                Labor = labor,
                Volume = volume,
                TotalVolume = volume * (float)nir.NirInnovationRate.Value
            };
        }
    }
}
