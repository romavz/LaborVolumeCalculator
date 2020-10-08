using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageLaborVolume : LaborVolumeBase
    {
        public NirStage Stage { get; set; }
        public NirLabor Labor { get; set; }
    }
}