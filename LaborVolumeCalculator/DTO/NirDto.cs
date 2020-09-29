using System;

namespace LaborVolumeCalculator.DTO
{
    public class NirCreateDto
    {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int AnalogDurationMonthes { get; set; }
        public double IntensiveRateValue { get; set; }
    }

    public class NirDto : NirCreateDto
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public double LaborsVolume { get; set; }
    }
}