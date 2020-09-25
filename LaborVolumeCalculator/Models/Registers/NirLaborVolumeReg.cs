using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirLaborVolumeReg : LaborVolume
    {
        public NirLaborVolumeReg()
        {
        }

        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public StageForNir Stage { get; set; }
        public NirLabor Labor { get; set; }
    }
}