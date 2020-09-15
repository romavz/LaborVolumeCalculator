using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.DeviceCountRanges
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceCountRange DeviceCountRange { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeviceCountRange = await _context.DeviceCountRange.FirstOrDefaultAsync(m => m.ID == id);

            if (DeviceCountRange == null)
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

            DeviceCountRange = await _context.DeviceCountRange.FindAsync(id);

            if (DeviceCountRange != null)
            {
                _context.DeviceCountRange.Remove(DeviceCountRange);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
