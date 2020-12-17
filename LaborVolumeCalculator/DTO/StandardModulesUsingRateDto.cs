namespace LaborVolumeCalculator.DTO
{
    public class StandardModulesUsingRateDto : StandardModulesUsingRateCreateDto
    {
        public int ID { get; set; }
    }

    public class StandardModulesUsingRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}