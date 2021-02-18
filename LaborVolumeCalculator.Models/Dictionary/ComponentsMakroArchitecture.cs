using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Макроархитектура компонент", GroupName = "Макроархитектуры компонент")]
    public class ComponentsMakroArchitecture : BasicModel
    {
        public ComponentsMakroArchitecture() : base()
        {
        }

        public ComponentsMakroArchitecture(string name, int code) : base(name)
        {
            this.Code = code;
        }

        public int Code { get; set; }
    }
}