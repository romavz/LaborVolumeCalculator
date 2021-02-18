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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsDevelopmentRateController : ControllerBase<TestsDevelopmentRate, TestsDevelopmentRateDto>
    {
        private readonly IRepository<TestsDevelopmentRate> _rates;

        public TestsDevelopmentRateController(IRepository<TestsDevelopmentRate> rates, IMapper mapper) : base(mapper)
        {
            _rates = rates;
        }

        // GET: api/TestsDevelopmentRate
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TestsDevelopmentRateDto>>> GetTestsDevelopmentRate()
        {
            var items = await _rates.WithIncludes
                .OrderBy(m => m.ComponentsMicroArchitecture.Code)
                .ThenBy(m => m.TestsScale.Code)
                .ThenBy(m => m.TestsCoverageLevel.Code)
                .ToListAsync();
                
            return ConvertToDto(items);
        }

        // GET: api/TestsDevelopmentRate/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestsDevelopmentRateDto>> GetTestsDevelopmentRate(int id)
        {
            var testsDevelopmentRateDto = await _rates.WithIncludes.FirstOrDefaultAsync(m => m.ID == id);

            if (testsDevelopmentRateDto == null)
            {
                return NotFound();
            }

            return ConvertToDto(testsDevelopmentRateDto);
        }

        // PUT: api/TestsDevelopmentRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutTestsDevelopmentRate(int id, TestsDevelopmentRateUpdateDto testsDevelopmentRateDto)
        {
            if (id != testsDevelopmentRateDto.ID)
            {
                return BadRequest();
            }

            var testsDevelopmentRate = ConvertToSource(testsDevelopmentRateDto);
            _rates.Update(testsDevelopmentRate);

            try
            {
                await _rates.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsDevelopmentRateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return Ok();
        }

        // POST: api/TestsDevelopmentRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<TestsDevelopmentRateDto>> PostTestsDevelopmentRate(TestsDevelopmentRateCreateDto testsDevelopmentRateDto)
        {
            var testsDevelopmentRate = ConvertToSource(testsDevelopmentRateDto);
            _rates.Add(testsDevelopmentRate);
            try 
            {
                await _rates.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            testsDevelopmentRate = await _rates.WithIncludes
                .FirstOrDefaultAsync(m => m.ID == testsDevelopmentRate.ID);
            
            return CreatedAtAction("GetTestsDevelopmentRate", new { id = testsDevelopmentRate.ID }, ConvertToDto(testsDevelopmentRate));
        }

        // DELETE: api/TestsDevelopmentRate/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestsDevelopmentRateDto>> DeleteTestsDevelopmentRate(int id)
        {
            var testsDevelopmentRate = await _rates.FindAsync(id);
            if (testsDevelopmentRate == null)
            {
                return NotFound();
            }

            _rates.Remove(testsDevelopmentRate);
            await _rates.SaveChangesAsync();

            return ConvertToDto(testsDevelopmentRate);
        }

        private bool TestsDevelopmentRateExists(int id)
        {
            return _rates.Any(e => e.ID == id);
        }
    }
}
