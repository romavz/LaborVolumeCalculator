using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class DevelopmentLaborVolumeRangeBuilder
    {

        public DevelopmentLaborVolumeRangeBuilder()
        {
        }

        public RangeFeature RangeFeature { get; private set; }

        public DevelopmentLaborVolumeRangeBuilder SetRangeFeature(RangeFeature rangeFeature)
        {
            RangeFeature = rangeFeature;
            return this;
        }
        public DevelopmentLabor Labor { get; private set; }

        public DevelopmentLaborVolumeRangeBuilder SetLabor(DevelopmentLabor labor)
        {
            this.Labor = labor;
            return this;
        }

        public LaborVolumeRange Create(RangeFeature feature, double volume)
        {
            return Create(feature, volume, volume);
        }

        public LaborVolumeRange Create(RangeFeature feature, double minVolume, double maxVolume)
        {
            return new LaborVolumeRange(Labor, feature, minVolume, maxVolume);
        }

        public LaborVolumeRange Create(DevelopmentLabor labor, double volume)
        {
            return Create(labor, volume, volume);
        }

        public LaborVolumeRange Create(DevelopmentLabor labor, double minVolume, double maxVolume)
        {
            return new LaborVolumeRange(labor, RangeFeature, minVolume, maxVolume);
        }
    }
}