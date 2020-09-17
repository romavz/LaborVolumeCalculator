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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardModulesUsingRateController : ControllerBase<StandardModulesUsingRate, StandardModulesUsingRateDto>
    {
        private readonly LVCContext _context;

        public StandardModulesUsingRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/StandardModulesUsingRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandardModulesUsingRateDto>>> GetStandardModulesUsingRates()
        {
            var items = await RatesRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/StandardModulesUsingRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StandardModulesUsingRateDto>> GetStandardModulesUsingRate(int id)
        {
            var standardModulesUsingRate = await RatesRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (standardModulesUsingRate == null)
            {
                return NotFound();
            }

            return ConvertToDto(standardModulesUsingRate);
        }

        private IQueryable<StandardModulesUsingRate> RatesRequest()
        {
            return _context.StandardModulesUsingRates.AsNoTracking();
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
            _context.Entry(standardModulesUsingRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<StandardModulesUsingRateDto>> PostStandardModulesUsingRate(StandardModulesUsingRateDto standardModulesUsingRateDto)
        {
            var standardModulesUsingRate = ConvertToSource(standardModulesUsingRateDto);
            _context.StandardModulesUsingRates.Add(standardModulesUsingRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStandardModulesUsingRate", new { id = standardModulesUsingRate.ID }, ConvertToDto(standardModulesUsingRate));
        }

        // DELETE: api/StandardModulesUsingRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StandardModulesUsingRateDto>> DeleteStandardModulesUsingRate(int id)
        {
            var standardModulesUsingRate = await _context.StandardModulesUsingRates.FindAsync(id);
            if (standardModulesUsingRate == null)
            {
                return NotFound();
            }

            _context.StandardModulesUsingRates.Remove(standardModulesUsingRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(standardModulesUsingRate);
        }

        private bool StandardModulesUsingRateExists(int id)
        {
            return _context.StandardModulesUsingRates.Any(e => e.ID == id);
        }
    }
}
