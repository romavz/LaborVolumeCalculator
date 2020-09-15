using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.DeviceComplexityRates
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceComplexityRate DeviceComplexityRate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeviceComplexityRate = await _context.DeviceComplexityRates
                .Include(d => d.DeviceComposition)
                .Include(d => d.DeviceCountRange).FirstOrDefaultAsync(m => m.ID == id);

            if (DeviceComplexityRate == null)
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

            DeviceComplexityRate = await _context.DeviceComplexityRates.FindAsync(id);

            if (DeviceComplexityRate != null)
            {
                _context.DeviceComplexityRates.Remove(DeviceComplexityRate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
