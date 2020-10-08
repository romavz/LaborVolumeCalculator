using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Архитектура взаимодействия компонент", GroupName = "Архитектуры взаимодействия компонент")]
    public class ComponentsInteractionArchitecture : BasicModel
    {
        public ComponentsInteractionArchitecture() : base()
        {
        }

        public ComponentsInteractionArchitecture(string name) : base(name)
        {
        }
    }
}