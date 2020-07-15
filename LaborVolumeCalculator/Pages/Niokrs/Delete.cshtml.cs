using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.Niokrs
{
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Niokr Niokr { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Niokr = await _context.Niokrs.FirstOrDefaultAsync(m => m.ID == id);

            if (Niokr == null)
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

            Niokr = await _context.Niokrs.FindAsync(id);

            if (Niokr != null)
            {
                _context.Niokrs.Remove(Niokr);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
