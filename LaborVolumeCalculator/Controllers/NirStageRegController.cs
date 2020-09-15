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
    public class NirStageRegController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirStageRegController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/NirStageReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageRegDto>>> GetNirStageRegs()
        {
            var regs = await _context.NirStageRegs
                .Include(r => r.Stage)
                .ToListAsync();

            var result = regs.Select(item => ConvertToDto(item))
                .OrderBy(item => item.Stage.Name)
                .ToList();

            return result;
        }

        // GET: api/NirStageReg/GetNirStageRegs/5
        [HttpGet("[action]/{nirId}")]
        public async Task<ActionResult<IEnumerable<NirStageRegDto>>> GetNirStageRegs(int nirId)
        {
            var nirStageRegs = await _context.NirStageRegs
                .Include(r => r.Stage)
                .Where(r => r.NirID == nirId)
                .AsNoTracking()
                .ToListAsync();

            if (nirStageRegs == null)
            {
                return NotFound();
            }
            
            var result = _mapper.Map<IList<NirStageReg>, IEnumerable<NirStageRegDto>>(nirStageRegs).ToList();

            return result;
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
            var nirStageReg = ConvertFromDto(itemDto);
            _context.NirStageRegs.Add(nirStageReg);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            itemDto = ConvertToDto(nirStageReg);

            return CreatedAtAction("GetNirStageReg", new { id = nirStageReg.ID }, itemDto);
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

        private NirStageRegDto ConvertToDto(NirStageReg item)
        {
            return _mapper.Map<NirStageRegDto>(item);
        }

        private NirStageReg ConvertFromDto(NirStageRegDto item)
        {
            return _mapper.Map<NirStageReg>(item);
        }
    }
}
