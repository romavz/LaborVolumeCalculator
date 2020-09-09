using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirSoftwareDevLaborGroupController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborGroupController(LVCContext context)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborGroup>>> GetNirSoftwareDevLaborGroups()
        {
            return await _context.NirSoftwareDevLaborGroups.ToListAsync();
        }

        // GET: api/NirSoftwareDevLaborGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroup>> GetNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _context.NirSoftwareDevLaborGroups.FindAsync(id);

            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            return nirSoftwareDevLaborGroup;
        }

        // PUT: api/NirSoftwareDevLaborGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborGroup(int id, NirSoftwareDevLaborGroup nirSoftwareDevLaborGroup)
        {
            if (id != nirSoftwareDevLaborGroup.ID)
            {
                return BadRequest();
            }

            _context.Entry(nirSoftwareDevLaborGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborGroupExists(id))
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

        // POST: api/NirSoftwareDevLaborGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirSoftwareDevLaborGroup>> PostNirSoftwareDevLaborGroup(NirSoftwareDevLaborGroup nirSoftwareDevLaborGroup)
        {
            _context.NirSoftwareDevLaborGroups.Add(nirSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirSoftwareDevLaborGroup", new { id = nirSoftwareDevLaborGroup.ID }, nirSoftwareDevLaborGroup);
        }

        // DELETE: api/NirSoftwareDevLaborGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroup>> DeleteNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _context.NirSoftwareDevLaborGroups.FindAsync(id);
            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            _context.NirSoftwareDevLaborGroups.Remove(nirSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            return nirSoftwareDevLaborGroup;
        }

        private bool NirSoftwareDevLaborGroupExists(int id)
        {
            return _context.NirSoftwareDevLaborGroups.Any(e => e.ID == id);
        }
    }
}
