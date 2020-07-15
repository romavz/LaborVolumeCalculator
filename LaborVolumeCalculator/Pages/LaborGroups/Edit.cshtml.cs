using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.LaborGroups
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LaborGroup LaborGroup { get; set; }

        public LaborGroup ParentGroup { get; private set; }

        public int? ParentGroupId { get; private set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaborGroup = await _context.LaborGroups
                .Include(l => l.ParentGroup).FirstOrDefaultAsync(m => m.ID == id);

            if (LaborGroup == null)
            {
                return NotFound();
            }

            ParentGroup = LaborGroup.ParentGroup;
            ParentGroupId = LaborGroup.ParentGroupId;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LaborGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborGroupExists(LaborGroup.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { parentGroupId = LaborGroup.ParentGroupId });
        }

        private bool LaborGroupExists(int? id)
        {
            return _context.LaborGroups.Any(e => e.ID == id);
        }
    }
}
