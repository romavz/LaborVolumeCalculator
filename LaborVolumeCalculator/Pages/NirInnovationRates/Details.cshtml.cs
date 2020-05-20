using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.NirInnovationRates
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public NirInnovationRate NirInnovationRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? nirID, int? nirInnovationPropertyID)
        {
            if (nirID == null || nirInnovationPropertyID == null)
            {
                return NotFound();
            }

            NirInnovationRate = await _context.NirInnovationRates
                .Include(n => n.Nir)
                .Include(n => n.NirInnovationProperty)
                .FirstOrDefaultAsync(m => m.NirID == nirID && m.NirInnovationPropertyID == nirInnovationPropertyID);

            if (NirInnovationRate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
