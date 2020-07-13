using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="Среда разработки ПО", GroupName ="Среды разработки ПО")]
    public class SoftwareDevEnv
    {
        public SoftwareDevEnv() { }

        public SoftwareDevEnv(string name) : this()
        {
            Name = name;
        }

        public int ID { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
