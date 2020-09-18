using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using AutoMapper;
using LaborVolumeCalculator.DTO;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirSoftwareDevLaborGroupController : ControllerBase<NirSoftwareDevLaborGroup, NirSoftwareDevLaborGroupDto>
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborGroupController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborGroupDto>>> GetNirSoftwareDevLaborGroups()
        {
            var groups = await GetGroupsQuery().ToListAsync();
            var result = ConvertToDto(groups)
                .OrderBy(m => m.Code, CodeComparer.Instance).ToArray();
            
            return result;
        }

        // GET: api/NirSoftwareDevLaborGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> GetNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await GetGroupsQuery().FirstOrDefaultAsync(m => m.ID == id);

            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborGroup);
        }

        private IQueryable<NirSoftwareDevLaborGroup> GetGroupsQuery()
        {
            return _context.NirSoftwareDevLaborGroups.AsNoTracking();
        }

        // PUT: api/NirSoftwareDevLaborGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborGroup(int id, NirSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupDto)
        {
            if (id != nirSoftwareDevLaborGroupDto.ID)
            {
                return BadRequest();
            }

            var nirSoftwareDevLaborGroup = ConvertToSource(nirSoftwareDevLaborGroupDto);
            _context.Entry(nirSoftwareDevLaborGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborGroupExists(id))
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

        // POST: api/NirSoftwareDevLaborGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> PostNirSoftwareDevLaborGroup(NirSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupDto)
        {
            var nirSoftwareDevLaborGroup = base.ConvertToSource(nirSoftwareDevLaborGroupDto);
            
            _context.NirSoftwareDevLaborGroups.Add(nirSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirSoftwareDevLaborGroup", new { id = nirSoftwareDevLaborGroup.ID }, ConvertToDto(nirSoftwareDevLaborGroup));
        }

        // DELETE: api/NirSoftwareDevLaborGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> DeleteNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _context.NirSoftwareDevLaborGroups.FindAsync(id);
            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            _context.NirSoftwareDevLaborGroups.Remove(nirSoftwareDevLaborGroup);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborGroup);
        }

        private bool NirSoftwareDevLaborGroupExists(int id)
        {
            return _context.NirSoftwareDevLaborGroups.Any(e => e.ID == id);
        }
    }
}
