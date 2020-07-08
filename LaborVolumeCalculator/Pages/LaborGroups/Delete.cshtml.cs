using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.LaborGroups
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LaborGroup LaborGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaborGroup = await _context.LaborGroup
                .Include(l => l.ParentGroup).FirstOrDefaultAsync(m => m.ID == id);

            if (LaborGroup == null)
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

            LaborGroup = await _context.LaborGroup.FindAsync(id);

            if (LaborGroup != null)
            {
                _context.LaborGroup.Remove(LaborGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
