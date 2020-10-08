using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrLaborVolumeReg : LaborVolume
    {
        public int OkrID { get; set; }
        public Okr Okr { get; set; }
        
        public StageForOkr Stage { get; set; }

        public OkrLabor Labor { get; set; }
    }
}