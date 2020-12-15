namespace LaborVolumeCalculator.DTO
{
    public class DevLaborVolumeDto
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public LaborVolumeRangeDto LaborVolumeRange { get; set; }
    }

    public class DevLaborVolumeCreateDto
    {
        public double Volume { get; set; }
        public int LaborVolumeRangeID { get; set; }
    }
}