namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NirStageDefaultLabor
    {
        public NirStageDefaultLabor()
        {
        }

        public int ID { get; set; }
        public int StageID { get; set; }
        public NirStage Stage { get; set; }

        public NirStageDefaultLabor(NirStage stage, NirLabor labor)
        {
            StageID = stage.ID;
            LaborID = labor.ID;
            Stage = stage;
            Labor = labor;
        }

        public int LaborID { get; set; }
        public NirLabor Labor { get; set; }
    }
}