using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Utils;
using LaborVolumeCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirLaborVolumeRegController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirLaborVolumeRegController(LVCContext context)
        {
            this._context = context;
        }

        //GET api/NirLaborVolumeReg/GetNirLaborsRegs? niokrID = 3 & niokrStageID = 1
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<LaborVolumeReg>>> GetNirLaborsRegs(int niokrID, int niokrStageID)
        {
            var laborVolumes = await _context.LaborVolumeRegs
                .AsNoTracking()
                .Include(m => m.Labor)
                .Where(m =>
                    m.NiokrID == niokrID
                    && m.NiokrStageID == niokrStageID)
                .ToListAsync();

            await Task.Run(() => laborVolumes.OrderBy(m => m.Labor.Code, CodeComparer.Instance));
            return laborVolumes;
        }

        // [HttpPost("[action]")]
        // public async Task<ActionResult<IEnumerable<LaborVolumeReg>>> AddTypycalLabors(int niokrID, int niokrStageID)
        // {
            

        //     // CreatedAtAction("GetByNiokrStage", new { niokrID, niokrStageID }, result )
        // }

    }
}
