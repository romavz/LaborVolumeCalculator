using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirLaborVolumeReg : LaborVolumeReg
    {
        public int NirID { get; set; }
        public Nir Nir { get; set; }
        
        public int StageID { get; set; }
        public NirStage Stage { get; set; }

        public int LaborID { get; set; }
        public NirLabor Labor { get; set; }
    }
}