namespace LaborVolumeCalculator.DTO
{
    public class NirStageLaborVolumeDto
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public LaborDto Labor { get; set; }
    }

    public class NirStageLaborVolumeCreateDto
    {
        public int StageID { get; set; }
        public int LaborID { get; set; }
        public double Volume { get; set; }
    }

    public class NirStageLaborVolumeChangeDto
    {
        public int ID { get; set; }
        public int LaborID { get; set; }
        public double Volume { get; set; }
    }

    public class NirStageLaborVolumeDto_ListItem
    {
        public int LaborID { get; set; }
        public double Volume { get; set; }
    }
}