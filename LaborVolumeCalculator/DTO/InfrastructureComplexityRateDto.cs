namespace LaborVolumeCalculator.DTO
{
    public class InfrastructureComplexityRateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class InfrastructureComplexityRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}