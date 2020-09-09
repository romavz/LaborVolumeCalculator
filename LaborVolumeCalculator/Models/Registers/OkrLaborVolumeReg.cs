using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrLaborVolumeReg : LaborVolumeReg
    {
        public int OkrID { get; set; }
        public Okr Okr { get; set; }
        
        public int StageID { get; set; }
        public OkrStage Stage { get; set; }

        public int LaborID { get; set; }
        public OkrLabor Labor { get; set; }
    }
}