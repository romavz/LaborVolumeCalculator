namespace LaborVolumeCalculator.DTO
{
    public class StandardModulesUsingRateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class StandardModulesUsingRateCreateDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}