using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Pages.DeviceComplexityRates
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<DeviceComplexityRate> DeviceComplexityRates { get;set; }

        public async Task OnGetAsync()
        {
            DeviceComplexityRates = await _context.DeviceComplexityRates
                .Include(d => d.DeviceComposition)
                .Include(d => d.DeviceCountRange).ToListAsync();
        }
    }
}
