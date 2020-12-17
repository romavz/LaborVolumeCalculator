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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionInnovationRateController : ControllerBase<SolutionInnovationRate, SolutionInnovationRateDto>
    {
        private readonly IRepository<SolutionInnovationRate> _rates;

        public SolutionInnovationRateController(IRepository<SolutionInnovationRate> rates, IMapper mapper) : base(mapper)
        {
            _rates = rates;
        }

        // GET: api/SolutionInnovationRate
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SolutionInnovationRateDto>>> GetSolutionInnovationRates()
        {
            var items = await _rates.ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/SolutionInnovationRate/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SolutionInnovationRateDto>> GetSolutionInnovationRate(int id)
        {
            var solutionInnovationRate = await _rates.FirstOrDefaultAsync(m => m.ID == id);

            if (solutionInnovationRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(solutionInnovationRate);
        }

        // PUT: api/SolutionInnovationRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutSolutionInnovationRate(int id, SolutionInnovationRateDto solutionInnovationRateDto)
        {
            if (id != solutionInnovationRateDto.ID)
            {
                return BadRequest();
            }

            var solutionInnovationRate = ConvertToSource(solutionInnovationRateDto);
            _rates.Update(solutionInnovationRate);

            try
            {
                await _rates.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionInnovationRateExists(id))
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

        // POST: api/SolutionInnovationRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<SolutionInnovationRateDto>> PostSolutionInnovationRate(SolutionInnovationRateCreateDto solutionInnovationRateDto)
        {
            var solutionInnovationRate = ConvertToSource(solutionInnovationRateDto);
            _rates.Add(solutionInnovationRate);
            await _rates.SaveChangesAsync();

            return CreatedAtAction("GetSolutionInnovationRate", new { id = solutionInnovationRate.ID }, ConvertToDto(solutionInnovationRate));
        }

        // DELETE: api/SolutionInnovationRate/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SolutionInnovationRateDto>> DeleteSolutionInnovationRate(int id)
        {
            var solutionInnovationRate = await _rates.FindAsync(id);
            if (solutionInnovationRate == null)
            {
                return NotFound();
            }

            _rates.Remove(solutionInnovationRate);
            await _rates.SaveChangesAsync();

            return ConvertToDto(solutionInnovationRate);
        }

        private bool SolutionInnovationRateExists(int id)
        {
            return _rates.Any(e => e.ID == id);
        }
    }
}
