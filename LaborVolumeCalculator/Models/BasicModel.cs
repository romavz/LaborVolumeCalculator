using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    public class BasicModel
    {
        public BasicModel()
        {
            CreateTime = DateTime.Now;
            UpdateTime = CreateTime;
        }

        public BasicModel(string name):this()
        {
            Name = name;
        }

        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Название должно содержать символы")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Display(Name="Дата создания")]
        public DateTime CreateTime { get; set; }
        
        [Display(Name="Дата изменения")]
        public DateTime UpdateTime { get; set; }
    }
}
