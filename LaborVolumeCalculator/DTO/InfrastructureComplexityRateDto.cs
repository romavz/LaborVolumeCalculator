namespace LaborVolumeCalculator.DTO
{
    public class InfrastructureComplexityRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class InfrastructureComplexityRateDto : InfrastructureComplexityRateCreateDto
    {
        public int ID { get; set; }
    }
}