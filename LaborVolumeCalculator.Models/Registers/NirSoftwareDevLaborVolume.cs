using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirSoftwareDevLaborVolume : DevLaborVolume<SoftwareDevLaborVolumeRange>
    {
        public NirStageSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }
    }
}