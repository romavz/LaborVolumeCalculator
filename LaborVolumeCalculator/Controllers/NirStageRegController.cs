using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirStageRegController : ControllerBase<NirStageReg, NirStageRegDto>
    {
        private readonly LVCContext _context;

        public NirStageRegController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirStageReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageRegDto>>> GetNirStageRegs()
        {
            var regs = await GetRegsQuery().ToListAsync();

            var result = ConvertToDto(regs)
                .OrderBy(item => item.Name)
                .ToArray();

            return result;
        }

        // GET: api/NirStageReg/GetNirStageRegs/5
        [HttpGet("[action]/{nirId}")]
        public async Task<ActionResult<IEnumerable<NirStageRegDto>>> GetNirStageRegs(int nirId)
        {
            var nirStageRegs = await GetRegsQuery()
                .Where(r => r.NirID == nirId)
                .ToListAsync();

            if (nirStageRegs == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStageRegs);
        }

        private IQueryable<NirStageReg> GetRegsQuery()
        {
            return _context.NirStageRegs
                            .Include(r => r.Stage)
                            .AsNoTracking();
        }


        // GET: api/NirStageReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageRegDto>> GetNirStageReg(int id)
        {
            var nirStageReg = await _context.NirStageRegs.FindAsync(id);

            if (nirStageReg == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStageReg);
        }

        // POST: api/NirStageReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStageRegDto>> PostNirStageReg(NirStageRegDto itemDto)
        {
            var nirStageReg = ConvertToSource(itemDto);
            _context.NirStageRegs.Add(nirStageReg);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }            

            return CreatedAtAction("GetNirStageReg", new { id = nirStageReg.ID }, ConvertToDto(nirStageReg));
        }

        // DELETE: api/NirStageReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageRegDto>> DeleteNirStageReg(int id)
        {
            var nirStageReg = await _context.NirStageRegs.FindAsync(id);
            if (nirStageReg == null)
            {
                return NotFound();
            }

            _context.NirStageRegs.Remove(nirStageReg);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirStageReg);
        }

        private bool NirStageRegExists(int id)
        {
            return _context.NirStageRegs.Any(e => e.ID == id);
        }
    }
}
