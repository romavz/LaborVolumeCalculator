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
    public class SolutionInnovationRateController : ControllerBase<SolutionInnovationRate, SolutionInnovationRateDto>
    {
        private readonly LVCContext _context;

        public SolutionInnovationRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/SolutionInnovationRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolutionInnovationRateDto>>> GetSolutionInnovationRates()
        {
            var items = await RatesRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/SolutionInnovationRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionInnovationRateDto>> GetSolutionInnovationRate(int id)
        {
            var solutionInnovationRate = await RatesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (solutionInnovationRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(solutionInnovationRate);
        }

        private IQueryable<SolutionInnovationRate> RatesRequest()
        {
            return _context.SolutionInnovationRates.AsNoTracking();
        }

        // PUT: api/SolutionInnovationRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolutionInnovationRate(int id, SolutionInnovationRateDto solutionInnovationRateDto)
        {
            if (id != solutionInnovationRateDto.ID)
            {
                return BadRequest();
            }

            var solutionInnovationRate = ConvertToSource(solutionInnovationRateDto);
            _context.Entry(solutionInnovationRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionInnovationRateExists(id))
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

        // POST: api/SolutionInnovationRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SolutionInnovationRateDto>> PostSolutionInnovationRate(SolutionInnovationRateDto solutionInnovationRateDto)
        {
            var solutionInnovationRate = ConvertToSource(solutionInnovationRateDto);
            _context.SolutionInnovationRates.Add(solutionInnovationRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolutionInnovationRate", new { id = solutionInnovationRate.ID }, ConvertToDto(solutionInnovationRate));
        }

        // DELETE: api/SolutionInnovationRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SolutionInnovationRateDto>> DeleteSolutionInnovationRate(int id)
        {
            var solutionInnovationRate = await _context.SolutionInnovationRates.FindAsync(id);
            if (solutionInnovationRate == null)
            {
                return NotFound();
            }

            _context.SolutionInnovationRates.Remove(solutionInnovationRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(solutionInnovationRate);
        }

        private bool SolutionInnovationRateExists(int id)
        {
            return _context.SolutionInnovationRates.Any(e => e.ID == id);
        }
    }
}
