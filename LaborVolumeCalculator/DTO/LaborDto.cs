namespace LaborVolumeCalculator.DTO
{
    public class LaborDto
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
    }
}