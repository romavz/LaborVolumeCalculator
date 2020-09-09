using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Utils;
using LaborVolumeCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborVolumeRegController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirLaborVolumeRegController(LVCContext context)
        {
            this._context = context;
        }


        // GET: api/NirLaborVolumeRegController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeReg>>> GetNirLaborVolumeRegs()
        {
            return await _context.NirLaborVolumeRegs.ToListAsync();
        }

        // GET: api/NirLaborVolumeRegController/5
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

        //GET api/NirLaborVolumeReg/GetNirLaborsRegs? nirID = 3 & StageID = 1
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NirLaborVolumeReg>>> GetNirLaborsRegs(int nirID, int StageID)
        {
            var laborVolumes = await _context.NirLaborVolumeRegs
                .AsNoTracking()
                .Include(m => m.Labor)
                .Where(m =>
                    m.NirID == nirID
                    && m.StageID == StageID)
                .ToListAsync();

            return await Task.Run(() => laborVolumes.OrderBy(m => m.Labor.Code, CodeComparer.Instance).ToArray());
        }

        // PUT: api/NirLaborVolumeRegController/5
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

        // POST: api/NirLaborVolumeRegController
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirLaborVolumeReg>> PostNirLaborVolumeReg(NirLaborVolumeReg nirLaborVolumeReg)
        {
            _context.NirLaborVolumeRegs.Add(nirLaborVolumeReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirLaborVolumeReg", new { id = nirLaborVolumeReg.ID }, nirLaborVolumeReg);
        }

        // DELETE: api/NirLaborVolumeRegController/5
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
    
        
        // [HttpPost("[action]")]
        // public async Task<ActionResult<IEnumerable<LaborVolumeReg>>> AddTypycalLabors(int niokrID, int niokrStageID)
        // {
            

        //     // CreatedAtAction("GetByNiokrStage", new { niokrID, niokrStageID }, result )
        // }

    }
}
