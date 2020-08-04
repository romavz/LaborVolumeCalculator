using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class SoftwareLaborVolumeReg : LaborVolumeReg
    {
        public SoftwareLaborVolumeReg() : base() {}

        public int SoftwareDevLaborGroupID { get; set; }

        public SoftwareDevLaborGroup SoftwareLaborDevGroup { get; set; }
    }
}
