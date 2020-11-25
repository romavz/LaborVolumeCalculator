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
    public class RangeFeatureCategoryController : ControllerBase<RangeFeatureCategory, RangeFeatureCategoryFullDto>
    {
        private readonly IRepository<RangeFeatureCategory> _rangeFeatureCategories;

        public RangeFeatureCategoryController(IRepository<RangeFeatureCategory> context, IMapper mapper) : base(mapper)
        {
            _rangeFeatureCategories = context;
        }

        // GET: api/RangeFeatureCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangeFeatureCategoryFullDto>>> GetRangeFeatureCategories()
        {
            var items = await _rangeFeatureCategories.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Name)
                .ToList();

            return itemsDto;
        }

        // GET: api/RangeFeatureCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RangeFeatureCategoryFullDto>> GetRangeFeatureCategory(int id)
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
        public async Task<ActionResult<RangeFeatureCategoryFullDto>> PutRangeFeatureCategory(int id, RangeFeatureCategoryDto rangeFeatureCategoryDto)
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
                    throw;
                }
            }

            rangeFeatureCategory = await _rangeFeatureCategories.WithIncludes.FindAsync(rangeFeatureCategory.ID);
            return Ok(ConvertToDto(rangeFeatureCategory));
        }

        // POST: api/RangeFeatureCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RangeFeatureCategoryFullDto>> PostRangeFeatureCategory(RangeFeatureCategoryFullCreateDto rangeFeatureCategoryDto)
        {
            var rangeFeatureCategory = ConvertToSource(rangeFeatureCategoryDto);
            _rangeFeatureCategories.Add(rangeFeatureCategory);
            await _rangeFeatureCategories.SaveChangesAsync();

            rangeFeatureCategory = await _rangeFeatureCategories.WithIncludes.FindAsync(rangeFeatureCategory.ID);
            return CreatedAtAction("GetRangeFeatureCategory", new { id = rangeFeatureCategory.ID }, ConvertToDto(rangeFeatureCategory));
        }

        // DELETE: api/RangeFeatureCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RangeFeatureCategoryFullDto>> DeleteRangeFeatureCategory(int id)
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