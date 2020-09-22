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
        public int StageID { get; set; }

        public int LaborID { get; set; }

        public double Volume { get; set; }
    }
}
