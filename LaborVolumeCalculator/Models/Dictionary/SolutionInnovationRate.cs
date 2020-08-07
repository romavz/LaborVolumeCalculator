using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Коэффициент новизны решения", GroupName = "Коэффициенты новизны решения")]
    public class SolutionInnovationRate : BasicModel
    {
        public SolutionInnovationRate() : base() { }

        public SolutionInnovationRate(string name, float value) : base(name)
        {
            Value = value;
        }

        [DisplayName("Значение")]
        public float Value { get; set; }
    }
}