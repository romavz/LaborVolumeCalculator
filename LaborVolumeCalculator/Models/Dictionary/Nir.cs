using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "НИР", GroupName = "НИРы")]
    public class Nir : BasicModel
    {
        public Nir() : base() 
        { 
            this.IntensiveRateValue = 1.0;
        }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double AnalogDurationMonthes { get; set; }
        public double IntensiveRateValue { get; set; }
        public double Volume { get; set; }
        public IEnumerable<NirStage> Stages { get; set; }
    }
}
