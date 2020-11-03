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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbEntityCountRangeController : ControllerBase<DbEntityCountRange, DbEntityCountRangeDto>
    {
        private readonly IRepository<DbEntityCountRange> _ranges;

        public DbEntityCountRangeController(IRepository<DbEntityCountRange> context, IMapper mapper) : base(mapper)
        {
            _ranges = context;
        }

        // GET: api/DbEntityCountRange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbEntityCountRangeDto>>> GetDbEntityCountRanges()
        {
            var items = await _ranges.GetAll().ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Name)
                .ToList();
            return itemsDto;
        }

        // GET: api/DbEntityCountRange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbEntityCountRangeDto>> GetDbEntityCountRange(int id)
        {
            var dbEntityCountRange = await _ranges.FirstOrDefaultAsync(m => m.ID == id);

            if (dbEntityCountRange == null)
            {
                return NotFound();
            }

            return ConvertToDto(dbEntityCountRange);
        }

        // PUT: api/DbEntityCountRange/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<DbEntityCountRangeDto>> PutDbEntityCountRange(int id, DbEntityCountRange dbEntityCountRange)
        {
            if (id != dbEntityCountRange.ID)
            {
                return BadRequest();
            }

            _ranges.Update(dbEntityCountRange);

            try
            {
                await _ranges.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbEntityCountRangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ConvertToDto(dbEntityCountRange));
        }

        // POST: api/DbEntityCountRange
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DbEntityCountRangeDto>> PostDbEntityCountRange(DbEntityCountRangeCreateDto dbEntityCountRangeDto)
        {
            var dbEntityCountRange = ConvertToSource(dbEntityCountRangeDto);
            _ranges.Add(dbEntityCountRange);
            await _ranges.SaveChangesAsync();

            return CreatedAtAction("GetDbEntityCountRange", new { id = dbEntityCountRange.ID }, ConvertToDto(dbEntityCountRange));
        }

        // DELETE: api/DbEntityCountRange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbEntityCountRangeDto>> DeleteDbEntityCountRange(int id)
        {
            var dbEntityCountRange = await _ranges.FirstOrDefaultAsync(m => m.ID == id);
            if (dbEntityCountRange == null)
            {
                return NotFound();
            }

            _ranges.Remove(dbEntityCountRange);
            await _ranges.SaveChangesAsync();

            return ConvertToDto(dbEntityCountRange);
        }

        private bool DbEntityCountRangeExists(int id)
        {
            return _ranges.Any(e => e.ID == id);
        }
    }
}
