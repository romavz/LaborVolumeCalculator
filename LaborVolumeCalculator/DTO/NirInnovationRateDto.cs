namespace LaborVolumeCalculator.DTO
{
    public class NirInnovationRateDto
    {
        public int ID { get; set; }
        public int NirScaleID { get; set; }

        public int NirInnovationPropertyID { get; set; }
        
        public string NirScaleName { get; set; }

        public string NirInnovationPropertyName { get; set; }

        public double Value { get; set; }

    }
}