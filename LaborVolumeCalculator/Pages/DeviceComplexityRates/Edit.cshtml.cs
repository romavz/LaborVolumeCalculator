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

namespace LaborVolumeCalculator.Pages.DeviceComplexityRates
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceComplexityRate DeviceComplexityRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeviceComplexityRate = await _context.DeviceComplexityRates
                .Include(d => d.DeviceComposition)
                .Include(d => d.DeviceCountRange).FirstOrDefaultAsync(m => m.ID == id);

            if (DeviceComplexityRate == null)
            {
                return NotFound();
            }
           ViewData["DeviceCompositionID"] = new SelectList(_context.DeviceCompositions, "ID", "Name");
           ViewData["DeviceCountRangeID"] = new SelectList(_context.Set<DeviceCountRange>(), "ID", "Name");
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

            _context.Attach(DeviceComplexityRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceComplexityRateExists(DeviceComplexityRate.ID))
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

        private bool DeviceComplexityRateExists(int id)
        {
            return _context.DeviceComplexityRates.Any(e => e.ID == id);
        }
    }
}
