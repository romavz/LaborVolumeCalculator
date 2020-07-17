using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocRecords
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<NirLaborVolumesDocRecord> NirLaborVolumesDocRecord { get;set; }

        public async Task OnGetAsync()
        {
            NirLaborVolumesDocRecord = await _context.NirLaborVolumesDocRecords
                .Include(n => n.Labor)
                .Include(n => n.NirLaborVolumesDoc).ToListAsync();
        }
    }
}
