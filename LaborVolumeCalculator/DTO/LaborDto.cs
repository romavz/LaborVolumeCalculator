namespace LaborVolumeCalculator.DTO
{
    public class LaborDto
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float MinVolume { get; set; }
        public float MaxVolume { get; set; }
    }
}