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
    public class ArchitectureComplexityRateController : ControllerBase<ArchitectureComplexityRate, ArchitectureComplexityRateDto>
    {
        private readonly LVCContext _context;

        public ArchitectureComplexityRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/ArchitectureComplexityRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchitectureComplexityRateDto>>> GetArchitectureComplexityRates()
        {
            var items = await RatesRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/ArchitectureComplexityRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> GetArchitectureComplexityRate(int id)
        {
            var architectureComplexityRate = await RatesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (architectureComplexityRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(architectureComplexityRate);
        }

        private IQueryable<ArchitectureComplexityRate> RatesRequest()
        {
            return _context.ArchitectureComplexityRates
                .Include(r => r.ComponentsInteractionArchitecture)
                .Include(r => r.ComponentsMakroArchitecture)
                .AsNoTracking();
        }

        // PUT: api/ArchitectureComplexityRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchitectureComplexityRate(int id, ArchitectureComplexityRateDto architectureComplexityRateDto)
        {
            if (id != architectureComplexityRateDto.ID)
            {
                return BadRequest();
            }

            var architectureComplexityRate = ConvertToSource(architectureComplexityRateDto);
            _context.Entry(architectureComplexityRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchitectureComplexityRateExists(id))
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

        // POST: api/ArchitectureComplexityRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> PostArchitectureComplexityRate(ArchitectureComplexityRateDto architectureComplexityRateDto)
        {
            var architectureComplexityRate = ConvertToSource(architectureComplexityRateDto);
            _context.ArchitectureComplexityRates.Add(architectureComplexityRate);
            try 
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }

            architectureComplexityRate = await RatesRequest().FirstOrDefaultAsync(m => m.ID == architectureComplexityRate.ID);

            return CreatedAtAction("GetArchitectureComplexityRate", new { id = architectureComplexityRate.ID }, ConvertToDto(architectureComplexityRate));
        }

        // DELETE: api/ArchitectureComplexityRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> DeleteArchitectureComplexityRate(int id)
        {
            var architectureComplexityRate = await _context.ArchitectureComplexityRates.FindAsync(id);
            if (architectureComplexityRate == null)
            {
                return NotFound();
            }

            _context.ArchitectureComplexityRates.Remove(architectureComplexityRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(architectureComplexityRate);
        }

        private bool ArchitectureComplexityRateExists(int id)
        {
            return _context.ArchitectureComplexityRates.Any(e => e.ID == id);
        }
    }
}
