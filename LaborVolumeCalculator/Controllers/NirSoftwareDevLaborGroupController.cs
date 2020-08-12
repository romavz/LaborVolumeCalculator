using System;
using System.Collections.Generic;
using System.Linq;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/NirSoftwareDevLaborGroup")]
    public class NirSoftwareDevLaborGroupController
    {
        private readonly LVCContext _context;

        public NirSoftwareDevLaborGroupController(LVCContext context)
        {
            this._context = context;
        }

        [Route("GetAllButThis")]
        public IEnumerable<NirSoftwareDevLaborGroup> GetAllButThis(int[] ids)
        {
            var allGroups = _context.NirSoftwareDevLaborGroups;
            return allGroups
                .Except(allGroups.Where(m => ids.Contains(m.ID)))
                .ToList()
                .OrderBy(m => m.Code, CodeComparer.Instance);
        }

        [HttpGet]
        public string Get(string msg)
        {
            return msg;
        }
    }
}