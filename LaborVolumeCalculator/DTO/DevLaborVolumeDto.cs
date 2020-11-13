namespace LaborVolumeCalculator.DTO
{
    public class DevLaborVolumeDto<TLaborVolumeRangeDto> where TLaborVolumeRangeDto : class
    {
        public int ID { get; set; }
        public double Volume { get; set; }
        public TLaborVolumeRangeDto LaborVolumeRange { get; set; }
    }

    public class DevLaborVolumeDto_ListItem
    {
        public double Volume { get; set; }
        public int LaborVolumeRangeID { get; set; }
    }
}