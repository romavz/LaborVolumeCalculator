namespace LaborVolumeCalculator.Models.Dictionary
{
    public class DbDevLaborVolumeRange : LaborVolumeRange
    {
        public DbDevLaborVolumeRange()
        {
        }
        public DbDevLaborVolumeRange(DbDevLabor labor, DbEntityCountRange dbEntityCountRange, double minVolume, double maxVolume) : base(minVolume, maxVolume)
        {
            Labor = labor;
            LaborID = labor?.ID ?? 0;
            DbEntityCountRange = dbEntityCountRange;
            DbEntityCountRangeID = dbEntityCountRange?.ID ?? 0;
        }

        public DbDevLabor Labor { get; set; }

        public int DbEntityCountRangeID { get; set; }
        public DbEntityCountRange DbEntityCountRange { get; set; }

        
    }
}