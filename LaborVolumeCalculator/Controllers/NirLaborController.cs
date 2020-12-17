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
using LaborVolumeCalculator.Utils;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborController : ControllerBase<NirLabor, LaborDto>
    {
        private readonly IRepository<NirLabor> _labors;

        public NirLaborController(IRepository<NirLabor> labors, IMapper mapper) : base(mapper)
        {
            _labors = labors;
        }

        // GET: api/NirLabor
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LaborDto>>> GetNirLabors()
        {
            var labors = await _labors.ToListAsync();
            var laborsDto = ConvertToDto(labors)
                .OrderBy(m => m.Code, CodeComparer.Instance)
                .ToArray();
            return laborsDto;
        }

        // GET: api/NirLabor/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LaborDto>> GetNirLabor(int id)
        {
            var nirLabor = await _labors.FindAsync(id);

            if (nirLabor == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirLabor);
        }

        // PUT: api/NirLabor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutNirLabor(int id, LaborDto nirLaborDto)
        {
            if (id != nirLaborDto.ID)
            {
                return BadRequest();
            }

            var nirLabor = ConvertToSource(nirLaborDto);

            _labors.Update(nirLabor);

            try
            {
                await _labors.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborExists(id))
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

        // POST: api/NirLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<LaborDto>> PostNirLabor(LaborCreateDto nirLaborDto)
        {
            var nirLabor = ConvertToSource(nirLaborDto);
            
            _labors.Add(nirLabor);
            await _labors.SaveChangesAsync();

            return CreatedAtAction("GetNirLabor", new { id = nirLabor.ID }, ConvertToDto(nirLabor));
        }

        // DELETE: api/NirLabor/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LaborDto>> DeleteNirLabor(int id)
        {
            var nirLabor = await _labors.FindAsync(id);
            if (nirLabor == null)
            {
                return NotFound();
            }

            _labors.Remove(nirLabor);
            await _labors.SaveChangesAsync();

            return ConvertToDto(nirLabor);
        }

        private bool NirLaborExists(int id)
        {
            return _labors.Any(e => e.ID == id);
        }
    }
}
