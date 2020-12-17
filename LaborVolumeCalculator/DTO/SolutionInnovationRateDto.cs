namespace LaborVolumeCalculator.DTO
{
    public class SolutionInnovationRateDto : SolutionInnovationRateCreateDto
    {
        public int ID { get; set; }
    }

    public class SolutionInnovationRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}