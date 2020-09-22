namespace LaborVolumeCalculator.DTO
{
    public class NirLaborVolumeRegDto : LaborVolumeRegDto
    {
        public int NirID { get; set; }
        public NirLaborDto Labor { get; set; }
    }
}