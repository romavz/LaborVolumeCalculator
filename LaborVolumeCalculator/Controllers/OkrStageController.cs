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
    public class OkrStageController : ControllerBase
    {
        private readonly LVCContext _context;

        public OkrStageController(LVCContext context)
        {
            _context = context;
        }

        // GET: api/OkrStage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OkrStage>>> GetOkrStages()
        {
            return await _context.OkrStages.ToListAsync();
        }

        // GET: api/OkrStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OkrStage>> GetOkrStage(int id)
        {
            var okrStageReg = await _context.OkrStages.FindAsync(id);

            if (okrStageReg == null)
            {
                return NotFound();
            }

            return okrStageReg;
        }

        // POST: api/OkrStage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OkrStage>> PostOkrStage(OkrStage okrStageReg)
        {
            _context.OkrStages.Add(okrStageReg);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetOkrStage", new { id = okrStageReg.ID }, okrStageReg);
        }

        // DELETE: api/OkrStage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OkrStage>> DeleteOkrStage(int id)
        {
            var okrStageReg = await _context.OkrStages.FindAsync(id);
            if (okrStageReg == null)
            {
                return NotFound();
            }

            _context.OkrStages.Remove(okrStageReg);
            await _context.SaveChangesAsync();

            return okrStageReg;
        }

        private bool OkrStageExists(int id)
        {
            return _context.OkrStages.Any(e => e.ID == id);
        }
    }
}
