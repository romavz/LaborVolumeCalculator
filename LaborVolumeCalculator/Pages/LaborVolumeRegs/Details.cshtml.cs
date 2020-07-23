using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Pages.LaborVolumeRegs
{
    public class DetailsModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DetailsModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public LaborVolumeReg LaborVolumeReg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaborVolumeReg = await _context.LaborVolumeRegs
                .Include(l => l.Labor)
                .Include(l => l.Niokr)
                .Include(l => l.NiokrStage).FirstOrDefaultAsync(m => m.ID == id);

            if (LaborVolumeReg == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
