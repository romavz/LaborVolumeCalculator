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
    public class NirSoftwareDevLaborVolumeController : ControllerBase<NirSoftwareDevLaborVolume, NirSoftwareDevLaborVolumeDto>
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborVolumeController(LVCContext context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/NirSoftwareDevLaborVolume
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NirSoftwareDevLaborVolumeDto>>> GetNirSoftwareDevLaborVolumes()
        {
            var items =  await ItemsRequest().ToListAsync();
            var orderedItems = ConvertToDto(items)
                .ToArray();

            return orderedItems;
        }

        // GET: api/NirSoftwareDevLaborVolume/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeDto>> GetNirSoftwareDevLaborVolume(int id)
        {
            var nirSoftwareDevLaborVolume = await ItemsRequest().FirstOrDefaultAsync(m => m.ID == id);

            if (nirSoftwareDevLaborVolume == null)
            {
                return NotFound();
            }

            return ConvertToDto(nirSoftwareDevLaborVolume);
        }

        private IQueryable<NirSoftwareDevLaborVolume> ItemsRequest()
        {
            return _context.NirSoftwareDevLaborVolums
                .Include(m => m.SoftwareDevLaborGroup)
                .Include(m => m.LaborVolumeRange)
                    .ThenInclude(range => range.Labor)
                .Include(m => m.LaborVolumeRange)
                    .ThenInclude(range => range.DevEnv)
                .AsNoTracking();
        }

        // PUT: api/NirSoftwareDevLaborVolume/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNirSoftwareDevLaborVolume(int id, NirSoftwareDevLaborVolumeDto nirSoftwareDevLaborVolumeDto)
        {
            if (id != nirSoftwareDevLaborVolumeDto.ID)
            {
                return BadRequest();
            }

            var NirSoftwareDevLaborVolume = ConvertToSource(nirSoftwareDevLaborVolumeDto);
            _context.Entry(NirSoftwareDevLaborVolume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirSoftwareDevLaborVolumeExists(id))
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

        // POST: api/NirSoftwareDevLaborVolume
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeDto>> PostNirSoftwareDevLaborVolume(NirSoftwareDevLaborVolumeDto nirSoftwareDevLaborVolumeDto)
        {
            var nirSoftwareDevLaborVolume = ConvertToSource(nirSoftwareDevLaborVolumeDto);
            _context.NirSoftwareDevLaborVolums.Add(nirSoftwareDevLaborVolume);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNirSoftwareDevLaborVolume", new { id = nirSoftwareDevLaborVolume.ID }, nirSoftwareDevLaborVolume);
        }

        // DELETE: api/NirSoftwareDevLaborVolume/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NirSoftwareDevLaborVolumeDto>> DeleteNirSoftwareDevLaborVolume(int id)
        {
            var nirSoftwareDevLaborVolume = await ItemsRequest().FirstOrDefaultAsync(m => m.ID == id);
            if (nirSoftwareDevLaborVolume == null)
            {
                return NotFound();
            }

            _context.NirSoftwareDevLaborVolums.Remove(nirSoftwareDevLaborVolume);
            await _context.SaveChangesAsync();

            return ConvertToDto(nirSoftwareDevLaborVolume);
        }

        private bool NirSoftwareDevLaborVolumeExists(int id)
        {
            return _context.NirSoftwareDevLaborVolums.Any(e => e.ID == id);
        }
    }
}
