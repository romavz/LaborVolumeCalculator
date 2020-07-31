using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Okrs
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public Okr Okr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Okr = await _context.Okrs
                .Include(o => o.DeviceComposition)
                .Include(o => o.DeviceCountRange)
                .Include(o => o.OkrInnovationProperty).FirstOrDefaultAsync(m => m.ID == id);

            if (Okr == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
