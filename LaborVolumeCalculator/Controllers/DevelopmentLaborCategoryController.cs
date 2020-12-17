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
    public class DevelopmentLaborCategoryController : ControllerBase<DevelopmentLaborCategory, DevelopmentLaborCategoryFullDto>
    {
        private readonly IRepository<DevelopmentLaborCategory> _laborCategories;

        public DevelopmentLaborCategoryController(IRepository<DevelopmentLaborCategory> context, IMapper mapper) : base(mapper)
        {
            _laborCategories = context;
        }

        // GET: api/DevelopmentLaborCategory
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DevelopmentLaborCategoryFullDto>>> GetLaborCategories()
        {
            var items = await _laborCategories.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Number)
                .ToList();
            
            return itemsDto;
        }

        // GET: api/DevelopmentLaborCategory/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DevelopmentLaborCategoryFullDto>> GetDevelopmentLaborCategory(int id)
        {
            var developmentLaborCategory = await _laborCategories.WithIncludes.FindAsync(id);

            if (developmentLaborCategory == null)
            {
                return NotFound();
            }

            return ConvertToDto(developmentLaborCategory);
        }

        // PUT: api/DevelopmentLaborCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutDevelopmentLaborCategory(int id, DevelopmentLaborCategoryDto developmentLaborCategoryDto)
        {
            var developmentLaborCategory = ConvertToSource(developmentLaborCategoryDto);

            if (id != developmentLaborCategory.ID)
            {
                return BadRequest();
            }

            _laborCategories.Update(developmentLaborCategory);

            try
            {
                await _laborCategories.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevelopmentLaborCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            developmentLaborCategory = await _laborCategories.WithIncludes.FindAsync(developmentLaborCategory.ID);
            return Ok(ConvertToDto(developmentLaborCategory));
        }

        // POST: api/DevelopmentLaborCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<DevelopmentLaborCategoryFullDto>> PostDevelopmentLaborCategory(DevelopmentLaborCategoryCreateDto developmentLaborCategoryDto)
        {
            var developmentLaborCategory = ConvertToSource(developmentLaborCategoryDto);
            _laborCategories.Add(developmentLaborCategory);
            await _laborCategories.SaveChangesAsync();
            
            developmentLaborCategory = await _laborCategories.WithIncludes.FindAsync(developmentLaborCategory.ID);
            return CreatedAtAction("GetDevelopmentLaborCategory", new { id = developmentLaborCategory.ID }, ConvertToDto(developmentLaborCategory));
        }

        // DELETE: api/DevelopmentLaborCategory/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DevelopmentLaborCategoryFullDto>> DeleteDevelopmentLaborCategory(int id)
        {
            var developmentLaborCategory = await _laborCategories.WithIncludes.FindAsync(id);
            if (developmentLaborCategory == null)
            {
                return NotFound();
            }

            _laborCategories.Remove(developmentLaborCategory);
            await _laborCategories.SaveChangesAsync();

            return ConvertToDto(developmentLaborCategory);
        }

        private bool DevelopmentLaborCategoryExists(int id)
        {
            return _laborCategories.Any(e => e.ID == id);
        }
    }
}
