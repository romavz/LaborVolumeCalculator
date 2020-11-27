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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsInteractionArchitectureController : ControllerBase
    {
        private readonly IRepository<ComponentsInteractionArchitecture> _architectures;

        public ComponentsInteractionArchitectureController(IRepository<ComponentsInteractionArchitecture> context)
        {
            _architectures = context;
        }

        // GET: api/ComponentsInteractionArchitecture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentsInteractionArchitecture>>> GetComponentsInteractionArchitectures()
        {
            return await _architectures.ToListAsync();
        }

        // GET: api/ComponentsInteractionArchitecture/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentsInteractionArchitecture>> GetComponentsInteractionArchitecture(int id)
        {
            var componentsInteractionArchitecture = await _architectures.FindAsync(id);

            if (componentsInteractionArchitecture == null)
            {
                return NotFound();
            }

            return componentsInteractionArchitecture;
        }

        // PUT: api/ComponentsInteractionArchitecture/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentsInteractionArchitecture(int id, ComponentsInteractionArchitecture componentsInteractionArchitecture)
        {
            if (id != componentsInteractionArchitecture.ID)
            {
                return BadRequest();
            }

            _architectures.Update(componentsInteractionArchitecture);

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

            return NoContent();
        }

        // POST: api/ComponentsInteractionArchitecture
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComponentsInteractionArchitecture>> PostComponentsInteractionArchitecture(ComponentsInteractionArchitecture componentsInteractionArchitecture)
        {
            _architectures.Add(componentsInteractionArchitecture);
            await _architectures.SaveChangesAsync();

            return CreatedAtAction("GetComponentsInteractionArchitecture", new { id = componentsInteractionArchitecture.ID }, componentsInteractionArchitecture);
        }

        // DELETE: api/ComponentsInteractionArchitecture/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComponentsInteractionArchitecture>> DeleteComponentsInteractionArchitecture(int id)
        {
            var componentsInteractionArchitecture = await _architectures.FindAsync(id);
            if (componentsInteractionArchitecture == null)
            {
                return NotFound();
            }

            _architectures.Remove(componentsInteractionArchitecture);
            await _architectures.SaveChangesAsync();

            return componentsInteractionArchitecture;
        }

        private bool ComponentsInteractionArchitectureExists(int id)
        {
            return _architectures.Any(e => e.ID == id);
        }
    }
}
