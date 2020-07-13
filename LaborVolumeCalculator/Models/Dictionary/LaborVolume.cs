using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты", GroupName = "Трудозатраты")]
    public class LaborVolume
    {
        public LaborVolume() { }

        public LaborVolume(Labor labor, float minValue, float maxValue) : this()
        {
            LaborId = labor.ID;
            Labor = labor;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int LaborId { get; set; }
        [Display(Name = "Работа")]
        public Labor Labor { get; set; }

        [Display(Name = "Минимум")]
        public float MinValue { get; set; }

        [Display(Name = "Маскимум")]
        public float MaxValue { get; set; }

    }
}
