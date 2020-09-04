using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Коэффициент использования стандартных модулей", GroupName = "Коэффициенты использования стандартных модулей")]
    public class StandardModulesUsingRate : BasicModel
    {
        public StandardModulesUsingRate() : base()
        {
        }

        public StandardModulesUsingRate(string name, float value) : base(name)
        {
            Value = value;
        }

        [DisplayName("Значение")]
        public float Value { get; set; }
    }
}