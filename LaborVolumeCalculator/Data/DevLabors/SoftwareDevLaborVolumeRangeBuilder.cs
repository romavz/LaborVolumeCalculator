using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class SoftwareDevLaborVolumeRangeBuilder
    {
        private SoftwareDevLabor _labor;

        public SoftwareDevLaborVolumeRangeBuilder(SoftwareDevLabor labor)
        {
            this._labor = labor;
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double volume)
        {
            return Create(labor, devEnv, volume, volume);
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double minVolume, double maxVolume)
        {
            this._labor = labor;
            return Create(devEnv, minVolume, maxVolume);
        }
        
        public SoftwareDevLaborVolumeRange Create(SoftwareDevEnv devEnv, double volume)
        {
            return Create(devEnv, volume, volume);
        }
        public SoftwareDevLaborVolumeRange Create(SoftwareDevEnv devEnv, double minVolume, double maxVolume)
        {
            return new SoftwareDevLaborVolumeRange(_labor, devEnv, minVolume, maxVolume);
        }
    }
}