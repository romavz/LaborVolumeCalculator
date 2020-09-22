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
    public class SoftwareDevLaborController : ControllerBase<SoftwareDevLabor, DevelopmentLaborDto>
    {
        private readonly LVCContext _context;

        public SoftwareDevLaborController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/SoftwareDevLabor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevelopmentLaborDto>>> GetSoftwareDevLabors()
        {
            var items = await LaborsRequest().ToListAsync();
            var orderedItems = ConvertToDto(items)
                .OrderBy(m => m.Code, CodeComparer.Instance)
                .ToArray();
            return orderedItems;
        }

        // GET: api/SoftwareDevLabor/SelectByCategory/5
        [HttpGet("[action]/{categoryId}")]
        public async Task<ActionResult<IEnumerable<DevelopmentLaborDto>>> SelectBy(int categoryId)
        {
            var items = await LaborsRequest()
                .Where(m => m.LaborCategoryID == categoryId)
                .ToListAsync();
                
            var orderedItems = ConvertToDto(items)
                .OrderBy(m => m.Code, CodeComparer.Instance)
                .ToArray();
            return orderedItems;
        }

        // GET: api/SoftwareDevLabor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DevelopmentLaborDto>> GetSoftwareDevLabor(int id)
        {
            var softwareDevLabor = await LaborsRequest()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (softwareDevLabor == null)
            {
                return NotFound();
            }

            return ConvertToDto(softwareDevLabor);
        }

        private IQueryable<SoftwareDevLabor> LaborsRequest()
        {
            return _context.SoftwareDevLabors
                .Include(m => m.LaborCategory)
                .AsNoTracking();
        }

        // PUT: api/SoftwareDevLabor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftwareDevLabor(int id, DevelopmentLaborDto softwareDevLaborDto)
        {
            if (id != softwareDevLaborDto.ID)
            {
                return BadRequest();
            }

            var softwareDevLabor = ConvertToSource(softwareDevLaborDto);
            _context.Entry(softwareDevLabor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareDevLaborExists(id))
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

        // POST: api/SoftwareDevLabor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DevelopmentLaborDto>> PostSoftwareDevLabor(DevelopmentLaborDto softwareDevLaborDto)
        {
            var softwareDevLabor = ConvertToSource(softwareDevLaborDto);
            _context.SoftwareDevLabors.Add(softwareDevLabor);
            await _context.SaveChangesAsync();

            softwareDevLabor = await LaborsRequest().FirstOrDefaultAsync(m => m.ID == softwareDevLabor.ID);
            return CreatedAtAction("GetSoftwareDevLabor", new { id = softwareDevLabor.ID }, ConvertToDto(softwareDevLabor));
        }

        // DELETE: api/SoftwareDevLabor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DevelopmentLaborDto>> DeleteSoftwareDevLabor(int id)
        {
            var softwareDevLabor = await _context.SoftwareDevLabors.FindAsync(id);
            if (softwareDevLabor == null)
            {
                return NotFound();
            }

            _context.SoftwareDevLabors.Remove(softwareDevLabor);
            await _context.SaveChangesAsync();

            return ConvertToDto(softwareDevLabor);
        }

        private bool SoftwareDevLaborExists(int id)
        {
            return _context.SoftwareDevLabors.Any(e => e.ID == id);
        }
    }
}
