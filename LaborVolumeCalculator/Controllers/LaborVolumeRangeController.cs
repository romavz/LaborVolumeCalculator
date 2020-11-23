using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborVolumeRangeController : ControllerBase<LaborVolumeRange, LaborVolumeRangeDto>
    {
        private readonly IRepository<LaborVolumeRange> _laborVolumeRanges;

        public LaborVolumeRangeController(IRepository<LaborVolumeRange> laborVolumeRanges, IMapper mapper) : base(mapper)
        {
            _laborVolumeRanges = laborVolumeRanges;
        }

        // GET: api/LaborVolumeRange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaborVolumeRangeDto>>> GetLaborVolumeRanges()
        {
            var items = await _laborVolumeRanges
                .WithIncludes
                .ToListAsync();
            
            var itemsDto = ConvertToDto(items)
                .OrderBy(m =>m.Labor.Code, CodeComparer.Instance)
                .ToList();

            return itemsDto;
        }

        // GET: api/LaborVolumeRange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaborVolumeRangeDto>> GetLaborVolumeRange(int id)
        {
            var laborVolumeRange = await _laborVolumeRanges.WithIncludes.FindAsync(id);

            if (laborVolumeRange == null)
            {
                return NotFound();
            }

            return ConvertToDto(laborVolumeRange);
        }

        // PUT: api/LaborVolumeRange/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<LaborVolumeRangeDto>> PutLaborVolumeRange(int id, LaborVolumeRangeChangeDto laborVolumeRangeDto)
        {
            if (id != laborVolumeRangeDto.ID)
            {
                return BadRequest();
            }

            var laborVolumeRange = ConvertToSource(laborVolumeRangeDto);

            _laborVolumeRanges.Update(laborVolumeRange);

            try
            {
                await _laborVolumeRanges.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborVolumeRangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            laborVolumeRange = await _laborVolumeRanges.WithIncludes.FindAsync(laborVolumeRange.ID);

            return Ok(ConvertToDto(laborVolumeRange));
        }

        // POST: api/LaborVolumeRange
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LaborVolumeRange>> PostLaborVolumeRange(LaborVolumeRangeCreateDto laborVolumeRangeDto)
        {
            var laborVolumeRange = ConvertToSource(laborVolumeRangeDto);
            _laborVolumeRanges.Add(laborVolumeRange);
            await _laborVolumeRanges.SaveChangesAsync();

            laborVolumeRange = await _laborVolumeRanges.WithIncludes.FindAsync(laborVolumeRange.ID);
            return CreatedAtAction("GetLaborVolumeRange", new { id = laborVolumeRange.ID }, ConvertToDto(laborVolumeRange));
        }

        // DELETE: api/LaborVolumeRange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LaborVolumeRangeDto>> DeleteLaborVolumeRange(int id)
        {
            var laborVolumeRange = await _laborVolumeRanges.WithIncludes.FindAsync(id);
            if (laborVolumeRange == null)
            {
                return NotFound();
            }

            _laborVolumeRanges.Remove(laborVolumeRange);
            await _laborVolumeRanges.SaveChangesAsync();

            return ConvertToDto(laborVolumeRange);
        }

        private bool LaborVolumeRangeExists(int id)
        {
            return _laborVolumeRanges.Any(e => e.ID == id);
        }
    }
}
