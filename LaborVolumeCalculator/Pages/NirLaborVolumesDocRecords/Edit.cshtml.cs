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

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocRecords
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NirLaborVolumesDocRecord NirLaborVolumesDocRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirLaborVolumesDocRecord = await _context.NirLaborVolumesDocRecords
                .Include(n => n.Labor)
                .Include(n => n.NirLaborVolumesDoc).FirstOrDefaultAsync(m => m.NirLaborVolumesDocID == id);

            if (NirLaborVolumesDocRecord == null)
            {
                return NotFound();
            }
           ViewData["LaborID"] = new SelectList(_context.Labors, "ID", "Code");
           ViewData["NirLaborVolumesDocID"] = new SelectList(_context.NirLaborVolumesDocs, "ID", "ID");
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

            _context.Attach(NirLaborVolumesDocRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirLaborVolumesDocRecordExists(NirLaborVolumesDocRecord.NirLaborVolumesDocID))
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

        private bool NirLaborVolumesDocRecordExists(int id)
        {
            return _context.NirLaborVolumesDocRecords.Any(e => e.NirLaborVolumesDocID == id);
        }
    }
}
