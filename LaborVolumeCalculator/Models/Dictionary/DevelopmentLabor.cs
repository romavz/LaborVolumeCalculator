using System;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class DevelopmentLabor
    {

        public DevelopmentLabor()
        {
        }

        public DevelopmentLabor(string code, string name, LaborCategory laborCategory) 
        {
            Code = code;
            Name = name;
            LaborCategory = laborCategory ?? throw new ArgumentNullException("laborCategory");
            LaborCategoryID = laborCategory.ID;
        }

        public int ID { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public int LaborCategoryID { get; set; }
        public LaborCategory LaborCategory { get; set; }
    }
}