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
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareDevLaborVolumeRangeController : ControllerBase<SoftwareDevLaborVolumeRange, SoftwareDevLaborVolumeRangeDto>
    {
        private readonly LVCContext _context;

        public SoftwareDevLaborVolumeRangeController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/SoftwareDevLaborVolumeRange
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwareDevLaborVolumeRangeDto>>> GetSoftwareDevLaborVolumeRanges()
        {
            var items = await RangesRequest().ToListAsync();
            var orderedItems = ConvertToDto(items)
                .OrderBy(m => m.LaborCode, CodeComparer.Instance)
                .ToArray();
            
            return orderedItems;
        }

        // GET: api/SoftwareDevLaborVolumeRange/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftwareDevLaborVolumeRangeDto>> GetSoftwareDevLaborVolumeRange(int id)
        {
            var softwareDevLaborVolumeRange = await RangesRequest()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (softwareDevLaborVolumeRange == null)
            {
                return NotFound();
            }

            return ConvertToDto(softwareDevLaborVolumeRange);
        }

        // GET: api/SoftwareDevLaborVolumeRange/GetByLabor/12
        [HttpGet("[action]/{laborId}")]
        public async Task<ActionResult<IEnumerable<SoftwareDevLaborVolumeRangeDto>>> GetByLabor(int laborId)
        {
            var items = await RangesRequest()
                .Where(m => m.LaborID == laborId)
                .ToListAsync();
            
            var orderedItems = ConvertToDto(items)
                .OrderBy(m => m.DevEnvName)
                .ToArray();
            
            return orderedItems;
        }

        private IQueryable<SoftwareDevLaborVolumeRange> RangesRequest()
        {
            return _context.SoftwareDevLaborVolumeRanges
                .Include(m => m.Labor)
                .Include(m => m.DevEnv)
                .AsNoTracking();
        }

        // PUT: api/SoftwareDevLaborVolumeRange/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftwareDevLaborVolumeRange(int id, SoftwareDevLaborVolumeRangeDto softwareDevLaborVolumeRangeDto)
        {
            if (id != softwareDevLaborVolumeRangeDto.ID)
            {
                return BadRequest();
            }

            var softwareDevLaborVolumeRange = ConvertToSource(softwareDevLaborVolumeRangeDto);
            _context.Entry(softwareDevLaborVolumeRange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareDevLaborVolumeRangeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/SoftwareDevLaborVolumeRange
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SoftwareDevLaborVolumeRange>> PostSoftwareDevLaborVolumeRange(SoftwareDevLaborVolumeRangeDto softwareDevLaborVolumeRangeDto)
        {
            var softwareDevLaborVolumeRange = ConvertToSource(softwareDevLaborVolumeRangeDto);
            _context.SoftwareDevLaborVolumeRanges.Add(softwareDevLaborVolumeRange);
            await _context.SaveChangesAsync();

            softwareDevLaborVolumeRange = await RangesRequest().FirstOrDefaultAsync(m => m.ID == softwareDevLaborVolumeRange.ID);

            return CreatedAtAction("GetSoftwareDevLaborVolumeRange", new { id = softwareDevLaborVolumeRange.ID }, ConvertToDto(softwareDevLaborVolumeRange));
        }

        // DELETE: api/SoftwareDevLaborVolumeRange/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SoftwareDevLaborVolumeRangeDto>> DeleteSoftwareDevLaborVolumeRange(int id)
        {
            var softwareDevLaborVolumeRange = await _context.SoftwareDevLaborVolumeRanges.FindAsync(id);
            if (softwareDevLaborVolumeRange == null)
            {
                return NotFound();
            }

            _context.SoftwareDevLaborVolumeRanges.Remove(softwareDevLaborVolumeRange);
            await _context.SaveChangesAsync();

            return ConvertToDto(softwareDevLaborVolumeRange);
        }

        private bool SoftwareDevLaborVolumeRangeExists(int id)
        {
            return _context.SoftwareDevLaborVolumeRanges.Any(e => e.ID == id);
        }
    }
}
