using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
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
            var stages = await GetStageQuery().OrderBy(m => m.Name).ToListAsync();
            return ConvertToDto(stages);
        }

        // GET: api/NirStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageDto>> GetNirStage(int id)
        {
            var nirStage = await GetStageQuery().FirstOrDefaultAsync(m => m.ID == id);

            if (nirStage == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStage);
        }

        private IQueryable<NirStage> GetStageQuery()
        {
            return _context.NirStages.AsNoTracking();
        }

        // PUT: api/NirStage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirStage(int id, NirStageDto nirStageDto)
        {
            if (id != nirStageDto.ID)
            {
                return BadRequest();
            }

            var nirStage = ConvertToSource(nirStageDto);
            _context.Entry(nirStage).State = EntityState.Modified;

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

        // POST: api/NirStage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStage>> PostNirStage(NirStageDto nirStageDto)
        {
            var nirStage = ConvertToSource(nirStageDto);
            _context.NirStages.Add(nirStage);
            await _context.SaveChangesAsync();

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
