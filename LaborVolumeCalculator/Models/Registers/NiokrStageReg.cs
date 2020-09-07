using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NiokrStageReg
    {

        public int ID { get; set; }

        public int NiokrID { get; set; }
        public Niokr Niokr { get; set;}

        public int NiokrStageID { get; set; }
        public NiokrStage NiokrStage { get; set; }

    }
}