using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Pages.LaborVolumeRegs
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<LaborVolumeReg> LaborVolumeReg { get;set; }

        public async Task OnGetAsync()
        {
            LaborVolumeReg = await _context.LaborVolumeRegs
                .Include(l => l.Labor)
                .Include(l => l.Niokr)
                .Include(l => l.NiokrStage).ToListAsync();
        }
    }
}
