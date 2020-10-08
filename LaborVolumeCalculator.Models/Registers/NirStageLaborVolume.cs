using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirStageLaborVolume
    {
        public NirStageLaborVolume()
        {
        }

        public int ID { get; set; }
        public int StageID { get; set; }

        public double Volume { get; set; }

        public int LaborID { get; set; }
        public NirStage Stage { get; set; }
        public NirLabor Labor { get; set; }
    }
}