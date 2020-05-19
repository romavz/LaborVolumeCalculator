using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.NirInnovationRates
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<NirInnovationRate> NirInnovationRate { get;set; }

        public async Task OnGetAsync()
        {
            NirInnovationRate = await _context.NirInnovationRates
                .Include(n => n.Nir)
                .Include(n => n.NirInnovationProperty).ToListAsync();
        }
    }
}
