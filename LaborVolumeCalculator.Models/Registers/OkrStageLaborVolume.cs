using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrStageLaborVolume : LaborVolumeBase
    {
        public OkrStage Stage { get; set; }
        public OkrLabor Labor { get; set; }
    }
}