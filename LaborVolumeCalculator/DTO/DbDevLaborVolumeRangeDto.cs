namespace LaborVolumeCalculator.DTO
{
    public class DbDevLaborVolumeRangeDto : LaborVolumeRangeDto
    {
        public DbEntityCountRangeDto DbEntityCountRange { get; set; }
    }

    public class DbDevLaborVolumeRangeCreateDto : LaborVolumeRangeCreateDto
    {
        public int DbEntityCountRangeID { get; set; }
    }

    public class DbDevLaborVolumeRangeChangeDto : DbDevLaborVolumeRangeCreateDto
    {
        public int ID { get; set; }
    }
}