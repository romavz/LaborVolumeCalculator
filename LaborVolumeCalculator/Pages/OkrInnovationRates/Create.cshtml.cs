using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.OkrInnovationRates
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
        ViewData["OkrInnovationPropertyID"] = new SelectList(_context.OkrInnovationProperties, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public OkrInnovationRate OkrInnovationRate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OkrInnovationRates.Add(OkrInnovationRate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
