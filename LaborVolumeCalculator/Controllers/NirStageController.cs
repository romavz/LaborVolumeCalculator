using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirStageController : ControllerBase<NirStage, NirStageDto>
    {
        private readonly LVCContext _context;

        public NirStageController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirStage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageDto>>> GetNirStages(int nirId)
        {
            var items = await StagesRequest()
                .Where(r => r.NirID == nirId)
                .ToListAsync();

            var result = ConvertToDto(items)
                .OrderBy(item => item.Code, CodeComparer.Instance)
                .ToArray();

            return result;
        }

        private IQueryable<NirStage> StagesRequest()
        {
            return _context.NirStages
                .Include(m => m.NirInnovationRate)
                .Include(m => m.LaborVolumes)
                    .ThenInclude(lv => lv.Labor)
                .AsNoTracking();
        }


        // GET: api/NirStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageDto>> GetNirStage(int id)
        {
            var nirStage = await StagesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirStage == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStage);
        }

        // PUT: api/NirStageController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutNirStage(int id, NirStageChangeDto item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            var nirStage = ConvertToSource(item);
            await RemoveDeletedLaborVolumes(nirStage.ID, actualLaborVolumesIDs: nirStage.LaborVolumes.Select(lv => lv.ID));
            _context.Update(nirStage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirStageExists(id))
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

        private async Task RemoveDeletedLaborVolumes(int nirStageID, IEnumerable<int> actualLaborVolumesIDs)
        {
            var deletedVolumes = await _context.NirStageLaborVolumes
                .Where(lv => lv.StageID == nirStageID && !actualLaborVolumesIDs.Contains(lv.ID))
                .ToListAsync();

            _context.RemoveRange(deletedVolumes);
        }

        // POST: api/NirStage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStageDto>> PostNirStage(NirStageCreateDto itemDto)
        {
            var nirStage = ConvertToSource(itemDto);
            _context.NirStages.Add(nirStage);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            nirStage = await StagesRequest().FirstOrDefaultAsync(m => m.ID == nirStage.ID);
            return CreatedAtAction("GetNirStage", new { id = nirStage.ID }, ConvertToDto(nirStage));
        }

        private void DeleteStageLaborVolumes(int stageID)
        {
            var laborVolumes = _context.NirStageLaborVolumes.Where(m => m.StageID == stageID);
            _context.NirStageLaborVolumes.RemoveRange(laborVolumes);
        }

        // DELETE: api/NirStage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageDeleteDto>> DeleteNirStage(int id)
        {
            var nirStage = await _context.NirStages.FindAsync(id);
            if (nirStage == null)
            {
                return NotFound();
            }

            _context.NirStages.Remove(nirStage);
            await _context.SaveChangesAsync();

            return ConvertToDto<NirStageDeleteDto>(nirStage);
        }

        private bool NirStageExists(int id)
        {
            return _context.NirStages.Any(e => e.ID == id);
        }
    }
}
