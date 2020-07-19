using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocs
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NirLaborVolumesDoc NirLaborVolumesDoc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirLaborVolumesDoc = await _context.NirLaborVolumesDocs
                .Include(n => n.Nir)
                .Include(n => n.NiokrStage)
                .Include(n => n.NirLaborVolumesDocRecords)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (NirLaborVolumesDoc == null)
            {
                return NotFound();
            }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NirLaborVolumesDoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborVolumesDocExists(NirLaborVolumesDoc.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NirLaborVolumesDocExists(int id)
        {
            return _context.NirLaborVolumesDocs.Any(e => e.ID == id);
        }
    }
}
