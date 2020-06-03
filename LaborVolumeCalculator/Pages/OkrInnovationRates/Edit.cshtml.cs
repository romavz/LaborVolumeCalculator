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

namespace LaborVolumeCalculator.Pages.OkrInnovationRates
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
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
                .FirstOrDefaultAsync( m => 
                    m.OkrInnovationPropertyID   == okrInnovationPropertyID  &&
                    m.DeviceCompositionID       == deviceCompositionID);

            if (OkrInnovationRate == null)
            {
                return NotFound();
            }

            ViewData["DeviceCompositionID"] = new SelectList(_context.DeviceCompositions, "ID", "Name");
            ViewData["OkrInnovationPropertyID"] = new SelectList(_context.OkrInnovationProperties, "ID", "Name");
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

            _context.Attach(OkrInnovationRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OkrInnovationRateExists(OkrInnovationRate.OkrInnovationPropertyID))
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

        private bool OkrInnovationRateExists(int id)
        {
            return _context.OkrInnovationRates.Any(e => e.OkrInnovationPropertyID == id);
        }
    }
}
