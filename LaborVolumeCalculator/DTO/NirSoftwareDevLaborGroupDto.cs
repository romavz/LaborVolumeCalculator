namespace LaborVolumeCalculator.DTO
{
    public class NirSoftwareDevLaborGroupDto : NirSoftwareDevLaborGroupCreateDto
    {
        public int ID { get; set; }
    }

    public class NirSoftwareDevLaborGroupCreateDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}