using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты ОКР", GroupName = "Трудозатраты ОКР")]
    public class OkrLabor : Labor
    {
        public OkrLabor()
        {
        }

        public OkrLabor(string code, string name, StageForOkr okrStage, double minVolume, double maxVolume) : base(code, name, minVolume, maxVolume)
        {
            OkrStage = okrStage ?? throw new ArgumentNullException("okrStage");
            OkrStageID = okrStage.ID;
        }

        public int OkrStageID { get; set; }

        [DisplayName("Этап ОКР")]
        public StageForOkr OkrStage { get; set; }
        
    }
}
