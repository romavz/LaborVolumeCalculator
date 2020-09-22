using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.DTO;
using AutoMapper;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirSoftwareDevLaborVolumeRegController : ControllerBase<NirSoftwareDevLaborVolumeReg, NirSoftwareDevLaborVolumeRegDto>
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborVolumeRegController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborVolumeReg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborVolumeRegDto>>> GetNirSoftwareDevLaborVolumeRegs()
        {
            var items =  await ItemsRequest().ToListAsync();
            var orderedItems = ConvertToDto(items)
                .OrderBy(m => m.LaborCode, CodeComparer.Instance)
                .ToArray();

            return orderedItems;
        }

        // GET: api/NirSoftwareDevLaborVolumeReg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeRegDto>> GetNirSoftwareDevLaborVolumeReg(int id)
        {
            var nirSoftwareDevLaborVolumeReg = await ItemsRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirSoftwareDevLaborVolumeReg == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborVolumeReg);
        }

        private IQueryable<NirSoftwareDevLaborVolumeReg> ItemsRequest()
        {
            return _context.NirSoftwareDevLaborVolumeRegs
                .Include(m => m.SoftwareDevLaborGroup)
                .Include(m => m.Labor)
                .AsNoTracking();
        }

        // PUT: api/NirSoftwareDevLaborVolumeReg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborVolumeReg(int id, NirSoftwareDevLaborVolumeRegDto nirSoftwareDevLaborVolumeRegDto)
        {
            if (id != nirSoftwareDevLaborVolumeRegDto.ID)
            {
                return BadRequest();
            }

            var nirSoftwareDevLaborVolumeReg = ConvertToSource(nirSoftwareDevLaborVolumeRegDto);
            _context.Entry(nirSoftwareDevLaborVolumeReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborVolumeRegExists(id))
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

        // POST: api/NirSoftwareDevLaborVolumeReg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeRegDto>> PostNirSoftwareDevLaborVolumeReg(NirSoftwareDevLaborVolumeRegDto nirSoftwareDevLaborVolumeRegDto)
        {
            var nirSoftwareDevLaborVolumeReg = ConvertToSource(nirSoftwareDevLaborVolumeRegDto);
            _context.NirSoftwareDevLaborVolumeRegs.Add(nirSoftwareDevLaborVolumeReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirSoftwareDevLaborVolumeReg", new { id = nirSoftwareDevLaborVolumeReg.ID }, nirSoftwareDevLaborVolumeReg);
        }

        // DELETE: api/NirSoftwareDevLaborVolumeReg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeRegDto>> DeleteNirSoftwareDevLaborVolumeReg(int id)
        {
            var nirSoftwareDevLaborVolumeReg = await ItemsRequest().FirstOrDefaultAsync(m => m.ID == id);
            if (nirSoftwareDevLaborVolumeReg == null)
            {
                return NotFound();
            }

            _context.NirSoftwareDevLaborVolumeRegs.Remove(nirSoftwareDevLaborVolumeReg);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborVolumeReg);
        }

        private bool NirSoftwareDevLaborVolumeRegExists(int id)
        {
            return _context.NirSoftwareDevLaborVolumeRegs.Any(e => e.ID == id);
        }
    }
}
