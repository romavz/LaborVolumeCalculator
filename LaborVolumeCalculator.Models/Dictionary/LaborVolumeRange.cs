namespace LaborVolumeCalculator.Models.Dictionary
{
    public class LaborVolumeRange : IIdentable
    {
        public LaborVolumeRange()
        {
        }

        public LaborVolumeRange(DevelopmentLabor labor, RangeFeature rangeFeature, double minVolume, double maxVolume)
        {
            this.Labor = labor;
            this.LaborID = labor?.ID ?? 0;
            this.RangeFeature = rangeFeature;
            this.RangeFeatureID = rangeFeature?.ID ?? 0;
            this.MinVolume = minVolume;
            this.MaxVolume = maxVolume;
        }
        
        public int ID { get; set; }
        public int LaborID { get; set; }
        public DevelopmentLabor Labor { get; set; }

        public int RangeFeatureID { get; set; }
        public RangeFeature RangeFeature { get; set; }

        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }

    }
}