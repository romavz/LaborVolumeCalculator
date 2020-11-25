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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirController : ControllerBase<Nir, NirDto>
    {
        private readonly IRepository<Nir> _context;
        private readonly IRepository<NirStage> _stages;
        public NirController(IRepository<Nir> context, IRepository<NirStage> stages, IMapper mapper) : base(mapper)
        {
            this._stages = stages;
            _context = context;
        }

        // GET: api/Nir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirDto>>> GetNirs()
        {
            var nirs = await _context.GetAll().ToListAsync();

            var nirsDto = ConvertToDto(nirs).ToList();
            return nirsDto;
        }

        // GET: api/Nir/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirDto>> GetNir(int id)
        {
            var nir = await _context.FindAsync(id);

            if (nir == null)
            {
                return NotFound();
            }
            nir.Stages = await _stages.WithIncludes.Where(s => s.NirID == id).ToListAsync();

            return ConvertToDto(nir);
        }

        // PUT: api/Nir/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNir(int id, NirChangeDto nirDto)
        {
            if (id != nirDto.ID)
            {
                return BadRequest();
            }

            var nir = ConvertToSource(nirDto);
            _context.Update(nir);

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

        // POST: api/Nir
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirDto>> PostNir(NirCreateDto nirDto)
        {
            var nir = ConvertToSource(nirDto);
            _context.Add(nir);
            await _context.SaveChangesAsync();

            nir = await _context.FindAsync(nir.ID);

            return CreatedAtAction("GetNir", new { id = nir.ID }, ConvertToDto(nir));
        }

        // DELETE: api/Nir/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirChangeDto>> DeleteNir(int id)
        {
            var nir = await _context.FindAsync(id);
            if (nir == null)
            {
                return NotFound();
            }

            _context.Remove(nir);
            await _context.SaveChangesAsync();

            return ConvertToDto<NirChangeDto>(nir);
        }

        private bool NirExists(int id)
        {
            return _context.Any(e => e.ID == id);
        }
    }
}