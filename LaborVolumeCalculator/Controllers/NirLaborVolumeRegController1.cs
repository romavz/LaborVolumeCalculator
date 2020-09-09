using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborVolumeRegController1 : ControllerBase
    {
        private readonly LVCContext _context;

        public NirLaborVolumeRegController1(LVCContext context)
        {
            _context = context;
        }

        // GET: api/NirLaborVolumeRegController1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeReg>>> GetNirLaborVolumeRegs()
        {
            return await _context.NirLaborVolumeRegs.ToListAsync();
        }

        // GET: api/NirLaborVolumeRegController1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirLaborVolumeReg>> GetNirLaborVolumeReg(int id)
        {
            var nirLaborVolumeReg = await _context.NirLaborVolumeRegs.FindAsync(id);

            if (nirLaborVolumeReg == null)
            {
                return NotFound();
            }

            return nirLaborVolumeReg;
        }

        // PUT: api/NirLaborVolumeRegController1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirLaborVolumeReg(int id, NirLaborVolumeReg nirLaborVolumeReg)
        {
            if (id != nirLaborVolumeReg.ID)
            {
                return BadRequest();
            }

            _context.Entry(nirLaborVolumeReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborVolumeRegExists(id))
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

        // POST: api/NirLaborVolumeRegController1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirLaborVolumeReg>> PostNirLaborVolumeReg(NirLaborVolumeReg nirLaborVolumeReg)
        {
            _context.NirLaborVolumeRegs.Add(nirLaborVolumeReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirLaborVolumeReg", new { id = nirLaborVolumeReg.ID }, nirLaborVolumeReg);
        }

        // DELETE: api/NirLaborVolumeRegController1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirLaborVolumeReg>> DeleteNirLaborVolumeReg(int id)
        {
            var nirLaborVolumeReg = await _context.NirLaborVolumeRegs.FindAsync(id);
            if (nirLaborVolumeReg == null)
            {
                return NotFound();
            }

            _context.NirLaborVolumeRegs.Remove(nirLaborVolumeReg);
            await _context.SaveChangesAsync();

            return nirLaborVolumeReg;
        }

        private bool NirLaborVolumeRegExists(int id)
        {
            return _context.NirLaborVolumeRegs.Any(e => e.ID == id);
        }
    }
}
