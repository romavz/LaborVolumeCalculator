using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Labors
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Labor Labor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Labor = await _context.Labors
                .Include(l => l.LaborGroup).FirstOrDefaultAsync(m => m.ID == id);

            if (Labor == null)
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

            Labor = await _context.Labors.FindAsync(id);

            if (Labor != null)
            {
                _context.Labors.Remove(Labor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../LaborGroups/Index", new { parentGroupId = Labor.LaborGroupId });
        }
    }
}
