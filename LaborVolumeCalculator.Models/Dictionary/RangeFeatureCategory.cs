namespace LaborVolumeCalculator.Models.Dictionary
{
    public class RangeFeatureCategory : IIdentable
    {
        public RangeFeatureCategory()
        {
        }

        public RangeFeatureCategory(string name)
        {
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}