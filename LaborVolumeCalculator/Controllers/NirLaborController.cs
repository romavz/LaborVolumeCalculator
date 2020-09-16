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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborController : ControllerBase<NirLabor, NirLaborDto>
    {
        private readonly LVCContext _context;

        public NirLaborController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirLabor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirLaborDto>>> GetNirLabors()
        {
            var labors = await GetLaborsQuery().ToListAsync();
            var laborsDto = ConvertToDto(labors)
                .OrderBy(m => m.Code, CodeComparer.Instance)
                .ToArray();
            return laborsDto;
        }

        // GET: api/NirLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirLaborDto>> GetNirLabor(int id)
        {
            var nirLabor = await GetLaborsQuery().FirstOrDefaultAsync(m => m.ID == id);

            if (nirLabor == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirLabor);
        }

        private IQueryable<NirLabor> GetLaborsQuery()
        {
            return _context.NirLabors.AsNoTracking();
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

            var nirLabor = ConvertToSource(nirLaborDto);

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

            return Ok();
        }

        // POST: api/NirLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirLabor>> PostNirLabor(NirLaborDto nirLaborDto)
        {
            var nirLabor = ConvertToSource(nirLaborDto);
            
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
    }
}
