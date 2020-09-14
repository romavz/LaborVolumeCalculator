namespace LaborVolumeCalculator.DTO
{
    public class NirLaborVolumeRegDto : LaborVolumeRegDto
    {
        public int NirID { get; set; }
        public int StageID { get; set; }

        public int LaborID { get; set; }
        public NirLaborDto Labor { get; set; }
    }
}