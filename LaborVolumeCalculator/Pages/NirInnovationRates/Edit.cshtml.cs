using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.NirInnovationRates
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NirInnovationRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirInnovationRateExists(NirInnovationRate.NirScaleID, NirInnovationRate.NirInnovationPropertyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NirInnovationRateExists(int nirID, int nirInnovationPropertyID)
        {
            return _context.NirInnovationRates.Any(e => e.NirScaleID == nirID && e.NirInnovationPropertyID == nirInnovationPropertyID);
        }
    }
}
