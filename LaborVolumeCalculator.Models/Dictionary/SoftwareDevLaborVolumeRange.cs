namespace LaborVolumeCalculator.Models.Dictionary
{
    public class SoftwareDevLaborVolumeRange : LaborVolumeRange
    {
        public SoftwareDevLaborVolumeRange()
        {
        }

        public SoftwareDevLaborVolumeRange( SoftwareDevLabor labor, SoftwareDevEnv softwareDevEnv, double minVolume, double maxVolume) : base(minVolume, maxVolume)
        {
            DevEnv = softwareDevEnv;
            DevEnvID = softwareDevEnv?.ID ?? 0;
            Labor = labor;
        }

        public SoftwareDevLabor Labor { get; set; }
        public int DevEnvID { get; set; }
        public SoftwareDevEnv DevEnv { get; set; }
    }
}