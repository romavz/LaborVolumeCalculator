namespace LaborVolumeCalculator.DTO
{
    public class ComponentsInteractionArchitectureDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class ComponentsInteractionArchitectureCreateDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}