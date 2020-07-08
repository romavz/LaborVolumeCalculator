using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;
using System.Collections;

namespace LaborVolumeCalculator.Pages.LaborGroups
{
    public class CreateModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public CreateModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? parentGroupId = null)
        {

            ParentGroup = _context.LaborGroup.Find(parentGroupId);
            return Page();
        }

        [BindProperty]
        public LaborGroup LaborGroup { get; set; }

        public LaborGroup ParentGroup { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LaborGroup.Add(LaborGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { parentGroupId = LaborGroup.ParentGroupId });
        }
    }
}
