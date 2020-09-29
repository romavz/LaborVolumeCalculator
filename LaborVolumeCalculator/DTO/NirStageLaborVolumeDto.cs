namespace LaborVolumeCalculator.DTO
{
    public class NirStageLaborVolumeDto : LaborVolumeBaseDto
    {
        public NirLaborDto Labor { get; set; }
    }

    public class NirStageLaborVolumeCreateDto
    {
        public int StageID { get; set; }
        public int LaborID { get; set; }
        public double Volume { get; set; }
    }

    public class NirStageLaborVolumeChangeDto : LaborVolumeBaseDto
    {
    }
}