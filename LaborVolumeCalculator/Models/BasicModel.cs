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
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Название должно содержать символы")]
        [StringLength(255, ErrorMessage = "Максимальная длинна названия 255 символов")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Display(Name="Дата создания")]
        public DateTime CreateTime { get; set; }
        
        [Display(Name="Дата изменения")]
        public DateTime UpdateTime { get; set; }
    }
}
