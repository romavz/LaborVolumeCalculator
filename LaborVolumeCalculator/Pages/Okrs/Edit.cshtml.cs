using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Okrs
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Okr Okr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Okr = await _context.Okrs
                .Include(o => o.DeviceComposition)
                .Include(o => o.DeviceCountRange)
                .Include(o => o.OkrInnovationProperty).FirstOrDefaultAsync(m => m.ID == id);

            if (Okr == null)
            {
                return NotFound();
            }
            ViewData["DeviceCompositionID"] = new SelectList(_context.DeviceCompositions, "ID", "Name");
            ViewData["DeviceCountRangeID"] = new SelectList(_context.DeviceCountRange, "ID", "Name");
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

            var okrInnovationRate = await _context.OkrInnovationRates
                .Where(n => n.OkrInnovationPropertyID == Okr.OkrInnovationPropertyID)
                .Where(n => n.DeviceCompositionID == Okr.DeviceCompositionID)
                .FirstOrDefaultAsync();

            var deviceComplexityRate = await _context.DeviceComplexityRates
                .Where(n => n.DeviceCompositionID == Okr.DeviceCompositionID)
                .Where(n => n.DeviceCountRangeID == Okr.DeviceCountRangeID)
                .FirstOrDefaultAsync();

            Okr.DeviceComplexityRateID = deviceComplexityRate.ID;
            Okr.OkrInnovationRateID = okrInnovationRate.ID;

            _context.Attach(Okr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OkrExists(Okr.ID))
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

        private bool OkrExists(int id)
        {
            return _context.Okrs.Any(e => e.ID == id);
        }
    }
}
