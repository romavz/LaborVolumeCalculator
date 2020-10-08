using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class OkrSoftwareDevLaborGroupReg : SoftwareDevLaborGroupReg
    {
        public int OkrID { get; set; }
        public Okr Okr { get; set; }
        public StageForOkr Stage { get; set; }

        public OkrSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}