using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.NirInnovationProperties
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public NirInnovationProperty NirInnovationProperty { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirInnovationProperty = await _context.NirInnovationProperties.FirstOrDefaultAsync(m => m.ID == id);

            if (NirInnovationProperty == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
