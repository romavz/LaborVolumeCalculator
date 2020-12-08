namespace LaborVolumeCalculator.DTO
{
    public class SolutionInnovationRateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class SolutionInnovationRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}