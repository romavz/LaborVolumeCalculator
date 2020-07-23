using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Pages.LaborVolumeRegs
{
    public class EditModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["LaborID"] = new SelectList(_context.Labors, "ID", "Code");
            ViewData["NiokrID"] = new SelectList(_context.Niokrs, "ID", "Name");
            ViewData["NiokrStageID"] = new SelectList(_context.NiokrStages, "ID", "Name");
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

            _context.Attach(LaborVolumeReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaborVolumeRegExists(LaborVolumeReg.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LaborVolumeRegExists(int id)
        {
            return _context.LaborVolumeRegs.Any(e => e.ID == id);
        }
    }
}
