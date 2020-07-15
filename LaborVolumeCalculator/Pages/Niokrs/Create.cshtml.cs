using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Niokrs
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
            ViewData["NiokrCategoryID"] = new SelectList(_context.NiokrCategories, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Niokr Niokr { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Niokrs.Add(Niokr);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
