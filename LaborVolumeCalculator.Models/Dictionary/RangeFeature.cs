namespace LaborVolumeCalculator.Models.Dictionary
{
        public class RangeFeature
    {
        public RangeFeature()
        {
        }

        public RangeFeature(string name, RangeFeatureCategory category)
        {
            Name = name;
            Category = category;
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public int RangeFeatureCategoryID { get; set; }
        public RangeFeatureCategory Category { get; set; }
    }
}