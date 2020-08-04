using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Группа работ разработки ПО", GroupName = "Группы работ разработки ПО")]
    public class SoftwareDevLaborGroup
    {
        public SoftwareDevLaborGroup() { }
        public SoftwareDevLaborGroup(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public int ID { get; set; }

        [DisplayName("Код")]
        public string Code { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
    }
}