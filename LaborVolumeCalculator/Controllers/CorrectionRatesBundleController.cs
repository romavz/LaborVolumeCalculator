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

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionRatesBundleController : ControllerBase
    {
        private readonly IRepository<CorrectionRatesBundle> _bundles;

        public CorrectionRatesBundleController(IRepository<CorrectionRatesBundle> context)
        {
            _bundles = context;
        }

        // GET: api/CorrectionRatesBundle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorrectionRatesBundle>>> GetCorrectionRatesBundles()
        {
            return await _bundles.WithIncludes.ToListAsync();
        }

        // GET: api/CorrectionRatesBundle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorrectionRatesBundle>> GetCorrectionRatesBundle(int id)
        {
            var correctionRatesBundle = await _bundles.WithIncludes.FindAsync(id);

            if (correctionRatesBundle == null)
            {
                return NotFound();
            }

            return correctionRatesBundle;
        }

        // PUT: api/CorrectionRatesBundle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorrectionRatesBundle(int id, CorrectionRatesBundle correctionRatesBundle)
        {
            if (id != correctionRatesBundle.ID)
            {
                return BadRequest();
            }

            _bundles.Update(correctionRatesBundle);

            try
            {
                await _bundles.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrectionRatesBundleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CorrectionRatesBundle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CorrectionRatesBundle>> PostCorrectionRatesBundle(CorrectionRatesBundle correctionRatesBundle)
        {
            _bundles.Add(correctionRatesBundle);
            await _bundles.SaveChangesAsync();

            return CreatedAtAction("GetCorrectionRatesBundle", new { id = correctionRatesBundle.ID }, correctionRatesBundle);
        }

        // DELETE: api/CorrectionRatesBundle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CorrectionRatesBundle>> DeleteCorrectionRatesBundle(int id)
        {
            var correctionRatesBundle = await _bundles.FindAsync(id);
            if (correctionRatesBundle == null)
            {
                return NotFound();
            }

            _bundles.Remove(correctionRatesBundle);
            await _bundles.SaveChangesAsync();

            return correctionRatesBundle;
        }

        private bool CorrectionRatesBundleExists(int id)
        {
            return _bundles.Any(e => e.ID == id);
        }
    }
}
