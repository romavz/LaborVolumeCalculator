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
    public class StageForNirController : ControllerBase<StageForNir, StageForNirDto>
    {
        private readonly LVCContext _context;

        public StageForNirController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/StageForNir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StageForNirDto>>> GetStageForNirs()
        {
            var stages = await GetStageQuery().OrderBy(m => m.Name).ToListAsync();
            return ConvertToDto(stages);
        }

        // GET: api/StageForNir/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StageForNirDto>> GetStageForNir(int id)
        {
            var stageForNir = await GetStageQuery().FirstOrDefaultAsync(m => m.ID == id);

            if (stageForNir == null)
            {
                return NotFound();
            }

            return ConvertToDto(stageForNir);
        }

        private IQueryable<StageForNir> GetStageQuery()
        {
            return _context.StagesForNir.AsNoTracking();
        }

        // PUT: api/StageForNir/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStageForNir(int id, StageForNirDto stageForNirDto)
        {
            if (id != stageForNirDto.ID)
            {
                return BadRequest();
            }

            var stageForNir = ConvertToSource(stageForNirDto);
            _context.Entry(stageForNir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageForNirExists(id))
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

        // POST: api/StageForNir
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StageForNir>> PostStageForNir(StageForNirDto stageForNirDto)
        {
            var stageForNir = ConvertToSource(stageForNirDto);
            _context.StagesForNir.Add(stageForNir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStageForNir", new { id = stageForNir.ID }, ConvertToDto(stageForNir));
        }

        // DELETE: api/StageForNir/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StageForNirDto>> DeleteStageForNir(int id)
        {
            var stageForNir = await _context.StagesForNir.FindAsync(id);
            if (stageForNir == null)
            {
                return NotFound();
            }

            _context.StagesForNir.Remove(stageForNir);
            await _context.SaveChangesAsync();

            return ConvertToDto(stageForNir);
        }

        private bool StageForNirExists(int id)
        {
            return _context.StagesForNir.Any(e => e.ID == id);
        }
    }
}
