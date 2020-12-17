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
    public class NirScaleController : ControllerBase<NirScale, NirScaleDto>
    {
        private readonly IRepository<NirScale> _scales;

        public NirScaleController(IRepository<NirScale> scales, IMapper mapper) : base(mapper)
        {
            _scales = scales;
        }

        // GET: api/NirScale
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NirScaleDto>>> GetNirScales()
        {
            var result = await _scales.ToListAsync();
            return ConvertToDto(result);
        }

        // GET: api/NirScale/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirScaleDto>> GetNirScale(int id)
        {
            var nirScale = await _scales.FirstOrDefaultAsync(m => m.ID == id);

            if (nirScale == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirScale);
        }

        // PUT: api/NirScale/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutNirScale(int id, NirScaleDto nirScaleDto)
        {
            if (id != nirScaleDto.ID)
            {
                return BadRequest();
            }

            var nirScale = ConvertToSource(nirScaleDto);
            _scales.Update(nirScale);

            try
            {
                await _scales.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirScaleExists(id))
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

        // POST: api/NirScale
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<NirScaleDto>> PostNirScale(NirScaleCreateDto nirScaleDto)
        {
            var nirScale = ConvertToSource(nirScaleDto);
            _scales.Add(nirScale);
            await _scales.SaveChangesAsync();

            return CreatedAtAction("GetNirScale", new { id = nirScale.ID }, ConvertToDto(nirScale));
        }

        // DELETE: api/NirScale/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirScaleDto>> DeleteNirScale(int id)
        {
            var nirScale = await _scales.FindAsync(id);
            if (nirScale == null)
            {
                return NotFound();
            }

            _scales.Remove(nirScale);
            await _scales.SaveChangesAsync();

            return ConvertToDto(nirScale);
        }

        private bool NirScaleExists(int id)
        {
            return _scales.Any(e => e.ID == id);
        }
    }
}
