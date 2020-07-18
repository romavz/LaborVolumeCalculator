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
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            var niokrs = _context.Niokrs;
                //.Include(i => i.NiokrCategory)
                //.Where(i => i.NiokrCategory.Name == NiokrCategory.NIR.Name);

            var niokrStages = _context.NiokrStages
                .Include(i => i.NiokrCategory)
                .Where(i => i.NiokrCategory.Name == NiokrCategory.NIR.Name);

            ViewData["NiokrID"] = new SelectList(niokrs, "ID", "Name");
            ViewData["NiokrStageID"] = new SelectList(niokrStages, "ID", "Name");
            ViewData["NirInnovationPropertyID"] = new SelectList(_context.NirInnovationProperties, "ID", "Name");
            ViewData["NirScaleID"] = new SelectList(_context.NirScales, "ID", "Name");
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

            //Nir nir = NirLaborVolumesDoc.Nir;

            //NirLaborVolumesDoc.NirInnovationRate = (float)_context.NirInnovationRates.Where(d => d.ID == )
            //    .FirstOrDefault().Value;

            _context.NirLaborVolumesDocs.Add(NirLaborVolumesDoc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
