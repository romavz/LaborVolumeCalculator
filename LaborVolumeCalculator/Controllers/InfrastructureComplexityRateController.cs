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
    public class InfrastructureComplexityRateController : ControllerBase<InfrastructureComplexityRate, InfrastructureComplexityRateDto>
    {
        private readonly LVCContext _context;

        public InfrastructureComplexityRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/InfrastructureComplexityRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfrastructureComplexityRateDto>>> GetInfrastructureComplexities()
        {
            var items = await RatesRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/InfrastructureComplexityRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfrastructureComplexityRateDto>> GetInfrastructureComplexityRate(int id)
        {
            var infrastructureComplexityRate = await RatesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (infrastructureComplexityRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(infrastructureComplexityRate);
        }

        private IQueryable<InfrastructureComplexityRate> RatesRequest()
        {
            return _context.InfrastructureComplexities.AsNoTracking();
        }

        // PUT: api/InfrastructureComplexityRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfrastructureComplexityRate(int id, InfrastructureComplexityRateDto infrastructureComplexityRateDto)
        {
            if (id != infrastructureComplexityRateDto.ID)
            {
                return BadRequest();
            }

            var infrastructureComplexityRate = ConvertToSource(infrastructureComplexityRateDto);
            _context.Entry(infrastructureComplexityRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfrastructureComplexityRateExists(id))
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

        // POST: api/InfrastructureComplexityRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InfrastructureComplexityRateDto>> PostInfrastructureComplexityRate(InfrastructureComplexityRateDto infrastructureComplexityRateDto)
        {
            var infrastructureComplexityRate = ConvertToSource(infrastructureComplexityRateDto);
            _context.InfrastructureComplexities.Add(infrastructureComplexityRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfrastructureComplexityRate", new { id = infrastructureComplexityRate.ID }, ConvertToDto(infrastructureComplexityRate));
        }

        // DELETE: api/InfrastructureComplexityRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfrastructureComplexityRateDto>> DeleteInfrastructureComplexityRate(int id)
        {
            var infrastructureComplexityRate = await _context.InfrastructureComplexities.FindAsync(id);
            if (infrastructureComplexityRate == null)
            {
                return NotFound();
            }

            _context.InfrastructureComplexities.Remove(infrastructureComplexityRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(infrastructureComplexityRate);
        }

        private bool InfrastructureComplexityRateExists(int id)
        {
            return _context.InfrastructureComplexities.Any(e => e.ID == id);
        }
    }
}
