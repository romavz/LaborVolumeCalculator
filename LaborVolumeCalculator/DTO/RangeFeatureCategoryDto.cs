using System.Collections.Generic;

namespace LaborVolumeCalculator.DTO
{
    public class RangeFeatureCategoryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class RangeFeatureCategoryCreateDto
    {
        public string Name { get; set; }
    }

    public class RangeFeatureCategoryFullDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<RangeFeatureDto_ListItem> RangeFeatures { get; set; }
    }

    public class RangeFeatureCategoryFullCreateDto
    {
        public string Name { get; set; }
        public List<RangeFeatureCreateDto_ListItem> RangeFeatures { get; set; }
    }
}