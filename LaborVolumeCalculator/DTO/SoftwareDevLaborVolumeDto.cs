namespace LaborVolumeCalculator.DTO
{
    public class SoftwareDevLaborVolumeDto
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public SoftwareDevLaborVolumeRangeDto LaborVolumeRange { get; set; }
    }

    public class SoftwareDevLaborVolumeDto_ListItem
    {
        public double Volume { get; set; }
        public int LaborVolumeRangeID { get; set; }
    }
}