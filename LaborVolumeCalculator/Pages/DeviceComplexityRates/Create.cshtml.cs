using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.DeviceComplexityRates
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
            ViewData["DeviceCountRangeID"] = new SelectList(_context.Set<DeviceCountRange>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public DeviceComplexityRate DeviceComplexityRate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeviceComplexityRates.Add(DeviceComplexityRate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
