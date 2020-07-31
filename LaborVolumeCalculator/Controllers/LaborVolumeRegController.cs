using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Services;
using LaborVolumeCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaborVolumeCalculator.Controllers
{
    [Route("api/LaborVolumeReg")]
    [Produces("application/json")]
    public class LaborVolumeRegController : ControllerBase
    {
        private readonly ILaborVolumeRegService _regService;

        public LaborVolumeRegController(ILaborVolumeRegService laborVolumeRegService)
        {
            this._regService = laborVolumeRegService;
        }

        //GET api/LaborVolumeReg/GetByNiokrStage? niokrID = 3 & niokrStageID = 1
        [HttpGet(Name = "GetByNiokrStage")]
        public IEnumerable<LaborVolumeReg> Get(int niokrID, int niokrStageID)
        {
            return _regService.GetNiokrStageLaborVolumes(niokrID, niokrStageID);
        }
    }
}
