using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class SoftwareDevLaborVolume
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public int SoftwareDevLaborGroupID { get; set; }

        public int LaborVolumeRangeID { get; set; }
        public SoftwareDevLaborVolumeRange LaborVolumeRange { get; set; }
    }
}
