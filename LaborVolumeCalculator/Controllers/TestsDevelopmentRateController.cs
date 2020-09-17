using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.DTO;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsDevelopmentRateController : ControllerBase<TestsDevelopmentRate, TestsDevelopmentRateDto>
    {
        private readonly LVCContext _context;

        public TestsDevelopmentRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/TestsDevelopmentRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestsDevelopmentRateDto>>> GetTestsDevelopmentRate()
        {
            var items = await RatesRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/TestsDevelopmentRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestsDevelopmentRateDto>> GetTestsDevelopmentRate(int id)
        {
            var testsDevelopmentRateDto = await RatesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (testsDevelopmentRateDto == null)
            {
                return NotFound();
            }

            return ConvertToDto(testsDevelopmentRateDto);
        }

        private IQueryable<TestsDevelopmentRate> RatesRequest()
        {
            return _context.TestsDevelopmentRates
                .Include(m => m.TestsScale)
                .Include(m => m.TestsCoverageLevel)
                .Include(m => m.ComponentsMicroArchitecture)
                .AsNoTracking();
        }

        // PUT: api/TestsDevelopmentRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestsDevelopmentRate(int id, TestsDevelopmentRateDto testsDevelopmentRateDto)
        {
            if (id != testsDevelopmentRateDto.ID)
            {
                return BadRequest();
            }

            var testsDevelopmentRate = ConvertToSource(testsDevelopmentRateDto);
            _context.Entry(testsDevelopmentRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsDevelopmentRateExists(id))
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

        // POST: api/TestsDevelopmentRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestsDevelopmentRateDto>> PostTestsDevelopmentRate(TestsDevelopmentRateDto testsDevelopmentRateDto)
        {
            var testsDevelopmentRate = ConvertToSource(testsDevelopmentRateDto);
            _context.TestsDevelopmentRates.Add(testsDevelopmentRate);
            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            testsDevelopmentRate = await RatesRequest()
                .FirstOrDefaultAsync(m => m.ID == testsDevelopmentRate.ID);
            
            return CreatedAtAction("GetTestsDevelopmentRate", new { id = testsDevelopmentRateDto.ID }, ConvertToDto(testsDevelopmentRate));
        }

        // DELETE: api/TestsDevelopmentRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestsDevelopmentRateDto>> DeleteTestsDevelopmentRate(int id)
        {
            var testsDevelopmentRate = await _context.TestsDevelopmentRates.FindAsync(id);
            if (testsDevelopmentRate == null)
            {
                return NotFound();
            }

            _context.TestsDevelopmentRates.Remove(testsDevelopmentRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(testsDevelopmentRate);
        }

        private bool TestsDevelopmentRateExists(int id)
        {
            return _context.TestsDevelopmentRates.Any(e => e.ID == id);
        }
    }
}
