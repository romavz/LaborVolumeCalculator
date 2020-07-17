using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocRecords
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
        ViewData["NirLaborVolumesDocID"] = new SelectList(_context.NirLaborVolumesDocs, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public NirLaborVolumesDocRecord NirLaborVolumesDocRecord { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NirLaborVolumesDocRecords.Add(NirLaborVolumesDocRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
