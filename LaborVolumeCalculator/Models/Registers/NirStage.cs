using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStage
    {
        public int ID { get; set; }
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
    }
}