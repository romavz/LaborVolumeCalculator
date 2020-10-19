using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageOntdLaborVolume : LaborVolumeBase
    {
        public NirStage Stage { get; set; }
        public OntdLabor Labor { get; set; }
    }
}