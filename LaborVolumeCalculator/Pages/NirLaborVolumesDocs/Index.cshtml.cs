using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Pages.NirLaborVolumesDocs
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<NirLaborVolumesDoc> NirLaborVolumesDoc { get;set; }

        public async Task OnGetAsync()
        {
            NirLaborVolumesDoc = await _context.NirLaborVolumesDocs
                .Include(n => n.Niokr)
                .Include(n => n.NiokrStage).ToListAsync();
        }
    }
}
