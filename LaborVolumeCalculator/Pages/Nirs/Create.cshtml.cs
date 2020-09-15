using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Pages.Nirs
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
            ViewData["NirInnovationPropertyID"] = new SelectList(_context.NirInnovationProperties, "ID", "Name");
            ViewData["NirScaleID"] = new SelectList(_context.NirScales, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Nir Nir { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var nirInnovationRate = await _context.NirInnovationRates
                .Where(n => n.NirInnovationPropertyID == Nir.NirInnovationPropertyID)
                .Where(n => n.NirScaleID == Nir.NirScaleID)
                .FirstOrDefaultAsync();

            Nir.NirInnovationRateValue = nirInnovationRate.Value;

            _context.Nirs.Add(Nir);
            await _context.SaveChangesAsync();

            return RedirectToPage("./EditLaborVolumes", new { id = Nir.ID });
        }
    }
}
