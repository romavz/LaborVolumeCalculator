namespace LaborVolumeCalculator.DTO
{
    public class StageLaborVolumeDto
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public LaborDto Labor { get; set; }
    }

    public class StageLaborVolumeDto_ListItem
    {
        public int LaborID { get; set; }
        public double Volume { get; set; }
    }
}