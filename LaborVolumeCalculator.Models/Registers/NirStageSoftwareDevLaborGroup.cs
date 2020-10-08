using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageSoftwareDevLaborGroup : StageSoftwareDevLaborGroup
    {
        public NirStage Stage { get; set; }

        public NirSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}