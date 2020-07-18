using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Pages.Niokrs
{
    public class IndexModel : PageModel
    {
        private readonly LVCContext _context;

        public IndexModel(LVCContext context)
        {
            _context = context;
        }

        public IList<Niokr> Niokrs { get;set; }

        public async Task OnGetAsync()
        {
            Niokrs = await _context.Niokrs
                .ToListAsync();
        }
    }
}
