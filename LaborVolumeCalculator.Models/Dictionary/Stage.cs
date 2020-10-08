using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Этап НИОКР", GroupName ="Этапы НИОКР")]
    public class Stage
    {
        public Stage() { }

        public Stage(string name) : this()
        {
            Name = name ?? throw new ArgumentNullException("name");
        }

        public int ID { get; set; }

        public string Code { get; set; }

        [DisplayName("Называние")]
        public string Name { get; set; }
    }
}
