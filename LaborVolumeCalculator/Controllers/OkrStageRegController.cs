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
    public class OkrStageRegController : ControllerBase
    {
        private readonly LVCContext _context;

        public OkrStageRegController(LVCContext context)
        {
            _context = context;
        }

        // GET: api/OkrStageReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OkrStageReg>>> GetOkrStageRegs()
        {
            return await _context.OkrStageRegs.ToListAsync();
        }

        // GET: api/OkrStageReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OkrStageReg>> GetOkrStageReg(int id)
        {
            var okrStageReg = await _context.OkrStageRegs.FindAsync(id);

            if (okrStageReg == null)
            {
                return NotFound();
            }

            return okrStageReg;
        }

        // POST: api/OkrStageReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OkrStageReg>> PostOkrStageReg(OkrStageReg okrStageReg)
        {
            _context.OkrStageRegs.Add(okrStageReg);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetOkrStageReg", new { id = okrStageReg.ID }, okrStageReg);
        }

        // DELETE: api/OkrStageReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OkrStageReg>> DeleteOkrStageReg(int id)
        {
            var okrStageReg = await _context.OkrStageRegs.FindAsync(id);
            if (okrStageReg == null)
            {
                return NotFound();
            }

            _context.OkrStageRegs.Remove(okrStageReg);
            await _context.SaveChangesAsync();

            return okrStageReg;
        }

        private bool OkrStageRegExists(int id)
        {
            return _context.OkrStageRegs.Any(e => e.ID == id);
        }
    }
}
