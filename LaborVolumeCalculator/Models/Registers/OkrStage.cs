using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrStage
    {
        public int ID { get; set; }
        public int OkrID { get; set; }
        public Okr Okr { get; set; }

        public int StageID { get; set; }
        public StageForOkr Stage { get; set; }
    }
}