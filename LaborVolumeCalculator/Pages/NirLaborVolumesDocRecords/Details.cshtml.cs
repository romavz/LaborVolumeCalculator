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
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public NirLaborVolumesDocRecord NirLaborVolumesDocRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirLaborVolumesDocRecord = await _context.NirLaborVolumesDocRecords
                .Include(n => n.Labor)
                .Include(n => n.NirLaborVolumesDoc).FirstOrDefaultAsync(m => m.ID == id);

            if (NirLaborVolumesDocRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
