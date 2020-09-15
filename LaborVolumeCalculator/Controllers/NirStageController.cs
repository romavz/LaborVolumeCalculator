using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirStageController : ControllerBase
    {
        private readonly LVCContext _context;
        private readonly IMapper _mapper;

        public NirStageController(LVCContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/NirStage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirStageDto>>> GetNirStages()
        {
            var stages = await _context.NirStages.ToListAsync();
            var stagesDto = ConvertToDto(stages);
            return stagesDto.ToList();
        }

        // GET: api/NirStage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirStageDto>> GetNirStage(int id)
        {
            var nirStage = await _context.NirStages.FindAsync(id);

            if (nirStage == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirStage);
        }

        // PUT: api/NirStage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirStage(int id, NirStageDto nirStageDto)
        {
            if (id != nirStageDto.ID)
            {
                return BadRequest();
            }

            var nirStage = ConvertFromDto(nirStageDto);
            _context.Entry(nirStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirStageExists(id))
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

        // POST: api/NirStage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirStage>> PostNirStage(NirStageDto nirStageDto)
        {
            var nirStage = ConvertFromDto(nirStageDto);
            _context.NirStages.Add(nirStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirStage", new { id = nirStage.ID }, ConvertToDto(nirStage));
        }

        // DELETE: api/NirStage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirStageDto>> DeleteNirStage(int id)
        {
            var nirStage = await _context.NirStages.FindAsync(id);
            if (nirStage == null)
            {
                return NotFound();
            }

            _context.NirStages.Remove(nirStage);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirStage);
        }

        private bool NirStageExists(int id)
        {
            return _context.NirStages.Any(e => e.ID == id);
        }

        private NirStageDto ConvertToDto(NirStage item)
        {
            return _mapper.Map<NirStageDto>(item);
        }

        private NirStage ConvertFromDto(NirStageDto item)
        {
            return _mapper.Map<NirStage>(item);
        }

        private IEnumerable<NirStageDto> ConvertToDto(IEnumerable<NirStage> laborVolumeRegs)
        {
            return _mapper.Map<IEnumerable<NirStage>, IEnumerable<NirStageDto>>(laborVolumeRegs);
        }
    }
}
