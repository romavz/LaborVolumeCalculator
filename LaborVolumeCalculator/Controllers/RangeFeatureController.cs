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
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Repositories.Extentions;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangeFeatureController : ControllerBase<RangeFeature, RangeFeatureDto>
    {
        private readonly IRepository<RangeFeature> _rangeFeatures;

        public RangeFeatureController(IRepository<RangeFeature> rangeFeatures, IMapper mapper) : base(mapper)
        {
            _rangeFeatures = rangeFeatures;
        }

        // GET: api/RangeFeature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangeFeatureDto>>> GetRangeFeatures()
        {
            var items = await _rangeFeatures
                .WithIncludes
                .ToListAsync();
            
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.RangeFeatureCategory.Name)
                .ThenBy(m => m.Name)
                .ToList();
            
            return itemsDto;
        }

        // GET: api/RangeFeature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RangeFeatureDto>> GetRangeFeature(int id)
        {
            var rangeFeature = await _rangeFeatures.WithIncludes.FindAsync(id);

            if (rangeFeature == null)
            {
                return NotFound();
            }

            return ConvertToDto(rangeFeature);
        }

        // PUT: api/RangeFeature/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangeFeature(int id, RangeFeatureChangeDto rangeFeatureDto)
        {
            if (id != rangeFeatureDto.ID)
            {
                return BadRequest();
            }

            var rangeFeature = ConvertToSource(rangeFeatureDto);
            _rangeFeatures.Update(rangeFeature);

            try
            {
                await _rangeFeatures.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangeFeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            rangeFeature = await _rangeFeatures.WithIncludes.FindAsync(rangeFeature.ID);
            return Ok(ConvertToDto(rangeFeature));
        }

        // POST: api/RangeFeature
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RangeFeature>> PostRangeFeature(RangeFeatureCreateDto rangeFeatureDto)
        {
            var rangeFeature = ConvertToSource(rangeFeatureDto);
            _rangeFeatures.Add(rangeFeature);
            await _rangeFeatures.SaveChangesAsync();

            rangeFeature = await _rangeFeatures.WithIncludes.FindAsync(rangeFeature.ID);
            return CreatedAtAction("GetRangeFeature", new { id = rangeFeature.ID }, ConvertToDto(rangeFeature));
        }

        // DELETE: api/RangeFeature/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RangeFeatureDto>> DeleteRangeFeature(int id)
        {
            var rangeFeature = await _rangeFeatures.WithIncludes.FindAsync(id);
            if (rangeFeature == null)
            {
                return NotFound();
            }

            _rangeFeatures.Remove(rangeFeature);
            await _rangeFeatures.SaveChangesAsync();

            return ConvertToDto(rangeFeature);
        }

        private bool RangeFeatureExists(int id)
        {
            return _rangeFeatures.Any(e => e.ID == id);
        }
    }
}
