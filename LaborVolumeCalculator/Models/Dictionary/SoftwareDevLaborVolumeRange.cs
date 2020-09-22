namespace LaborVolumeCalculator.Models.Dictionary
{
    public class SoftwareDevLaborVolumeRange : LaborVolumeRange
    {
        public SoftwareDevLaborVolumeRange()
        {
        }

        public SoftwareDevLaborVolumeRange( SoftwareDevLabor labor, SoftwareDevEnv softwareDevEnv, double minVolume, double maxVolume) : base(minVolume, maxVolume)
        {
            SoftwareDevEnv = softwareDevEnv;
            SoftwareDevEnvID = softwareDevEnv?.ID ?? 0;
            Labor = labor;
        }

        public SoftwareDevLabor Labor { get; set; }
        public int SoftwareDevEnvID { get; set; }
        public SoftwareDevEnv SoftwareDevEnv { get; set; }
    }
}