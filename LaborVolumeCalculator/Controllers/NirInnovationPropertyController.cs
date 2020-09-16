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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirInnovationPropertyController : ControllerBase<NirInnovationProperty, NirInnovationPropertyDto>
    {
        private readonly LVCContext _context;

        public NirInnovationPropertyController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirInnovationProperty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirInnovationPropertyDto>>> GetNirInnovationProperties()
        {
            var result = await GetPropertiesQuery().ToListAsync();
            return ConvertToDto(result);
        }

        // GET: api/NirInnovationProperty/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirInnovationPropertyDto>> GetNirInnovationProperty(int id)
        {
            var nirInnovationProperty = await GetPropertiesQuery().FirstOrDefaultAsync(m => m.ID == id);

            if (nirInnovationProperty == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirInnovationProperty);
        }

        private IQueryable<NirInnovationProperty> GetPropertiesQuery()
        {
            return _context.NirInnovationProperties.AsNoTracking();
        }

        // PUT: api/NirInnovationProperty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirInnovationProperty(int id, NirInnovationPropertyDto nirInnovationPropertyDto)
        {
            if (id != nirInnovationPropertyDto.ID)
            {
                return BadRequest();
            }

            var nirInnovationProperty = ConvertToSource(nirInnovationPropertyDto);
            _context.Entry(nirInnovationProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirInnovationPropertyExists(id))
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

        // POST: api/NirInnovationProperty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirInnovationPropertyDto>> PostNirInnovationProperty(NirInnovationPropertyDto nirInnovationPropertyDto)
        {
            var nirInnovationProperty = ConvertToSource(nirInnovationPropertyDto);
            _context.NirInnovationProperties.Add(nirInnovationProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirInnovationProperty", new { id = nirInnovationProperty.ID }, ConvertToDto(nirInnovationProperty));
        }

        // DELETE: api/NirInnovationProperty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirInnovationPropertyDto>> DeleteNirInnovationProperty(int id)
        {
            var nirInnovationProperty = await _context.NirInnovationProperties.FindAsync(id);
            if (nirInnovationProperty == null)
            {
                return NotFound();
            }

            _context.NirInnovationProperties.Remove(nirInnovationProperty);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirInnovationProperty);
        }

        private bool NirInnovationPropertyExists(int id)
        {
            return _context.NirInnovationProperties.Any(e => e.ID == id);
        }
    }
}
