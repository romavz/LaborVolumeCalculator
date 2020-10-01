using System;
using System.Collections.Generic;

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

    public class NirChangeDto : NirCreateDto
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class NirDto : NirChangeDto
    {
        public List<NirStageDto> Stages { get; set; }
    }

}