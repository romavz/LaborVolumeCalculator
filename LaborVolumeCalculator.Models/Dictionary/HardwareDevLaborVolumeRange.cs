namespace LaborVolumeCalculator.Models.Dictionary
{
    public class HardwareDevLaborVolumeRange : LaborVolumeRange
    {
        public HardwareDevLaborVolumeRange(HardwareDevLabor labor, PlatePointsCountRange pointsCountRange, double minVolume, double maxVolume) : base(minVolume, maxVolume)
        {
            Labor = labor;
            LaborID = labor?.ID ?? 0;
            PointsCountRange = pointsCountRange;
            PointsCountRangeID = pointsCountRange?.ID ?? 0;
        }

        public HardwareDevLabor Labor { get; set; }
        public int PointsCountRangeID { get; set; }
        public PlatePointsCountRange PointsCountRange { get; set; }
    }
}