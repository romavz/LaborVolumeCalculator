using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.OkrInnovationRates
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<OkrInnovationRate> OkrInnovationRates { get;set; }

        public async Task OnGetAsync()
        {
            OkrInnovationRates = await _context.OkrInnovationRates
                .Include(o => o.DeviceComposition)
                .Include(o => o.OkrInnovationProperty).ToListAsync();
        }
    }
}
