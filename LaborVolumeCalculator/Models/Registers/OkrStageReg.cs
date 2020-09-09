using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrStageReg
    {
        public int ID { get; set; }
        public int OkrID { get; set; }
        public Okr Okr { get; set; }

        public int OkrStageID { get; set; }
        public OkrStage OkrStage { get; set; }
    }
}