using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Pages.LaborGroups
{
    public class IndexModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public IndexModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public IList<LaborGroup> LaborGroups { get; set; }

        public int? ParentGroupId { get; set; }

        public LaborGroup ParentGroup { get; set; }

        public async Task OnGetAsync(int? parentGroupId)
        {
            ParentGroupId = parentGroupId;
            ParentGroup = await _context.LaborGroups
                .Include(i => i.Labors)
                .FirstOrDefaultAsync(lg => lg.ID == parentGroupId);

            LaborGroups = await _context.LaborGroups
                .Where(lg => lg.ParentGroupId == parentGroupId)
                .ToListAsync();
        }
    }
}
