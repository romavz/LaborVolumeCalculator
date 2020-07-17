using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocs
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public NirLaborVolumesDoc NirLaborVolumesDoc { get; set; }

        public List<NirLaborVolumesDocRecord> NirLaborVolumesDocRecords { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirLaborVolumesDoc = await _context.NirLaborVolumesDocs
                .Include(n => n.Niokr)
                .Include(n => n.NiokrStage)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (NirLaborVolumesDoc == null)
            {
                return NotFound();
            }

            NirLaborVolumesDocRecords = await _context.NirLaborVolumesDocRecords
                .Include(n => n.Labor)
                .Where(n => n.NirLaborVolumesDocID == id)
                .ToListAsync();

            return Page();
        }
    }
}
