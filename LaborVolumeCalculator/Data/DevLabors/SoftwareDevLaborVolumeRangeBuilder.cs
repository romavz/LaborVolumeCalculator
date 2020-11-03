using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class SoftwareDevLaborVolumeRangeBuilder
    {
        private SoftwareDevEnv _devEnv;

        public SoftwareDevLaborVolumeRangeBuilder(SoftwareDevEnv devEnv)
        {
            _devEnv = devEnv;
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double volume)
        {
            return Create(labor, devEnv, volume, volume);
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double minVolume, double maxVolume)
        {
            this._devEnv = devEnv;
            return Create(labor, minVolume, maxVolume);
        }
        
        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, double volume)
        {
            return Create(labor, volume, volume);
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, double minVolume, double maxVolume)
        {
            return new SoftwareDevLaborVolumeRange(labor, _devEnv, minVolume, maxVolume);
        }
    }
}