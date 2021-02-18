using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Микроархитектура компонент", GroupName = "Микроархитектуры компонент")]
    public class ComponentsMicroArchitecture : BasicModel
    {
        public ComponentsMicroArchitecture() : base()
        {
        }

        public ComponentsMicroArchitecture(string name, int code) : base(name)
        {
            this.Code = code;
        }

        public int Code { get; set; }
    }
}