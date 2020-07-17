using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocRecords
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirLaborVolumesDocRecord = await _context.NirLaborVolumesDocRecords.FindAsync(id);

            if (NirLaborVolumesDocRecord != null)
            {
                _context.NirLaborVolumesDocRecords.Remove(NirLaborVolumesDocRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
