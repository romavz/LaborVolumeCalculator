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
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareDevEnvController : ControllerBase<SoftwareDevEnv, SoftwareDevEnvDto>
    {
        private readonly IRepository<SoftwareDevEnv> _context;

        public SoftwareDevEnvController(IRepository<SoftwareDevEnv> context, IMapper mapper) : base(mapper)
        {
            _context = context;
        }

        // GET: api/SoftwareDevEnv
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwareDevEnvDto>>> GetSoftwareDevEnvs()
        {
            var items = await _context.GetAll().ToListAsync();
            return ConvertToDto(items);
        }

        // GET: api/SoftwareDevEnv/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftwareDevEnvDto>> GetSoftwareDevEnv(int id)
        {
            var softwareDevEnv = await _context.FirstOrDefaultAsync(m => m.ID == id);

            if (softwareDevEnv == null)
            {
                return NotFound();
            }

            return ConvertToDto(softwareDevEnv);
        }

        // PUT: api/SoftwareDevEnv/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SoftwareDevEnvDto>> PutSoftwareDevEnv(int id, SoftwareDevEnvChangeDto softwareDevEnvDto)
        {
            if (id != softwareDevEnvDto.ID)
            {
                return BadRequest();
            }

            var softwareDevEnv = ConvertToSource(softwareDevEnvDto);
            _context.Update(softwareDevEnv);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareDevEnvExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            softwareDevEnv = await _context.FirstOrDefaultAsync(m => m.ID == softwareDevEnv.ID);

            return Ok(ConvertToDto(softwareDevEnv));
        }

        // POST: api/SoftwareDevEnv
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SoftwareDevEnvDto>> PostSoftwareDevEnv(SoftwareDevEnvCreateDto softwareDevEnvDto)
        {
            var softwareDevEnv = ConvertToSource(softwareDevEnvDto);
            _context.Add(softwareDevEnv);
            await _context.SaveChangesAsync();

            softwareDevEnv = await _context.FirstOrDefaultAsync(m => m.ID == softwareDevEnv.ID);

            return CreatedAtAction("GetSoftwareDevEnv", new { id = softwareDevEnv.ID }, ConvertToDto(softwareDevEnv));
        }

        // DELETE: api/SoftwareDevEnv/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SoftwareDevEnv>> DeleteSoftwareDevEnv(int id)
        {
            var softwareDevEnv = await _context.FirstOrDefaultAsync(m => m.ID == id);
            if (softwareDevEnv == null)
            {
                return NotFound();
            }

            _context.Remove(softwareDevEnv);
            await _context.SaveChangesAsync();

            return softwareDevEnv;
        }

        private bool SoftwareDevEnvExists(int id)
        {
            return _context.Any(e => e.ID == id);
        }
    }
}
