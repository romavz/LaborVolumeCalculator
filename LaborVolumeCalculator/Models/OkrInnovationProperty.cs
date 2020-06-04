using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Свойство новизны ОКР", GroupName = "Свойства новизны ОКР")]
    public class OkrInnovationProperty
    {

        public OkrInnovationProperty() { }
        
        public OkrInnovationProperty(string name): this()
        {
            Name = name;
        }

        public int ID { get; set; }

        [DisplayName("Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Название должно содержать символы")]
        public string Name { get; set; }
    }
}
