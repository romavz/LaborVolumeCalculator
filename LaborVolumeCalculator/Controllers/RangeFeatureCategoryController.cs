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
    public class RangeFeatureCategoryController : ControllerBase<RangeFeatureCategory, RangeFeatureCategoryDto>
    {
        private readonly IRepository<RangeFeatureCategory> _rangeFeatureCategories;

        public RangeFeatureCategoryController(IRepository<RangeFeatureCategory> context, IMapper mapper) : base(mapper)
        {
            _rangeFeatureCategories = context;
        }

        // GET: api/RangeFeatureCategory
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RangeFeatureCategoryDto>>> GetRangeFeatureCategories()
        {
            var items = await _rangeFeatureCategories.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Name)
                .ToList();

            return itemsDto;
        }

        // GET: api/RangeFeatureCategory/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RangeFeatureCategoryDto>> GetRangeFeatureCategory(int id)
        {
            var rangeFeatureCategory = await _rangeFeatureCategories.WithIncludes.FindAsync(id);

            if (rangeFeatureCategory == null)
            {
                return NotFound();
            }

            return ConvertToDto(rangeFeatureCategory);
        }

        // PUT: api/RangeFeatureCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<RangeFeatureCategoryDto>> PutRangeFeatureCategory(int id, RangeFeatureCategoryChangeDto rangeFeatureCategoryDto)
        {
            if (id != rangeFeatureCategoryDto.ID)
            {
                return BadRequest();
            }

            var rangeFeatureCategory = ConvertToSource(rangeFeatureCategoryDto);
            _rangeFeatureCategories.Update(rangeFeatureCategory);

            try
            {
                await _rangeFeatureCategories.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangeFeatureCategoryExists(id))
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

        // POST: api/RangeFeatureCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<RangeFeatureCategoryDto>> PostRangeFeatureCategory(RangeFeatureCategoryCreateDto rangeFeatureCategoryDto)
        {
            var rangeFeatureCategory = ConvertToSource(rangeFeatureCategoryDto);
            _rangeFeatureCategories.Add(rangeFeatureCategory);
            await _rangeFeatureCategories.SaveChangesAsync();

            rangeFeatureCategory = await _rangeFeatureCategories.WithIncludes.FindAsync(rangeFeatureCategory.ID);
            return CreatedAtAction("GetRangeFeatureCategory", new { id = rangeFeatureCategory.ID }, ConvertToDto(rangeFeatureCategory));
        }

        // DELETE: api/RangeFeatureCategory/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RangeFeatureCategoryDto>> DeleteRangeFeatureCategory(int id)
        {
            var rangeFeatureCategory = await _rangeFeatureCategories.WithIncludes.FindAsync(id);
            if (rangeFeatureCategory == null)
            {
                return NotFound();
            }

            _rangeFeatureCategories.Remove(rangeFeatureCategory);
            await _rangeFeatureCategories.SaveChangesAsync();

            return ConvertToDto(rangeFeatureCategory);
        }

        private bool RangeFeatureCategoryExists(int id)
        {
            return _rangeFeatureCategories.Any(e => e.ID == id);
        }
    }
}
