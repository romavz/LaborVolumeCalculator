using System.Collections.Generic;

namespace LaborVolumeCalculator.Models.Dictionary
{
        public class RangeFeature : IIdentable
    {
        public RangeFeature()
        {
        }

        public RangeFeature(string name, RangeFeatureCategory category)
        {
            Name = name;
            RangeFeatureCategory = category;
            RangeFeatureCategoryID = category?.ID ?? 0;
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public int RangeFeatureCategoryID { get; set; }
        public RangeFeatureCategory RangeFeatureCategory { get; set; }
    }
}