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
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? okrInnovationPropertyID, int? deviceCompositionID)
        {
            if (okrInnovationPropertyID == null || deviceCompositionID == null)
            {
                return NotFound();
            }

            OkrInnovationRate = await _context.OkrInnovationRates
                .FindAsync(okrInnovationPropertyID, deviceCompositionID);

            if (OkrInnovationRate != null)
            {
                _context.OkrInnovationRates.Remove(OkrInnovationRate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
