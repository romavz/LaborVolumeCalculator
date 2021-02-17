using System;
using System.Collections.Generic;

namespace LaborVolumeCalculator.DTO
{
    public class NirCreateDto
    {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double AnalogDurationMonthes { get; set; }
        public double IntensiveRateValue { get; set; }
        public double Volume { get; set; }
    }

    public class NirChangeDto : NirCreateDto
    {
        public int ID { get; set; }
        public bool IsFinished { get; set; }
    }

    public class NirDto : NirChangeDto
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public List<NirStageDto> Stages { get; set; }
    }

}