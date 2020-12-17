using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NirDto>>> GetNirs()
        {
            var nirs = await _context.GetAll().ToListAsync();

            var nirsDto = ConvertToDto(nirs).ToList();
            return nirsDto;
        }

        // GET: api/Nir/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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
                    return Conflict();
                }
            }

            return Ok();
        }

        // POST: api/Nir
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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