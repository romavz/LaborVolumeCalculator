using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Комплексная работа по разработке ПО", GroupName = "Комплексные работы по разработке ПО")]
    public class SoftwareDevLaborGroup : IIdentable
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