using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Pages.Niokrs
{
    public class EditModel : PageModel
    {
        private readonly LVCContext _context;

        public EditModel(LVCContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Niokr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NiokrExists(Niokr.ID))
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

        private bool NiokrExists(int id)
        {
            return _context.Niokrs.Any(e => e.ID == id);
        }
    }
}
