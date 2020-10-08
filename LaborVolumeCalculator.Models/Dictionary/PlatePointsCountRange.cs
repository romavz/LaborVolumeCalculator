using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Диапазон количества точек на плате", GroupName = "Диапазоны количества точек на плате")]
    public class PlatePointsCountRange
    {
        public PlatePointsCountRange() { }

        public PlatePointsCountRange(string name)
        {
            Name = name;
        }

        public int ID { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
