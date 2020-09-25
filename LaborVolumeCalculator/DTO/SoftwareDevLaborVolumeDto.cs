namespace LaborVolumeCalculator.DTO
{
    public class SoftwareDevLaborVolumeDto : LaborVolumeBaseDto
    {
        public int SoftwareDevLaborGroupID { get; set; }

        public int LaborVolumeRangeID { get; set; }
        public SoftwareDevLaborVolumeRangeDto LaborVolumeRange { get; set; }
    }
}