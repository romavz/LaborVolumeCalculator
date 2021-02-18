namespace LaborVolumeCalculator.DTO
{
    public class ComponentsMicroArchitectureDto : BaseModelDto
    {
        public int Code { get; set; }
    }

    public class ComponentsMicroArchitectureCreateDto
    {
        public int Code { get; set; }
        public string Name { get; set ;}
    }
}