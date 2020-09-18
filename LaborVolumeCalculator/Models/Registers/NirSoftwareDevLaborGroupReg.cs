using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirSoftwareDevLaborGroupReg : SoftwareDevLaborGroupReg
    {
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        public NirStage Stage { get; set; }

        public NirSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}