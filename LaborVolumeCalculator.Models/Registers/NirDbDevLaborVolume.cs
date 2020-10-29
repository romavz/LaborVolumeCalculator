using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class NirDbDevLaborVolume : DevLaborVolume<DbDevLaborVolumeRange>
    {
        public NirStageSoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }

    }
}