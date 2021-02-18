using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Repositories.Extentions;
using Microsoft.AspNetCore.Http;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsMicroArchitectureController : ControllerBase<ComponentsMicroArchitecture, ComponentsMicroArchitectureDto>
    {
        private readonly IRepository<ComponentsMicroArchitecture> _architectures;

        public ComponentsMicroArchitectureController(IRepository<ComponentsMicroArchitecture> architectures, IMapper mapper) : base(mapper)
        {
            _architectures = architectures;
        }

        // GET: api/ComponentsMicroArchitecture
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ComponentsMicroArchitectureDto>>> GetComponentsMicroArchitectures()
        {
            var items = await _architectures.GetAll()
                .OrderBy(m => m.Code)
                .ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/ComponentsMicroArchitecture/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComponentsMicroArchitectureDto>> GetComponentsMicroArchitecture(int id)
        {
            var componentsMicroArchitecture = await _architectures.FindAsync(id);

            if (componentsMicroArchitecture == null)
            {
                return NotFound();
            }

            return ConvertToDto(componentsMicroArchitecture);
        }

        // PUT: api/ComponentsMicroArchitecture/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutComponentsMicroArchitecture(int id, ComponentsMicroArchitectureDto componentsMicroArchitectureDto)
        {
            var componentsMicroArchitecture = ConvertToSource(componentsMicroArchitectureDto);
            if (id != componentsMicroArchitecture.ID)
            {
                return BadRequest();
            }

            _architectures.Update(componentsMicroArchitecture);

            try
            {
                await _architectures.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentsMicroArchitectureExists(id))
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

        // POST: api/ComponentsMicroArchitecture
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<ComponentsMicroArchitectureDto>> PostComponentsMicroArchitecture(ComponentsMicroArchitectureCreateDto componentsMicroArchitectureDto)
        {
            var componentsMicroArchitecture = ConvertToSource(componentsMicroArchitectureDto);
            _architectures.Add(componentsMicroArchitecture);
            await _architectures.SaveChangesAsync();

            return CreatedAtAction("GetComponentsMicroArchitecture", new { id = componentsMicroArchitecture.ID }, ConvertToDto(componentsMicroArchitecture));
        }

        // DELETE: api/ComponentsMicroArchitecture/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComponentsMicroArchitectureDto>> DeleteComponentsMicroArchitecture(int id)
        {
            var componentsMicroArchitecture = await _architectures.FindAsync(id);
            if (componentsMicroArchitecture == null)
            {
                return NotFound();
            }

            _architectures.Remove(componentsMicroArchitecture);
            await _architectures.SaveChangesAsync();

            return Ok(ConvertToDto(componentsMicroArchitecture));
        }

        private bool ComponentsMicroArchitectureExists(int id)
        {
            return _architectures.Any(e => e.ID == id);
        }
    }
}
