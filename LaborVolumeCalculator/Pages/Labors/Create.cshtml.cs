using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Labors
{
    public class CreateModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public CreateModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int laborGroupId)
        {
            LaborGroup = _context.LaborGroups.Find(laborGroupId);
            return Page();
        }

        [BindProperty]
        public Labor Labor { get; set; }

        public LaborGroup LaborGroup { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Labors.Add(Labor);
            await _context.SaveChangesAsync();

            return RedirectToPage("../LaborGroups/Index", new { parentGroupId = Labor.LaborGroupId });
        }
    }
}
