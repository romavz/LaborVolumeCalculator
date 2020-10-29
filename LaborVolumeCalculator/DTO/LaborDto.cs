namespace LaborVolumeCalculator.DTO
{
    public class LaborCreateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
    }

    public class LaborDto : LaborCreateDto
    {
        public int ID { get; set; }
        
    }
}