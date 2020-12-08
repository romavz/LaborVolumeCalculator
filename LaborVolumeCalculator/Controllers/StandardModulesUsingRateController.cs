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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardModulesUsingRateController : ControllerBase<StandardModulesUsingRate, StandardModulesUsingRateDto>
    {
        private readonly IRepository<StandardModulesUsingRate> _rates;

        public StandardModulesUsingRateController(IRepository<StandardModulesUsingRate> rates, IMapper mapper) : base(mapper)
        {
            _rates = rates;
        }

        // GET: api/StandardModulesUsingRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandardModulesUsingRateDto>>> GetStandardModulesUsingRates()
        {
            var items = await _rates.ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/StandardModulesUsingRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StandardModulesUsingRateDto>> GetStandardModulesUsingRate(int id)
        {
            var standardModulesUsingRate = await _rates.FirstOrDefaultAsync(m => m.ID == id);

            if (standardModulesUsingRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(standardModulesUsingRate);
        }

        // PUT: api/StandardModulesUsingRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandardModulesUsingRate(int id, StandardModulesUsingRateDto standardModulesUsingRateDto)
        {
            if (id != standardModulesUsingRateDto.ID)
            {
                return BadRequest();
            }
            
            var standardModulesUsingRate = ConvertToSource(standardModulesUsingRateDto);
            _rates.Update(standardModulesUsingRate);

            try
            {
                await _rates.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardModulesUsingRateExists(id))
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

        // POST: api/StandardModulesUsingRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StandardModulesUsingRateDto>> PostStandardModulesUsingRate(StandardModulesUsingRateCreateDto standardModulesUsingRateDto)
        {
            var standardModulesUsingRate = ConvertToSource(standardModulesUsingRateDto);
            _rates.Add(standardModulesUsingRate);
            await _rates.SaveChangesAsync();

            return CreatedAtAction("GetStandardModulesUsingRate", new { id = standardModulesUsingRate.ID }, ConvertToDto(standardModulesUsingRate));
        }

        // DELETE: api/StandardModulesUsingRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StandardModulesUsingRateDto>> DeleteStandardModulesUsingRate(int id)
        {
            var standardModulesUsingRate = await _rates.FindAsync(id);
            if (standardModulesUsingRate == null)
            {
                return NotFound();
            }

            _rates.Remove(standardModulesUsingRate);
            await _rates.SaveChangesAsync();

            return ConvertToDto(standardModulesUsingRate);
        }

        private bool StandardModulesUsingRateExists(int id)
        {
            return _rates.Any(e => e.ID == id);
        }
    }
}
