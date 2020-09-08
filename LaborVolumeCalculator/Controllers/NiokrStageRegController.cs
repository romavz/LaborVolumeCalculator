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
    public class NiokrStageRegController : ControllerBase
    {
        private readonly LVCContext _context;

        public NiokrStageRegController(LVCContext context)
        {
            _context = context;
        }

        // GET: api/NiokrStageReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NiokrStageReg>>> GetNiokrStageRegs()
        {
            return await _context.NiokrStageRegs.ToListAsync();
        }

        // GET: api/NiokrStageReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NiokrStageReg>> GetNiokrStageReg(int id)
        {
            var niokrStageReg = await _context.NiokrStageRegs.FindAsync(id);

            if (niokrStageReg == null)
            {
                return NotFound();
            }

            return niokrStageReg;
        }
        
        // POST: api/NiokrStageReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NiokrStageReg>> PostNiokrStageReg(NiokrStageReg niokrStageReg)
        {
            _context.NiokrStageRegs.Add(niokrStageReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNiokrStageReg", new { id = niokrStageReg.ID }, niokrStageReg);
        }

        // DELETE: api/NiokrStageReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NiokrStageReg>> DeleteNiokrStageReg(int id)
        {
            var niokrStageReg = await _context.NiokrStageRegs.FindAsync(id);
            if (niokrStageReg == null)
            {
                return NotFound();
            }

            _context.NiokrStageRegs.Remove(niokrStageReg);
            await _context.SaveChangesAsync();

            return niokrStageReg;
        }

        private bool NiokrStageRegExists(int id)
        {
            return _context.NiokrStageRegs.Any(e => e.ID == id);
        }
    }
}
