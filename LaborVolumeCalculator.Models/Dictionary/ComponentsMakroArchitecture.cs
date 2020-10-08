using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Макроархитектура компонент", GroupName = "Макроархитектуры компонент")]
    public class ComponentsMakroArchitecture : BasicModel
    {
        public ComponentsMakroArchitecture() : base()
        {
        }

        public ComponentsMakroArchitecture(string name) : base(name)
        {
        }
    }
}