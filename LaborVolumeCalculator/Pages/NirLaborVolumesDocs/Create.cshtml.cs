using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocs
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
        ViewData["NiokrStageID"] = new SelectList(_context.NiokrStages, "ID", "Name");
        ViewData["NirID"] = new SelectList(_context.Nirs, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public NirLaborVolumesDoc NirLaborVolumesDoc { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var nir = await _context.Nirs
                .Where(n => n.ID == NirLaborVolumesDoc.NirID)
                .FirstOrDefaultAsync();

            var nirInnovationRate = await _context.NirInnovationRates
                .Where(n => n.ID == nir.NirInnovationRateID)
                .FirstOrDefaultAsync();

            NirLaborVolumesDoc.NirInnovationRate = (float)nirInnovationRate.Value;

            _context.NirLaborVolumesDocs.Add(NirLaborVolumesDoc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
