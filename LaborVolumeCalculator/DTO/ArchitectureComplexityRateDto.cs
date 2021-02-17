namespace LaborVolumeCalculator.DTO
{
    public class ArchitectureComplexityRateDto
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public int ComponentsMakroArchitectureID { get; set; }
        public string ComponentsMakroArchitectureName { get; set; }
        public string ComponentsMakroArchitectureCode { get; set; }
        public int ComponentsInteractionArchitectureID { get; set; }
        public string ComponentsInteractionArchitectureName { get; set; }
        public string ComponentsInteractionArchitectureCode { get; set; }
    }

    public class ArchitectureComplexityRateCreateDto
    {
        public double Value { get; set; }
        public int ComponentsMakroArchitectureID { get; set; }
        public int ComponentsInteractionArchitectureID { get; set; }
    }

    public class ArchitectureComplexityRateCnageDto : ArchitectureComplexityRateCreateDto
    {
        public int ID { get; set; }
    }
}