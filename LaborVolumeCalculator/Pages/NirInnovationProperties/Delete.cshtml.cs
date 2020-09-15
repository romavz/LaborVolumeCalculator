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
    public class DeleteModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public DeleteModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NirInnovationProperty = await _context.NirInnovationProperties.FindAsync(id);

            if (NirInnovationProperty != null)
            {
                _context.NirInnovationProperties.Remove(NirInnovationProperty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
