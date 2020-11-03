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
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbDevLaborController : ControllerBase<DbDevLabor, DevelopmentLaborDto>
    {
        private readonly IRepository<DbDevLabor> _labors;

        public DbDevLaborController(IRepository<DbDevLabor> labors, IMapper mapper) : base(mapper)
        {
            _labors = labors;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevelopmentLaborDto>>> GetDbDevLabors()
        {
            var items = await _labors.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.LaborCategory.Number)
                .ThenBy(m => m.Code)
                .ToList();

            return itemsDto;
        }

        // GET: api/DbDevLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DevelopmentLaborDto>> GetDbDevLabor(int id)
        {
            var dbDevLabor = await GetLaborByIdAsync(id);

            if (dbDevLabor == null)
            {
                return NotFound();
            }

            return ConvertToDto(dbDevLabor);
        }
        
        private Task<DbDevLabor> GetLaborByIdAsync(int id)
        {
            var dbDevLabor = _labors.WithIncludes.FirstOrDefaultAsync(m => m.ID == id);
            return dbDevLabor;
        }

        // PUT: api/DbDevLabor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<DevelopmentLaborDto>> PutDbDevLabor(int id, DevelopmentLaborChangeDto dbDevLaborDto)
        {
            if (id != dbDevLaborDto.ID)
            {
                return BadRequest();
            }

            var dbDevLabor = ConvertToSource(dbDevLaborDto);
            _labors.Update(dbDevLabor);

            try
            {
                await _labors.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbDevLaborExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            dbDevLabor = await GetLaborByIdAsync(dbDevLabor.ID);
            return Ok(ConvertToDto(dbDevLabor));
        }

        // POST: api/DbDevLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DevelopmentLaborDto>> PostDbDevLabor(DevelopmentLaborCreateDto dbDevLaborDto)
        {
            var dbDevLabor = ConvertToSource(dbDevLaborDto);
            _labors.Add(dbDevLabor);
            await _labors.SaveChangesAsync();

            dbDevLabor = await GetLaborByIdAsync(dbDevLabor.ID);
            return CreatedAtAction("GetDbDevLabor", new { id = dbDevLabor.ID }, ConvertToDto(dbDevLabor));
        }

        // DELETE: api/DbDevLabor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DevelopmentLaborDto>> DeleteDbDevLabor(int id)
        {
            var dbDevLabor = await _labors.FirstOrDefaultAsync(m => m.ID == id);
            if (dbDevLabor == null)
            {
                return NotFound();
            }

            _labors.Remove(dbDevLabor);
            await _labors.SaveChangesAsync();

            dbDevLabor = await GetLaborByIdAsync(dbDevLabor.ID);
            return ConvertToDto(dbDevLabor);
        }

        private bool DbDevLaborExists(int id)
        {
            return _labors.Any(e => e.ID == id);
        }
    }
}
