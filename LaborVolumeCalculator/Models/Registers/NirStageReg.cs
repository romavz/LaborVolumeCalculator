using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageReg
    {
        public int ID { get; set; }
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public int StageID { get; set; }
        public StageForNir Stage { get; set; }
    }
}