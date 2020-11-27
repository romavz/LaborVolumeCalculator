using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsMacroArchitectureController : ControllerBase<ComponentsMakroArchitecture, ComponentsMacroArchitectureDto>
    {
        private readonly IRepository<ComponentsMakroArchitecture> _architectures;

        public ComponentsMacroArchitectureController(IRepository<ComponentsMakroArchitecture> architectures, IMapper mapper) : base(mapper)
        {
            _architectures = architectures;
        }

        // GET: api/ComponentsMakroArchitecture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentsMacroArchitectureDto>>> GetComponentsMakroArchitectures()
        {
            var items = await _architectures.ToListAsync();
            return ConvertToDto(items)
                        .OrderBy(m => m.Name)
                        .ToList();
        }

        // GET: api/ComponentsMakroArchitecture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentsMacroArchitectureDto>> GetComponentsMakroArchitecture(int id)
        {
            var architecture = await _architectures.FindAsync(id);

            if (architecture == null)
            {
                return NotFound();
            }

            return ConvertToDto(architecture);
        }

        // PUT: api/ComponentsMakroArchitecture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ComponentsMacroArchitectureDto>> PutComponentsMakroArchitecture(int id, ComponentsMacroArchitectureDto architectureDto)
        {
            var architecture = ConvertToSource(architectureDto);
            
            if (id != architecture.ID)
            {
                return BadRequest();
            }

            _architectures.Update(architecture);

            try
            {
                await _architectures.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentsMakroArchitectureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ConvertToDto(architecture));
        }

        // POST: api/ComponentsMakroArchitecture
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComponentsMacroArchitectureDto>> PostComponentsMakroArchitecture(ComponentsMacroArchitectureCreateDto architectureDto)
        {
            var architecture = ConvertToSource(architectureDto);
            _architectures.Add(architecture);
            await _architectures.SaveChangesAsync();

            return CreatedAtAction("GetComponentsMakroArchitecture", new { id = architecture.ID }, ConvertToDto(architecture));
        }

        // DELETE: api/ComponentsMakroArchitecture/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComponentsMacroArchitectureDto>> DeleteComponentsMakroArchitecture(int id)
        {
            var architecture = await _architectures.FindAsync(id);
            if (architecture == null)
            {
                return NotFound();
            }

            _architectures.Remove(architecture);
            await _architectures.SaveChangesAsync();

            return ConvertToDto(architecture);
        }

        private bool ComponentsMakroArchitectureExists(int id)
        {
            return _architectures.Any(e => e.ID == id);
        }
    }
}
