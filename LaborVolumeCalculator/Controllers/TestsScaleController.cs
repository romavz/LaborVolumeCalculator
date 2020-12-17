using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsScaleController : ControllerBase<TestsScale, TestsScaleDto>
    {
        private readonly IRepository<TestsScale> _scales;

        public TestsScaleController(IRepository<TestsScale> scales, IMapper mapper) : base(mapper)
        {
            _scales = scales;
        }

        // GET: api/TestsScale
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TestsScaleDto>>> GetTestsScales()
        {
            var items = await _scales.ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/TestsScale/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestsScaleDto>> GetTestsScale(int id)
        {
            var testsScale = await _scales.FindAsync(id);

            if (testsScale == null)
            {
                return NotFound();
            }

            return ConvertToDto(testsScale);
        }

        // PUT: api/TestsScale/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutTestsScale(int id, TestsScaleDto testsScaleDto)
        {
            var testsScale = ConvertToSource(testsScaleDto);
            if (id != testsScale.ID)
            {
                return BadRequest();
            }

            _scales.Update(testsScale);

            try
            {
                await _scales.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsScaleExists(id))
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

        // POST: api/TestsScale
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<TestsScaleDto>> PostTestsScale(TestsScaleCreateDto testsScaleDto)
        {
            var testsScale = ConvertToSource(testsScaleDto);
            _scales.Add(testsScale);
            await _scales.SaveChangesAsync();

            return CreatedAtAction("GetTestsScale", new { id = testsScale.ID }, ConvertToDto(testsScale));
        }

        // DELETE: api/TestsScale/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTestsScale(int id)
        {
            var testsScale = await _scales.FindAsync(id);
            if (testsScale == null)
            {
                return NotFound();
            }

            _scales.Remove(testsScale);
            await _scales.SaveChangesAsync();

            return Ok();
        }

        private bool TestsScaleExists(int id)
        {
            return _scales.Any(e => e.ID == id);
        }
    }
}
