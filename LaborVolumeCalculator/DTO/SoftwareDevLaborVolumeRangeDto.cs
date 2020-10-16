using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO
{
    /// <summary>
    /// SoftwareDevLaborVolumeRangeDto
    /// </summary>
    public class SoftwareDevLaborVolumeRangeDto : LaborVolumeRangeDto
    {
        public SoftwareDevEnvDto DevEnv { get; set; }
    }
}