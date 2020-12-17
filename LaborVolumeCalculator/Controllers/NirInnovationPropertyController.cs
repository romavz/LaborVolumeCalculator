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
    public class NirInnovationPropertyController : ControllerBase<NirInnovationProperty, NirInnovationPropertyDto>
    {
        private readonly IRepository<NirInnovationProperty> _properties;

        public NirInnovationPropertyController(IRepository<NirInnovationProperty> context, IMapper mapper) : base(mapper)
        {
            _properties = context;
        }

        // GET: api/NirInnovationProperty
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NirInnovationPropertyDto>>> GetNirInnovationProperties()
        {
            var result = await _properties.ToListAsync();
            return ConvertToDto(result);
        }

        // GET: api/NirInnovationProperty/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirInnovationPropertyDto>> GetNirInnovationProperty(int id)
        {
            var nirInnovationProperty = await _properties.FirstOrDefaultAsync(m => m.ID == id);

            if (nirInnovationProperty == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirInnovationProperty);
        }

        // PUT: api/NirInnovationProperty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutNirInnovationProperty(int id, NirInnovationPropertyDto nirInnovationPropertyDto)
        {
            if (id != nirInnovationPropertyDto.ID)
            {
                return BadRequest();
            }

            var nirInnovationProperty = ConvertToSource(nirInnovationPropertyDto);
            _properties.Update(nirInnovationProperty);

            try
            {
                await _properties.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirInnovationPropertyExists(id))
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

        // POST: api/NirInnovationProperty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<NirInnovationPropertyDto>> PostNirInnovationProperty(NirInnovationPropertyCreateDto nirInnovationPropertyDto)
        {
            var nirInnovationProperty = ConvertToSource(nirInnovationPropertyDto);
            _properties.Add(nirInnovationProperty);
            await _properties.SaveChangesAsync();

            return CreatedAtAction("GetNirInnovationProperty", new { id = nirInnovationProperty.ID }, ConvertToDto(nirInnovationProperty));
        }

        // DELETE: api/NirInnovationProperty/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirInnovationPropertyDto>> DeleteNirInnovationProperty(int id)
        {
            var nirInnovationProperty = await _properties.FindAsync(id);
            if (nirInnovationProperty == null)
            {
                return NotFound();
            }

            _properties.Remove(nirInnovationProperty);
            await _properties.SaveChangesAsync();

            return ConvertToDto(nirInnovationProperty);
        }

        private bool NirInnovationPropertyExists(int id)
        {
            return _properties.Any(e => e.ID == id);
        }
    }
}
