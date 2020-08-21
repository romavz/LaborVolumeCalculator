using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    public class NirController
    {
        private readonly LVCContext _context;

        public NirController(LVCContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IList<NirStage> NirStages()
        {
            return _context.NirStages
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}