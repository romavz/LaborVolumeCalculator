using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Диапазон количества разнотипных устройств", GroupName = "Диапазоны количества разнотипных устройств")]
    public class DeviceCountRange
    {
        public int ID { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
