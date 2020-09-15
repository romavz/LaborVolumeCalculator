namespace LaborVolumeCalculator.DTO
{
    public class NirStageRegDto
    {
        public int ID { get; set; }
        public int NirID { get; set; }
        public int StageID { get; set; }
        public NirStageDto Stage { get; set; }
    }
}