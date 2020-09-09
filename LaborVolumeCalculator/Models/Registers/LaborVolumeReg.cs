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

        [DisplayName("Объем")]
        public float Volume { get; set; }
        [DisplayName("Итог")]
        public float TotalVolume { get; set; }

    }
}
