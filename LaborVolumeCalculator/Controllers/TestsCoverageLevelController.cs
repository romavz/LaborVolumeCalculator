using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsCoverageLevelController : ControllerBase<TestsCoverageLevel, TestsCoverageLevelDto>
    {
        private readonly IRepository<TestsCoverageLevel> _levels;

        public TestsCoverageLevelController(IRepository<TestsCoverageLevel> levels, IMapper mapper) : base(mapper)
        {
            _levels = levels;
        }

        // GET: api/TestsCoverageLevel
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TestsCoverageLevelDto>>> GetTestsCoverageLevels()
        {
            var items = await _levels.ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/TestsCoverageLevel/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestsCoverageLevelDto>> GetTestsCoverageLevel(int id)
        {
            var testsCoverageLevel = await _levels.FindAsync(id);

            if (testsCoverageLevel == null)
            {
                return NotFound();
            }

            return ConvertToDto(testsCoverageLevel);
        }

        // PUT: api/TestsCoverageLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutTestsCoverageLevel(int id, TestsCoverageLevelDto testsCoverageLevelDto)
        {
            var testsCoverageLevel = ConvertToSource(testsCoverageLevelDto);

            if (id != testsCoverageLevel.ID)
            {
                return BadRequest();
            }

            _levels.Update(testsCoverageLevel);

            try
            {
                await _levels.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsCoverageLevelExists(id))
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

        // POST: api/TestsCoverageLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<TestsCoverageLevelDto>> PostTestsCoverageLevel(TestsCoverageLevelCreateDto testsCoverageLevelDto)
        {
            var testsCoverageLevel = ConvertToSource(testsCoverageLevelDto);
            _levels.Add(testsCoverageLevel);
            await _levels.SaveChangesAsync();

            return CreatedAtAction("GetTestsCoverageLevel", new { id = testsCoverageLevel.ID }, ConvertToDto(testsCoverageLevel));
        }

        // DELETE: api/TestsCoverageLevel/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTestsCoverageLevel(int id)
        {
            var testsCoverageLevel = await _levels.FindAsync(id);
            if (testsCoverageLevel == null)
            {
                return NotFound();
            }

            _levels.Remove(testsCoverageLevel);
            await _levels.SaveChangesAsync();

            return Ok();
        }

        private bool TestsCoverageLevelExists(int id)
        {
            return _levels.Any(e => e.ID == id);
        }
    }
}
