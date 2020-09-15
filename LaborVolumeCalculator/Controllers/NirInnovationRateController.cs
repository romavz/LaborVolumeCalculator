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
    public class NirInnovationRateController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirInnovationRateController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/NirInnovationRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirInnovationRate>>> GetNirInnovationRates()
        {
            return await _context.NirInnovationRates.ToListAsync();
        }

        // GET: api/NirInnovationRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirInnovationRate>> GetNirInnovationRate(int id)
        {
            var nirInnovationRate = await _context.NirInnovationRates.FindAsync(id);

            if (nirInnovationRate == null)
            {
                return NotFound();
            }

            return nirInnovationRate;
        }

        // PUT: api/NirInnovationRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirInnovationRate(int id, NirInnovationRate nirInnovationRate)
        {
            if (id != nirInnovationRate.ID)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<NirInnovationRate>> PostNirInnovationRate(NirInnovationRate nirInnovationRate)
        {
            _context.NirInnovationRates.Add(nirInnovationRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirInnovationRate", new { id = nirInnovationRate.ID }, nirInnovationRate);
        }

        // DELETE: api/NirInnovationRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirInnovationRate>> DeleteNirInnovationRate(int id)
        {
            var nirInnovationRate = await _context.NirInnovationRates.FindAsync(id);
            if (nirInnovationRate == null)
            {
                return NotFound();
            }

            _context.NirInnovationRates.Remove(nirInnovationRate);
            await _context.SaveChangesAsync();

            return nirInnovationRate;
        }

        private bool NirInnovationRateExists(int id)
        {
            return _context.NirInnovationRates.Any(e => e.ID == id);
        }

        private IEnumerable<NirInnovationRateDto> ConvertToDto(List<NirInnovationRate> nirs)
        {
            return _mapper.Map<IList<NirInnovationRate>, IEnumerable<NirInnovationRateDto>>(nirs);
        }

        private NirInnovationRateDto ConvertToDto(NirInnovationRate nir)
        {
            return _mapper.Map<NirInnovationRate, NirInnovationRateDto>(nir);
        }

        private NirInnovationRate ConvertFromDto(NirInnovationRateDto NirInnovationRateDto)
        {
            return _mapper.Map<NirInnovationRateDto, NirInnovationRate>(NirInnovationRateDto);
        }
    }
}
