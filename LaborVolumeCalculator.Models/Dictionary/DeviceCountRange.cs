using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Диапазон количества разнотипных устройств", GroupName = "Диапазоны количества разнотипных устройств")]
    public class DeviceCountRange
    {
        public DeviceCountRange() { }

        public DeviceCountRange(string name) : this() => Name = name;

        public int ID { get; set; }
        
        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Необходимо задать диапазон значений в виде строки, например, 1..5")]
        public string Name { get; set; }
    }
}
