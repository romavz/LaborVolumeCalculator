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
using LaborVolumeCalculator.DTO;
using AutoMapper;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionRatesBundleController : ControllerBase<CorrectionRatesBundle, CorrectionRatesBundleFullDto>
    {
        private readonly IRepository<CorrectionRatesBundle> _bundles;

        public CorrectionRatesBundleController(IRepository<CorrectionRatesBundle> context, IMapper mapper) : base(mapper)
        {
            _bundles = context;
        }

        // GET: api/CorrectionRatesBundle
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CorrectionRatesBundleFullDto>>> GetCorrectionRatesBundles()
        {
            var items = await _bundles.WithIncludes.ToListAsync();
            var itemsDto = ConvertToDto(items)
                .OrderBy(m => m.Number)
                .ToList();
            return itemsDto;
        }

        // GET: api/CorrectionRatesBundle/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // validation errors
        public async Task<ActionResult<CorrectionRatesBundleFullDto>> GetCorrectionRatesBundle(int id)
        {
            var correctionRatesBundle = await _bundles.WithIncludes.FindAsync(id);

            if (correctionRatesBundle == null)
            {
                return NotFound();
            }

            return ConvertToDto(correctionRatesBundle);
        }

        // PUT: api/CorrectionRatesBundle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CorrectionRatesBundleDto>> PutCorrectionRatesBundle(int id, CorrectionRatesBundleDto correctionRatesBundleDto)
        {
            if (id != correctionRatesBundleDto.ID)
            {
                return BadRequest();
            }

            var correctionRatesBundle = ConvertToSource<CorrectionRatesBundleDto>(correctionRatesBundleDto);

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
                    return Conflict();
                }
            }

            correctionRatesBundle = await _bundles.FindAsync(correctionRatesBundle.ID);
            return Ok(ConvertToDto<CorrectionRatesBundleDto>(correctionRatesBundle));
        }

        // POST: api/CorrectionRatesBundle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<CorrectionRatesBundleDto>> PostCorrectionRatesBundle(CorrectionRatesBundleCreateDto correctionRatesBundleDto)
        {
            var correctionRatesBundle = ConvertToSource<CorrectionRatesBundleCreateDto>(correctionRatesBundleDto);
            
            _bundles.Add(correctionRatesBundle);
            await _bundles.SaveChangesAsync();

            correctionRatesBundle = await _bundles.FindAsync(correctionRatesBundle.ID);

            return CreatedAtAction("GetCorrectionRatesBundle", new { id = correctionRatesBundle.ID }, ConvertToDto<CorrectionRatesBundleDto>(correctionRatesBundle));
        }

        // DELETE: api/CorrectionRatesBundle/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // validation errors
        public async Task<ActionResult<CorrectionRatesBundleDto>> DeleteCorrectionRatesBundle(int id)
        {
            var correctionRatesBundle = await _bundles.FindAsync(id);
            if (correctionRatesBundle == null)
            {
                return NotFound();
            }

            _bundles.Remove(correctionRatesBundle);
            await _bundles.SaveChangesAsync();

            return ConvertToDto<CorrectionRatesBundleDto>(correctionRatesBundle);
        }

        private bool CorrectionRatesBundleExists(int id)
        {
            return _bundles.Any(e => e.ID == id);
        }
    }
}
