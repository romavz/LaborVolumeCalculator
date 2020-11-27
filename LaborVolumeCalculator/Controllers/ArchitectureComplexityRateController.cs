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
    public class ArchitectureComplexityRateController : ControllerBase<ArchitectureComplexityRate, ArchitectureComplexityRateDto>
    {
        private readonly IRepository<ArchitectureComplexityRate> _rates;

        public ArchitectureComplexityRateController(IRepository<ArchitectureComplexityRate> rates, IMapper mapper) : base(mapper)
        {
            _rates = rates;
        }

        // GET: api/ArchitectureComplexityRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchitectureComplexityRateDto>>> GetArchitectureComplexityRates()
        {
            var items = await _rates.WithIncludes.ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/ArchitectureComplexityRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> GetArchitectureComplexityRate(int id)
        {
            var architectureComplexityRate = await _rates.WithIncludes.FirstOrDefaultAsync(m => m.ID == id);

            if (architectureComplexityRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(architectureComplexityRate);
        }

        // PUT: api/ArchitectureComplexityRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchitectureComplexityRate(int id, ArchitectureComplexityRateShortDto architectureComplexityRateDto)
        {
            if (id != architectureComplexityRateDto.ID)
            {
                return BadRequest();
            }

            var rate = ConvertToSource(architectureComplexityRateDto);
            _rates.Update(rate);

            try
            {
                await _rates.SaveChangesAsync();
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

            rate = await _rates.FindAsync(id);

            return Ok(ConvertToDto<ArchitectureComplexityRateShortDto>(rate));
        }

        // POST: api/ArchitectureComplexityRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> PostArchitectureComplexityRate(ArchitectureComplexityRateCreateDto architectureComplexityRateDto)
        {
            var rate = ConvertToSource(architectureComplexityRateDto);
            _rates.Add(rate);
            try 
            {
                await _rates.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }

            rate = await _rates.WithIncludes.FindAsync(rate.ID);
            return CreatedAtAction("GetArchitectureComplexityRate", new { id = rate.ID }, ConvertToDto(rate));
        }

        // DELETE: api/ArchitectureComplexityRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchitectureComplexityRateDto>> DeleteArchitectureComplexityRate(int id)
        {
            var rate = await _rates.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }

            _rates.Remove(rate);
            await _rates.SaveChangesAsync();

            return ConvertToDto(rate);
        }

        private bool ArchitectureComplexityRateExists(int id)
        {
            return _rates.Any(e => e.ID == id);
        }
    }
}
