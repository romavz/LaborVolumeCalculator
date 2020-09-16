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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirSoftwareDevLaborGroupController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirSoftwareDevLaborGroupController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/NirSoftwareDevLaborGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborGroupDto>>> GetNirSoftwareDevLaborGroups()
        {
            var groups = await _context.NirSoftwareDevLaborGroups.ToListAsync();
            IList<NirSoftwareDevLaborGroupDto> groupsDto = ConvertToDto(groups);
            return groupsDto.ToList();
        }

        // GET: api/NirSoftwareDevLaborGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> GetNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _context.NirSoftwareDevLaborGroups.FindAsync(id);

            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborGroup);
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

            var nirSoftwareDevLaborGroup = ConvertFromDto(nirSoftwareDevLaborGroupDto);
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
            var nirSoftwareDevLaborGroup = ConvertFromDto(nirSoftwareDevLaborGroupDto);
            
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

        private IList<NirSoftwareDevLaborGroupDto> ConvertToDto(List<NirSoftwareDevLaborGroup> groups)
        {
            return _mapper.Map<IList<NirSoftwareDevLaborGroup>, IList<NirSoftwareDevLaborGroupDto>>(groups);
        }

        private NirSoftwareDevLaborGroupDto ConvertToDto(NirSoftwareDevLaborGroup nirSoftwareDevLaborGroup)
        {
            return _mapper.Map<NirSoftwareDevLaborGroupDto>(nirSoftwareDevLaborGroup);
        }

        private NirSoftwareDevLaborGroup ConvertFromDto(NirSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupDto)
        {
            return _mapper.Map<NirSoftwareDevLaborGroupDto, NirSoftwareDevLaborGroup>(nirSoftwareDevLaborGroupDto);
        }
    }
}
