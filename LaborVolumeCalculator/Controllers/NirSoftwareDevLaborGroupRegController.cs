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
    public class NirSoftwareDevLaborGroupRegController : ControllerBase<NirSoftwareDevLaborGroupReg, NirSoftwareDevLaborGroupRegDto>
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborGroupRegController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborGroupReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborGroupRegDto>>> GetNirSoftwareDevLaborGroupRegs()
        {
            var items = await GroupsRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/NirSoftwareDevLaborGroupReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroupRegDto>> GetNirSoftwareDevLaborGroupReg(int id)
        {
            var nirSoftwareDevLaborGroupReg = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirSoftwareDevLaborGroupReg == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborGroupReg);
        }

        private IQueryable<NirSoftwareDevLaborGroupReg> GroupsRequest()
        {
            return _context.NirSoftwareDevLaborGroupRegs.Include(m => m.SoftwareDevLaborGroup).AsNoTracking();
        }

        // PUT: api/NirSoftwareDevLaborGroupReg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborGroupReg(int id, NirSoftwareDevLaborGroupRegDto nirSoftwareDevLaborGroupRegDto)
        {
            if (id != nirSoftwareDevLaborGroupRegDto.ID)
            {
                return BadRequest();
            }

            var nirSoftwareDevLaborGroupReg = ConvertToSource(nirSoftwareDevLaborGroupRegDto);
            _context.Entry(nirSoftwareDevLaborGroupReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborGroupRegExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/NirSoftwareDevLaborGroupReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirSoftwareDevLaborGroupRegDto>> PostNirSoftwareDevLaborGroupReg(NirSoftwareDevLaborGroupRegDto nirSoftwareDevLaborGroupRegDto)
        {
            var nirSoftwareDevLaborGroupReg = ConvertToSource(nirSoftwareDevLaborGroupRegDto);
            _context.NirSoftwareDevLaborGroupRegs.Add(nirSoftwareDevLaborGroupReg);
            await _context.SaveChangesAsync();

            nirSoftwareDevLaborGroupReg = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == nirSoftwareDevLaborGroupReg.ID);
            return CreatedAtAction("GetNirSoftwareDevLaborGroupReg", new { id = nirSoftwareDevLaborGroupReg.ID }, ConvertToDto(nirSoftwareDevLaborGroupReg));
        }

        // DELETE: api/NirSoftwareDevLaborGroupReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroupRegDto>> DeleteNirSoftwareDevLaborGroupReg(int id)
        {
            var nirSoftwareDevLaborGroupReg = await _context.NirSoftwareDevLaborGroupRegs.FindAsync(id);
            if (nirSoftwareDevLaborGroupReg == null)
            {
                return NotFound();
            }

            _context.NirSoftwareDevLaborGroupRegs.Remove(nirSoftwareDevLaborGroupReg);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborGroupReg);
        }

        private bool NirSoftwareDevLaborGroupRegExists(int id)
        {
            return _context.NirSoftwareDevLaborGroupRegs.Any(e => e.ID == id);
        }
    }
}
