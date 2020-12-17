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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirSoftwareDevLaborGroupController : ControllerBase<NirSoftwareDevLaborGroup, NirSoftwareDevLaborGroupDto>
    {
        private readonly IRepository<NirSoftwareDevLaborGroup> _groups;

        public NirSoftwareDevLaborGroupController(IRepository<NirSoftwareDevLaborGroup> groups, IMapper mapper) : base(mapper)
        {
            _groups = groups;
        }

        // GET: api/NirSoftwareDevLaborGroup
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborGroupDto>>> GetNirSoftwareDevLaborGroups()
        {
            var groups = await _groups.ToListAsync();
            var result = ConvertToDto(groups)
                .OrderBy(m => m.Code, CodeComparer.Instance).ToArray();
            
            return result;
        }

        // GET: api/NirSoftwareDevLaborGroup/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> GetNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _groups.FirstOrDefaultAsync(m => m.ID == id);

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutNirSoftwareDevLaborGroup(int id, NirSoftwareDevLaborGroupDto nirSoftwareDevLaborGroupDto)
        {
            if (id != nirSoftwareDevLaborGroupDto.ID)
            {
                return BadRequest();
            }

            var nirSoftwareDevLaborGroup = ConvertToSource(nirSoftwareDevLaborGroupDto);
            _groups.Update(nirSoftwareDevLaborGroup);

            try
            {
                await _groups.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return Ok();
        }

        // POST: api/NirSoftwareDevLaborGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> PostNirSoftwareDevLaborGroup(NirSoftwareDevLaborGroupCreateDto nirSoftwareDevLaborGroupDto)
        {
            var nirSoftwareDevLaborGroup = base.ConvertToSource(nirSoftwareDevLaborGroupDto);
            
            _groups.Add(nirSoftwareDevLaborGroup);
            await _groups.SaveChangesAsync();

            return CreatedAtAction("GetNirSoftwareDevLaborGroup", new { id = nirSoftwareDevLaborGroup.ID }, ConvertToDto(nirSoftwareDevLaborGroup));
        }

        // DELETE: api/NirSoftwareDevLaborGroup/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NirSoftwareDevLaborGroupDto>> DeleteNirSoftwareDevLaborGroup(int id)
        {
            var nirSoftwareDevLaborGroup = await _groups.FindAsync(id);
            if (nirSoftwareDevLaborGroup == null)
            {
                return NotFound();
            }

            _groups.Remove(nirSoftwareDevLaborGroup);
            await _groups.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborGroup);
        }

        private bool NirSoftwareDevLaborGroupExists(int id)
        {
            return _groups.Any(e => e.ID == id);
        }
    }
}
