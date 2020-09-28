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
        public async Task<ActionResult<IEnumerable<NirStageDto>>> GetNirStages()
        {
            var items = await StagesRequest().ToListAsync();

            var result = ConvertToDto(items)
                .OrderBy(item => item.Name)
                .ToArray();

            return result;
        }

        // GET: api/NirStage/GetNirStages/5
        [HttpGet("[action]/{nirId}")]
        public async Task<ActionResult<IEnumerable<NirStageDto>>> GetNirStages(int nirId)
        {
            var nirStages = await StagesRequest()
                .Where(r => r.NirID == nirId)
                .ToListAsync();

            if (nirStages == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStages);
        }

        private IQueryable<NirStage> StagesRequest()
        {
            return _context.NirStages
                            .AsNoTracking();
        }


        // GET: api/NirStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageDto>> GetNirStage(int id)
        {
            var nirStage = await _context.NirStages.FindAsync(id);

            if (nirStage == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStage);
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

            return CreatedAtAction("GetNirStage", new { id = nirStage.ID }, ConvertToDto(nirStage));
        }

        // DELETE: api/NirStage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageDto>> DeleteNirStage(int id)
        {
            var nirStage = await _context.NirStages.FindAsync(id);
            if (nirStage == null)
            {
                return NotFound();
            }

            _context.NirStages.Remove(nirStage);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirStage);
        }

        private bool NirStageExists(int id)
        {
            return _context.NirStages.Any(e => e.ID == id);
        }
    }
}
