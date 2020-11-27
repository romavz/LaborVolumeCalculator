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
    public class ComponentsInteractionArchitectureController : ControllerBase<ComponentsInteractionArchitecture, ComponentsInteractionArchitectureDto>
    {
        private readonly IRepository<ComponentsInteractionArchitecture> _architectures;

        public ComponentsInteractionArchitectureController(IRepository<ComponentsInteractionArchitecture> architectures, IMapper mapper) : base(mapper)
        {
            _architectures = architectures;
        }

        // GET: api/ComponentsInteractionArchitecture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentsInteractionArchitectureDto>>> GetComponentsInteractionArchitectures()
        {
            var items = await _architectures.ToListAsync();
            return ConvertToDto(items)
                    .OrderBy(m => m.Name)
                    .ToList();
        }

        // GET: api/ComponentsInteractionArchitecture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentsInteractionArchitectureDto>> GetComponentsInteractionArchitecture(int id)
        {
            var componentsInteractionArchitecture = await _architectures.FindAsync(id);

            if (componentsInteractionArchitecture == null)
            {
                return NotFound();
            }

            return ConvertToDto(componentsInteractionArchitecture);
        }

        // PUT: api/ComponentsInteractionArchitecture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ComponentsInteractionArchitectureDto>> PutComponentsInteractionArchitecture(int id, ComponentsInteractionArchitectureDto architectureDto)
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
                if (!ComponentsInteractionArchitectureExists(id))
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

        // POST: api/ComponentsInteractionArchitecture
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComponentsInteractionArchitectureDto>> PostComponentsInteractionArchitecture(ComponentsInteractionArchitectureCreateDto architectureDto)
        {
            var architecture = ConvertToSource(architectureDto);
            _architectures.Add(architecture);
            await _architectures.SaveChangesAsync();

            return CreatedAtAction("GetComponentsInteractionArchitecture", new { id = architecture.ID }, ConvertToDto(architecture));
        }

        // DELETE: api/ComponentsInteractionArchitecture/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComponentsInteractionArchitectureDto>> DeleteComponentsInteractionArchitecture(int id)
        {
            var componentsInteractionArchitecture = await _architectures.FindAsync(id);
            if (componentsInteractionArchitecture == null)
            {
                return NotFound();
            }

            _architectures.Remove(componentsInteractionArchitecture);
            await _architectures.SaveChangesAsync();

            return ConvertToDto(componentsInteractionArchitecture);
        }

        private bool ComponentsInteractionArchitectureExists(int id)
        {
            return _architectures.Any(e => e.ID == id);
        }
    }
}
