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

        public int ID { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public int LaborGroupId { get; set; }

        [Display(Name = "Группа")]
        public LaborGroup LaborGroup { get; set; }

    }
}
