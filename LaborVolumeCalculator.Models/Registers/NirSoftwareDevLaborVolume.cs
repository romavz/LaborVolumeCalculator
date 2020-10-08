using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirSoftwareDevLaborVolume : SoftwareDevLaborVolume
    {
        public NirStageSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}