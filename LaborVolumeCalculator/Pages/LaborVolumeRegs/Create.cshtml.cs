using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Pages.LaborVolumeRegs
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
            ViewData["LaborID"] = new SelectList(_context.Labors, "ID", "Code");
            ViewData["NiokrID"] = new SelectList(_context.Niokrs, "ID", "Name");
            ViewData["NiokrStageID"] = new SelectList(_context.NiokrStages, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public LaborVolumeReg LaborVolumeReg { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LaborVolumeRegs.Add(LaborVolumeReg);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
