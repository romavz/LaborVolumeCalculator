namespace LaborVolumeCalculator.DTO
{
    public class NirStageDto
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class NirStageCreateDto
    {
        public int NirID { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
    }
}