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
    public class NirStageRegController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirStageRegController(LVCContext context)
        {
            _context = context;
        }

        // GET: api/NirStageReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageReg>>> GetNirStageRegs()
        {
            return await _context.NirStageRegs.ToListAsync();
        }

        // GET: api/NirStageReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageReg>> GetNirStageReg(int id)
        {
            var nirStageReg = await _context.NirStageRegs.FindAsync(id);

            if (nirStageReg == null)
            {
                return NotFound();
            }

            return nirStageReg;
        }

        // POST: api/NirStageReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStageReg>> PostNirStageReg(NirStageReg nirStageReg)
        {
            _context.NirStageRegs.Add(nirStageReg);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetNirStageReg", new { id = nirStageReg.ID }, nirStageReg);
        }

        // DELETE: api/NirStageReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageReg>> DeleteNirStageReg(int id)
        {
            var nirStageReg = await _context.NirStageRegs.FindAsync(id);
            if (nirStageReg == null)
            {
                return NotFound();
            }

            _context.NirStageRegs.Remove(nirStageReg);
            await _context.SaveChangesAsync();

            return nirStageReg;
        }

        private bool NirStageRegExists(int id)
        {
            return _context.NirStageRegs.Any(e => e.ID == id);
        }
    }
}
