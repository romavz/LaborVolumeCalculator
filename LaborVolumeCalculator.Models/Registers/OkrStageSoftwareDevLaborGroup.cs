using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrStageSoftwareDevLaborGroup : StageSoftwareDevLaborGroup
    {
        public OkrStage Stage { get; set; }

        public OkrSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}