namespace LaborVolumeCalculator.DTO
{
    public class NirLaborVolumeRegDto : LaborVolumeDto
    {
        public int NirID { get; set; }
        public NirLaborDto Labor { get; set; }
    }
}