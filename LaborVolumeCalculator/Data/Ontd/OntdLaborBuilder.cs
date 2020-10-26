using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Ontd
{
    public class OntdLaborBuilder
    {
        public OntdLabor Create(int code, string name, double minVolume, double maxVolume)
        {
            return new OntdLabor(code.ToString(), name, minVolume, maxVolume);
        }

        public OntdLabor Create(int code, string name, double volume)
        {
            return Create(code, name, volume, volume);
        }
    }
}