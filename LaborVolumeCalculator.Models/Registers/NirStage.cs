using System;
using System.Collections.Generic;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStage
    {
        public int ID { get; set; }
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public int NirInnovationRateID { get; set; }
        public NirInnovationRate NirInnovationRate { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public double Volume { get; set; }
        public List<NirStageLaborVolume> LaborVolumes { get; set; }
    }
}