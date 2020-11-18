namespace LaborVolumeCalculator.DTO
{
    public class RangeFeatureDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public RangeFeatureCategoryDto Category { get; set; }
    }

    public class RangeFeatureCreateDto
    {
        public string Name { get; set; }
        public int RangeFeatureCategoryID { get; set; }
    }

    public class RangeFeatureChangeDto : RangeFeatureCategoryCreateDto
    {
        public int ID { get; set; }
    }


}