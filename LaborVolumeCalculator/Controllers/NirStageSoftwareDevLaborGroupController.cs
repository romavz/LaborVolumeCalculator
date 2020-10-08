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
    public class NirStageSoftwareDevLaborGroupController : ControllerBase<NirStageSoftwareDevLaborGroup, NirStageSoftwareDevLaborGroupDto>
    {
        private readonly LVCContext _context;

        public NirStageSoftwareDevLaborGroupController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborGroupReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageSoftwareDevLaborGroupDto>>> GetNirSoftwareDevLaborGroupRegs()
        {
            var items = await GroupsRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/NirSoftwareDevLaborGroupReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageSoftwareDevLaborGroupDto>> GetNirSoftwareDevLaborGroupReg(int id)
        {
            var nirSoftwareDevLaborGroupReg = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirSoftwareDevLaborGroupReg == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborGroupReg);
        }

        private IQueryable<NirStageSoftwareDevLaborGroup> GroupsRequest()
        {
            return _context.NirStageSoftwareDevLaborGroups.Include(m => m.SoftwareDevLaborGroup).AsNoTracking();
        }

        // PUT: api/NirSoftwareDevLaborGroupReg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborGroupReg(int id, NirStageSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupRegDto)
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
        public async Task<ActionResult<NirStageSoftwareDevLaborGroupDto>> PostNirSoftwareDevLaborGroupReg(NirStageSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupRegDto)
        {
            var nirSoftwareDevLaborGroupReg = ConvertToSource(nirSoftwareDevLaborGroupRegDto);
            _context.NirStageSoftwareDevLaborGroups.Add(nirSoftwareDevLaborGroupReg);
            await _context.SaveChangesAsync();

            nirSoftwareDevLaborGroupReg = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == nirSoftwareDevLaborGroupReg.ID);
            return CreatedAtAction("GetNirSoftwareDevLaborGroupReg", new { id = nirSoftwareDevLaborGroupReg.ID }, ConvertToDto(nirSoftwareDevLaborGroupReg));
        }

        // DELETE: api/NirSoftwareDevLaborGroupReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageSoftwareDevLaborGroupDto>> DeleteNirSoftwareDevLaborGroupReg(int id)
        {
            var nirSoftwareDevLaborGroupReg = await _context.NirStageSoftwareDevLaborGroups.FindAsync(id);
            if (nirSoftwareDevLaborGroupReg == null)
            {
                return NotFound();
            }

            _context.NirStageSoftwareDevLaborGroups.Remove(nirSoftwareDevLaborGroupReg);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborGroupReg);
        }

        private bool NirSoftwareDevLaborGroupRegExists(int id)
        {
            return _context.NirStageSoftwareDevLaborGroups.Any(e => e.ID == id);
        }
    }
}
