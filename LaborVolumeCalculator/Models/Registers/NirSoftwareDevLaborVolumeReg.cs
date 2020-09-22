using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirSoftwareDevLaborVolumeReg : SoftwareDevLaborVolumeReg
    {
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public NirStage Stage { get; set; }
        public SoftwareDevLabor Labor { get; set; }
    }
}