using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{

    [Display(Name ="Работа", GroupName = "Работы")]
    public class Labor
    {
        public Labor() { }

        public Labor(string code, string name) : this()
        {
            Code = code;
            Name = name;
        }

        public Labor(string code, string name, float minVolume, float maxVolume) : this(code, name)
        {
            MinVolume = minVolume;
            MaxVolume = maxVolume;
        }

        public int ID { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Минимум")]
        public float MinVolume { get; set; }

        [Display(Name = "Маскимум")]
        public float MaxVolume { get; set; }
    }
}
