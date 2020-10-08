using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Микроархитектура компонент", GroupName = "Микроархитектуры компонент")]
    public class ComponentsMicroArchitecture : BasicModel
    {
        public ComponentsMicroArchitecture() : base()
        {
        }

        public ComponentsMicroArchitecture(string name) : base(name)
        {
        }
    }
}