namespace LaborVolumeCalculator.DTO
{
    public class LaborVolumeRangeDto
    {
        public int ID { get; set; }
        public DevelopmentLaborDto Labor { get; set; }
        
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
    }
}