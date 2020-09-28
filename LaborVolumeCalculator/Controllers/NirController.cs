using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NSwag.Annotations;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirController : ControllerBase<Nir, NirDto>
    {
        private readonly LVCContext _context;
        public NirController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirDto>>> GetNirs()
        {
            var nirs = await NirsQuery().ToListAsync();
            
            var nirsDto = ConvertToDto(nirs).ToList();
            return nirsDto;
        }

        // GET: api/NirController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirDto>> GetNir(int id)
        {
            var nir = await NirsQuery().FirstOrDefaultAsync(n => n.ID == id);

            if (nir == null)
            {
                return NotFound();
            }

            return ConvertToDto(nir);
        }

        private IQueryable<Nir> NirsQuery()
        {
            return _context.Nirs
                .AsNoTracking();
        }

        // PUT: api/NirController/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNir(int id, NirDto nirDto)
        {
            if (id != nirDto.ID)
            {
                return BadRequest();
            }

            var nir = ConvertToSource(nirDto);
            _context.Entry(nir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirExists(id))
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

        // POST: api/NirController
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirDto>> PostNir(NirCreateDto nirDto)
        {
            var nir = ConvertToSource(nirDto);
            _context.Nirs.Add(nir);
            await _context.SaveChangesAsync();

            nir = await NirsQuery().FirstOrDefaultAsync(m => m.ID == nir.ID);
            
            return CreatedAtAction("GetNir", new { id = nir.ID }, ConvertToDto(nir));
        }

        // DELETE: api/NirController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirDto>> DeleteNir(int id)
        {
            var nir = await _context.Nirs.FindAsync(id);
            if (nir == null)
            {
                return NotFound();
            }

            _context.Nirs.Remove(nir);
            await _context.SaveChangesAsync();

            return ConvertToDto(nir);
        }

        private bool NirExists(int id)
        {
            return _context.Nirs.Any(e => e.ID == id);
        }
    }
}