namespace LaborVolumeCalculator.DTO
{
    public class SoftwareDevEnvCreateDto
    {
        public string Name { get; set; }
    }

    public class SoftwareDevEnvChangeDto : SoftwareDevEnvCreateDto
    {
        public int ID { get; set; }
    }

    public class SoftwareDevEnvDto : SoftwareDevEnvChangeDto
    {
    }

}