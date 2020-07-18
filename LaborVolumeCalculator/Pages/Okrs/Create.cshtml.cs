using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Pages.Okrs
{
    public class CreateModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public CreateModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeviceCompositionID"] = new SelectList(_context.DeviceCompositions, "ID", "Name");
        ViewData["DeviceCountRangeID"] = new SelectList(_context.DeviceCountRange, "ID", "Name");
        ViewData["OkrInnovationPropertyID"] = new SelectList(_context.OkrInnovationProperties, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Okr Okr { get; set; }

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

            _context.Okrs.Add(Okr);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
