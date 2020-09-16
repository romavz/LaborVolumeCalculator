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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirInnovationRateController : ControllerBase<NirInnovationRate, NirInnovationRateDto>
    {
        private readonly LVCContext _context;

        public NirInnovationRateController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirInnovationRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirInnovationRateDto>>> GetNirInnovationRates()
        {
            var result = await GetRatesQuery().ToListAsync();
            return ConvertToDto(result);
        }

        private IIncludableQueryable<NirInnovationRate, NirScale> GetRatesQuery()
        {
            return _context.NirInnovationRates
                .Include(r => r.NirInnovationProperty)
                .Include(r => r.NirScale);
        }

        // GET: api/NirInnovationRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirInnovationRateDto>> GetNirInnovationRate(int id)
        {
            var nirInnovationRate = await GetRatesQuery().FirstOrDefaultAsync(n => n.ID == id);

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
        public async Task<IActionResult> PutNirInnovationRate(int id, NirInnovationRateDto nirInnovationRateDto)
        {
            if (id != nirInnovationRateDto.ID)
            {
                return BadRequest();
            }

            var nirInnovationRate = ConvertToSource(nirInnovationRateDto);
            _context.Entry(nirInnovationRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirInnovationRateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NirInnovationRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirInnovationRateDto>> PostNirInnovationRate(NirInnovationRateDto nirInnovationRateDto)
        {
            var nirInnovationRate = ConvertToSource(nirInnovationRateDto);
            _context.NirInnovationRates.Add(nirInnovationRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirInnovationRate", new { id = nirInnovationRate.ID }, ConvertToDto(nirInnovationRate));
        }

        // DELETE: api/NirInnovationRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirInnovationRateDto>> DeleteNirInnovationRate(int id)
        {
            var nirInnovationRate = await _context.NirInnovationRates.FindAsync(id);
            if (nirInnovationRate == null)
            {
                return NotFound();
            }

            _context.NirInnovationRates.Remove(nirInnovationRate);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirInnovationRate);
        }

        private bool NirInnovationRateExists(int id)
        {
            return _context.NirInnovationRates.Any(e => e.ID == id);
        }
    }
}
