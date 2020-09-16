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

        public StandardModulesUsingRate(string name, double value) : base(name)
        {
            Value = value;
        }

        [DisplayName("Значение")]
        public double Value { get; set; }
    }
}