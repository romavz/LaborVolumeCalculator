using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "НИОКР", GroupName = "НИОКРы")]
    public class Niokr : BasicModel
    {
        public Niokr() : base() { }
        public Niokr(string name) : base(name)
        {
            //NiokrCategory = niokrCategory ?? throw new ArgumentNullException("niokrCategory");
            //NiokrCategoryID = niokrCategory.ID;
        }

        //public int NiokrCategoryID { get; set; }
        
        //[DisplayName("Категория")]
        public virtual string NiokrCategory { get; set; }

        
    }
}