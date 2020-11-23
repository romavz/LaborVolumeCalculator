using System.Collections.Generic;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageSoftwareDevLaborGroup : StageSoftwareDevLaborGroup
    {
        public NirStage Stage { get; set; }

        public NirSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
        public List<NirDevelopmentLaborVolume> LaborVolumes { get; set; }
    }
}