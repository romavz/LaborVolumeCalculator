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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirStageController : ControllerBase<NirStage, NirStageDto>
    {
        private readonly INirStageRepository _nirStages;

        public NirStageController(INirStageRepository nirStages, IMapper mapper) : base(mapper)
        {
            _nirStages = nirStages;
        }

        // GET: api/NirStage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageDto>>> GetNirStages(int nirId)
        {
            var items = await _nirStages.WithIncludes
                .Where(r => r.NirID == nirId)
                .ToListAsync();

            var result = ConvertToDto(items)
                .OrderBy(item => item.Code, CodeComparer.Instance)
                .ToArray();

            return result;
        }

        // GET: api/NirStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageDto>> GetNirStage(int id)
        {
            var nirStage = await _nirStages.WithIncludes.FirstOrDefaultAsync(m => m.ID == id);

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
            await _nirStages.RemoveOutdatedIncludesAsync(nirStage);
            _nirStages.Update(nirStage);

            try
            {
                await _nirStages.SaveChangesAsync();
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

        // POST: api/NirStage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStageDto>> PostNirStage(NirStageCreateDto itemDto)
        {
            var nirStage = ConvertToSource(itemDto);
            _nirStages.Add(nirStage);
            
            try
            {
                await _nirStages.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            nirStage = await _nirStages.FirstOrDefaultAsync(m => m.ID == nirStage.ID);
            return CreatedAtAction("GetNirStage", new { id = nirStage.ID }, ConvertToDto(nirStage));
        }

        // DELETE: api/NirStage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageDeleteDto>> DeleteNirStage(int id)
        {
            var nirStage = await _nirStages.FirstOrDefaultAsync(m => m.ID == id);
            if (nirStage == null)
            {
                return NotFound();
            }

            _nirStages.Remove(nirStage);
            await _nirStages.SaveChangesAsync();

            return ConvertToDto<NirStageDeleteDto>(nirStage);
        }

        private bool NirStageExists(int id)
        {
            return _nirStages.Any(e => e.ID == id);
        }
    }
}
