using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Registers
{
    public class LaborVolumeReg
    {
        public LaborVolumeReg()
        {

        }

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int NiokrID { get; set; }
        public Niokr Niokr { get; set; }
        
        public int NiokrStageID { get; set; }
        public NiokrStage NiokrStage { get; set; }

        public int LaborID { get; set; }
        public Labor Labor { get; set; }

        [DisplayName("Объем")]
        public float Volume { get; set; }
        [DisplayName("Итог")]
        public float TotalVolume { get; set; }

    }
}
