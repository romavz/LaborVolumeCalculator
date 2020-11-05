using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class SoftwareDevLaborVolumeRangeBuilder
    {

        public SoftwareDevLaborVolumeRangeBuilder()
        {
        }

        public SoftwareDevEnv DevEnv { get; private set; }
        
        public SoftwareDevLaborVolumeRangeBuilder SetDevEnv(SoftwareDevEnv devEnv)
        {
            DevEnv = devEnv;
            return this;
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, double volume)
        {
            return Create(labor, volume, volume);
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, double minVolume, double maxVolume)
        {
            return new SoftwareDevLaborVolumeRange(labor, DevEnv, minVolume, maxVolume);
        }
    }
}