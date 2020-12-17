using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using AutoMapper;
using LaborVolumeCalculator.DTO;
using Microsoft.EntityFrameworkCore.Query;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirInnovationRateController : ControllerBase<NirInnovationRate, NirInnovationRateDto>
    {
        private readonly IRepository<NirInnovationRate> _rates;

        public NirInnovationRateController(IRepository<NirInnovationRate> context, IMapper mapper) : base(mapper)
        {
            _rates = context;
        }

        // GET: api/NirInnovationRate
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NirInnovationRateDto>>> GetNirInnovationRates()
        {
            var result = await _rates.WithIncludes.ToListAsync();
            return ConvertToDto(result);
        }

        // GET: api/NirInnovationRate/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirInnovationRateDto>> GetNirInnovationRate(int id)
        {
            var nirInnovationRate = await _rates.WithIncludes.FirstOrDefaultAsync(n => n.ID == id);

            if (nirInnovationRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirInnovationRate);
        }

        // PUT: api/NirInnovationRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutNirInnovationRate(int id, NirInnovationRateUpdateDto nirInnovationRateDto)
        {
            if (id != nirInnovationRateDto.ID)
            {
                return BadRequest();
            }

            var nirInnovationRate = ConvertToSource(nirInnovationRateDto);
            _rates.Update(nirInnovationRate);

            try
            {
                await _rates.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirInnovationRateExists(id))
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

        // POST: api/NirInnovationRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<NirInnovationRateDto>> PostNirInnovationRate(NirInnovationRateCreateDto nirInnovationRateDto)
        {
            var nirInnovationRate = ConvertToSource(nirInnovationRateDto);
            _rates.Add(nirInnovationRate);
            await _rates.SaveChangesAsync();

            return CreatedAtAction("GetNirInnovationRate", new { id = nirInnovationRate.ID }, ConvertToDto(nirInnovationRate));
        }

        // DELETE: api/NirInnovationRate/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirInnovationRateDto>> DeleteNirInnovationRate(int id)
        {
            var nirInnovationRate = await _rates.FindAsync(id);
            if (nirInnovationRate == null)
            {
                return NotFound();
            }

            _rates.Remove(nirInnovationRate);
            await _rates.SaveChangesAsync();

            return ConvertToDto(nirInnovationRate);
        }

        private bool NirInnovationRateExists(int id)
        {
            return _rates.Any(e => e.ID == id);
        }
    }
}
