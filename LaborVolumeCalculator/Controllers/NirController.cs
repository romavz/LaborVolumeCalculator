using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NirController : ControllerBase
    {
        private readonly LVCContext _context;

        public NirController(LVCContext context)
        {
            _context = context;
        }

        [HttpGet("{nirId}/[action]")]
        public async Task<ActionResult<IEnumerable<NirStage>>> Stages(int nirId)
        {
            var nirStage = await _context.Nirs.FindAsync(nirId);

            if (nirStage == null)
            {
                return NotFound();
            }

            return await _context.NiokrStageRegs
                .Include(stageReg => stageReg.NiokrStage)
                .Where(reg => reg.NiokrID == nirId)
                .Select(reg => (NirStage)reg.NiokrStage)
                .OrderBy(stage => stage.Name)
                .AsNoTracking()
                .ToListAsync();
        }
       
        // Данный метод устарел, будет удален в следующей итерации, после исправления клиентской части. 
        // Вместо этого необходимо пользоваться методом Stages(nirId)
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<NirStage>>> NirStages()
        {
            return await _context.NirStages.ToListAsync();
        }
    }
}