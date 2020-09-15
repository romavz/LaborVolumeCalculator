using System;

namespace LaborVolumeCalculator.DTO
{
    public class NirDto : BaseModelDto
    {
        public double NirInnovationRateValue { get; set; }

        public int NirInnovationPropertyID { get; set; }
        public string NirInnovationPropertyName { get; set; }

        public int NirScaleID { get; set; }
        public string NirScaleName { get; set; }

        public DateTime CreateTime { get; set; }
    }
}