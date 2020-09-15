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
    public class NirLaborController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirLaborController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/NirLabor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirLaborDto>>> GetNirLabors()
        {
            var labors = await _context.NirLabors.ToListAsync();
            var laborsDto = ConvertToDto(labors).ToList();
            return laborsDto;
        }

        // GET: api/NirLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirLaborDto>> GetNirLabor(int id)
        {
            var nirLabor = await _context.NirLabors.FindAsync(id);

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
        public async Task<IActionResult> PutNirLabor(int id, NirLaborDto nirLaborDto)
        {
            if (id != nirLaborDto.ID)
            {
                return BadRequest();
            }

            var nirLabor = ConvertFromDto(nirLaborDto);

            _context.Entry(nirLabor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborExists(id))
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

        // POST: api/NirLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirLabor>> PostNirLabor(NirLaborDto nirLaborDto)
        {
            var nirLabor = ConvertFromDto(nirLaborDto);
            
            _context.NirLabors.Add(nirLabor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirLabor", new { id = nirLabor.ID }, ConvertToDto(nirLabor));
        }

        // DELETE: api/NirLabor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirLaborDto>> DeleteNirLabor(int id)
        {
            var nirLabor = await _context.NirLabors.FindAsync(id);
            if (nirLabor == null)
            {
                return NotFound();
            }

            _context.NirLabors.Remove(nirLabor);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirLabor);
        }

        private bool NirLaborExists(int id)
        {
            return _context.NirLabors.Any(e => e.ID == id);
        }

        private NirLaborDto ConvertToDto(NirLabor labor)
        {
            return _mapper.Map<NirLabor, NirLaborDto>(labor);
        }

        private NirLabor ConvertFromDto(NirLaborDto item)
        {
            return _mapper.Map<NirLaborDto, NirLabor>(item);
        }
        
        private IEnumerable<NirLaborDto> ConvertToDto(List<NirLabor> labors)
        {
            return _mapper.Map<IEnumerable<NirLabor>, IEnumerable<NirLaborDto>>(labors);
        }
    }
}
