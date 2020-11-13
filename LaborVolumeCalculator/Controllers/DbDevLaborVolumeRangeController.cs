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
using AutoMapper;
using LaborVolumeCalculator.DTO;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbDevLaborVolumeRangeController : ControllerBase<DbDevLaborVolumeRange, DbDevLaborVolumeRangeDto>
    {
        private readonly IRepository<DbDevLaborVolumeRange> _ranges;

        public DbDevLaborVolumeRangeController(IRepository<DbDevLaborVolumeRange> ranges, IMapper mapper) : base(mapper)
        {
            _ranges = ranges;
        }

        // GET: api/DbDevLaborVolumeRange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbDevLaborVolumeRangeDto>>> GetDbDevLaborVolumeRanges()
        {
            var items = await _ranges.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Labor.LaborCategory.Name)
                    .ThenBy(m => m.Labor.Code, CodeComparer.Instance)
                        .ThenBy(m => m.DbEntityCountRange.Name)
                .ToList();
            return itemsDto;
        }

        // GET: api/DbDevLaborVolumeRange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbDevLaborVolumeRangeDto>> GetDbDevLaborVolumeRange(int id)
        {
            var dbDevLaborVolumeRange = await GetRangeByIdAsync(id);

            if (dbDevLaborVolumeRange == null)
            {
                return NotFound();
            }

            return ConvertToDto(dbDevLaborVolumeRange);
        }

        // PUT: api/DbDevLaborVolumeRange/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<DbDevLaborVolumeRange>> PutDbDevLaborVolumeRange(int id, DbDevLaborVolumeRangeChangeDto dbDevLaborVolumeRangeDto)
        {
            if (id != dbDevLaborVolumeRangeDto.ID)
            {
                return BadRequest();
            }

            var dbDevLaborVolumeRange = ConvertToSource(dbDevLaborVolumeRangeDto);
            _ranges.Update(dbDevLaborVolumeRange);

            try
            {
                await _ranges.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbDevLaborVolumeRangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            dbDevLaborVolumeRange = await GetRangeByIdAsync(id);
            return Ok(ConvertToDto(dbDevLaborVolumeRange));
        }

        private Task<DbDevLaborVolumeRange> GetRangeByIdAsync(int id)
        {
            return _ranges.WithIncludes.FindAsync(id);
        }

        // POST: api/DbDevLaborVolumeRange
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DbDevLaborVolumeRangeDto>> PostDbDevLaborVolumeRange(DbDevLaborVolumeRangeCreateDto dbDevLaborVolumeRangeDto)
        {
            var dbDevLaborVolumeRange = ConvertToSource(dbDevLaborVolumeRangeDto);
            _ranges.Add(dbDevLaborVolumeRange);
            await _ranges.SaveChangesAsync();

            dbDevLaborVolumeRange = await GetRangeByIdAsync(dbDevLaborVolumeRange.ID);
            return CreatedAtAction("GetDbDevLaborVolumeRange", new { id = dbDevLaborVolumeRange.ID }, ConvertToDto(dbDevLaborVolumeRange));
        }

        // DELETE: api/DbDevLaborVolumeRange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbDevLaborVolumeRangeDto>> DeleteDbDevLaborVolumeRange(int id)
        {
            var dbDevLaborVolumeRange = await GetRangeByIdAsync(id);
            if (dbDevLaborVolumeRange == null)
            {
                return NotFound();
            }

            _ranges.Remove(dbDevLaborVolumeRange);
            await _ranges.SaveChangesAsync();

            return ConvertToDto(dbDevLaborVolumeRange);
        }

        private bool DbDevLaborVolumeRangeExists(int id)
        {
            return _ranges.Any(e => e.ID == id);
        }
    }
}
