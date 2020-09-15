using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.OkrInnovationRates
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public OkrInnovationRate OkrInnovationRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? okrInnovationPropertyID, int? deviceCompositionID)
        {
            if (okrInnovationPropertyID == null || deviceCompositionID == null)
            {
                return NotFound();
            }

            OkrInnovationRate = await _context.OkrInnovationRates
                .Include(o => o.DeviceComposition)
                .Include(o => o.OkrInnovationProperty)
                .FirstOrDefaultAsync(m =>
                   m.OkrInnovationPropertyID == okrInnovationPropertyID &&
                   m.DeviceCompositionID == deviceCompositionID);

            if (OkrInnovationRate == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
