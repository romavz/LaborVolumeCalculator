using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirSoftwareDevLaborVolume : SoftwareDevLaborVolume
    {
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public StageForNir Stage { get; set; }
    }
}