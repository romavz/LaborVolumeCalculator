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
    public class NirScaleController : ControllerBase<NirScale, NirScaleDto>
    {
        private readonly LVCContext _context;

        public NirScaleController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirScale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirScaleDto>>> GetNirScales()
        {
            var result = await _context.NirScales.ToListAsync();
            return ConvertToDto(result);
        }

        // GET: api/NirScale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirScaleDto>> GetNirScale(int id)
        {
            var nirScale = await _context.NirScales.FindAsync(id);

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
        public async Task<IActionResult> PutNirScale(int id, NirScaleDto nirScaleDto)
        {
            if (id != nirScaleDto.ID)
            {
                return BadRequest();
            }

            var nirScale = ConvertToSource(nirScaleDto);
            _context.Entry(nirScale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirScaleExists(id))
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

        // POST: api/NirScale
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirScaleDto>> PostNirScale(NirScaleDto nirScaleDto)
        {
            var nirScale = ConvertToSource(nirScaleDto);
            _context.NirScales.Add(nirScale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirScale", new { id = nirScale.ID }, ConvertToDto(nirScale));
        }

        // DELETE: api/NirScale/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirScaleDto>> DeleteNirScale(int id)
        {
            var nirScale = await _context.NirScales.FindAsync(id);
            if (nirScale == null)
            {
                return NotFound();
            }

            _context.NirScales.Remove(nirScale);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirScale);
        }

        private bool NirScaleExists(int id)
        {
            return _context.NirScales.Any(e => e.ID == id);
        }
    }
}
