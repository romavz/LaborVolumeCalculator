using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirLaborVolumeReg : LaborVolumeReg
    {
        public NirLaborVolumeReg()
        {
        }

        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public NirStage Stage { get; set; }
        public NirLabor Labor { get; set; }
    }
}