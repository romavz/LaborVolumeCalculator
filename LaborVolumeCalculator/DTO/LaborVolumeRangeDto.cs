namespace LaborVolumeCalculator.DTO
{
    public class LaborVolumeRangeBaseDto
    {       
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
    }

    public class LaborVolumeRangeDto : LaborVolumeRangeBaseDto
    {
        public int ID { get; set; }
        public DevelopmentLaborDto Labor { get; set; }
        public RangeFeatureDto RangeFeature { get; set; }
    }

    public class LaborVolumeRangeCreateDto : LaborVolumeRangeBaseDto
    {
        public int LaborID { get; set; }
        public int RangeFeatureID { get; set; }
    }

    public class LaborVolumeRangeChangeDto : LaborVolumeRangeCreateDto
    {
        public int ID { get; set; }
    }
}