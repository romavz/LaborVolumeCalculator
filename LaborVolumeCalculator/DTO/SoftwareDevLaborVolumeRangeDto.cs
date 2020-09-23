using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO
{
    /// <summary>
    /// SoftwareDevLaborVolumeRangeDto
    /// </summary>
    public class SoftwareDevLaborVolumeRangeDto : LaborVolumeRangeDto
    {
        public string LaborCode { get; set; }
        public string LaborName { get; set; }
        public int DevEnvID { get; set; }
        public string DevEnvName { get; set; }
    }
}