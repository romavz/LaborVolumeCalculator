using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrLaborVolumeReg : LaborVolume
    {
        public int OkrID { get; set; }
        public Okr Okr { get; set; }
        
        public OkrStage Stage { get; set; }

        public OkrLabor Labor { get; set; }
    }
}