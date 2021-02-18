namespace LaborVolumeCalculator.DTO
{
    public class ComponentsMacroArchitectureDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }

    public class ComponentsMacroArchitectureCreateDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}