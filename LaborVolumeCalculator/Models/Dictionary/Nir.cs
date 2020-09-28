using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "НИР", GroupName = "НИРы")]
    public class Nir : BasicModel
    {
        public Nir() : base() { }

        public Nir(string name) : base(name)
        {

        }
    }
}
