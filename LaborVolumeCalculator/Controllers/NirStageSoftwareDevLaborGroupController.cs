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
    public class NirStageSoftwareDevLaborGroupController : ControllerBase<NirStageSoftwareDevLaborGroup, StageSoftwareDevLaborGroupDto>
    {
        private readonly LVCContext _context;

        public NirStageSoftwareDevLaborGroupController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirStageSoftwareDevLaborGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StageSoftwareDevLaborGroupDto>>> GetNirStageSoftwareDevLaborGroups()
        {
            var items = await GroupsRequest().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/NirStageSoftwareDevLaborGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StageSoftwareDevLaborGroupDto>> GetNirStageSoftwareDevLaborGroup(int id)
        {
            var nirStageSoftwareDevLaborGroup = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirStageSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStageSoftwareDevLaborGroup);
        }

        private IQueryable<NirStageSoftwareDevLaborGroup> GroupsRequest()
        {
            return _context.NirStageSoftwareDevLaborGroups.Include(m => m.SoftwareDevLaborGroup).AsNoTracking();
        }

        // PUT: api/NirStageSoftwareDevLaborGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirStageSoftwareDevLaborGroup(int id, StageSoftwareDevLaborGroupChangeDto nirStageSoftwareDevLaborGroupDto)
        {
            if (id != nirStageSoftwareDevLaborGroupDto.ID)
            {
                return BadRequest();
            }

            var nirStageSoftwareDevLaborGroup = ConvertToSource(nirStageSoftwareDevLaborGroupDto);
            _context.Entry(nirStageSoftwareDevLaborGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirStageSoftwareDevLaborGroupExists(id))
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

        // POST: api/NirStageSoftwareDevLaborGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StageSoftwareDevLaborGroupDto>> PostNirStageSoftwareDevLaborGroup(StageSoftwareDevLaborGroupCreateDto nirStageSoftwareDevLaborGroupDto)
        {
            var nirStageSoftwareDevLaborGroup = ConvertToSource(nirStageSoftwareDevLaborGroupDto);
            _context.NirStageSoftwareDevLaborGroups.Add(nirStageSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            nirStageSoftwareDevLaborGroup = await GroupsRequest().FirstOrDefaultAsync(m => m.ID == nirStageSoftwareDevLaborGroup.ID);
            return CreatedAtAction("GetNirStageSoftwareDevLaborGroup", new { id = nirStageSoftwareDevLaborGroup.ID }, ConvertToDto(nirStageSoftwareDevLaborGroup));
        }

        // DELETE: api/NirStageSoftwareDevLaborGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StageSoftwareDevLaborGroupDto>> DeleteNirStageSoftwareDevLaborGroup(int id)
        {
            var nirStageSoftwareDevLaborGroup = await _context.NirStageSoftwareDevLaborGroups.FindAsync(id);
            if (nirStageSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            _context.NirStageSoftwareDevLaborGroups.Remove(nirStageSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirStageSoftwareDevLaborGroup);
        }

        private bool NirStageSoftwareDevLaborGroupExists(int id)
        {
            return _context.NirStageSoftwareDevLaborGroups.Any(e => e.ID == id);
        }
    }
}
