using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Инфраструктурный коэффициент", GroupName = "Инфраструктурные коэффициенты")]
    public class InfrastructureComplexityRate : BasicModel
    {
        public InfrastructureComplexityRate() : base()
        {
        }

        public InfrastructureComplexityRate(string name, double value) : base(name)
        {
            Value = value;
        }

        public double Value { get; set; }
    }
}