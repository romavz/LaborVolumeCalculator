using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.NirInnovationRates
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NirInnovationRate NirInnovationRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? nirID, int? nirInnovationPropertyID)
        {
            if (nirID == null || nirInnovationPropertyID == null)
            {
                return NotFound();
            }

            NirInnovationRate = await _context.NirInnovationRates
                .Include(n => n.NirScale)
                .Include(n => n.NirInnovationProperty)
                .FirstOrDefaultAsync(m => m.NirScaleID == nirID && m.NirInnovationPropertyID == nirInnovationPropertyID);

            if (NirInnovationRate == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? nirID, int? nirInnovationPropertyID)
        {
            if (nirID == null || nirInnovationPropertyID == null)
            {
                return NotFound();
            }

            NirInnovationRate = await _context.NirInnovationRates.FindAsync(nirID, nirInnovationPropertyID);

            if (NirInnovationRate != null)
            {
                _context.NirInnovationRates.Remove(NirInnovationRate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
