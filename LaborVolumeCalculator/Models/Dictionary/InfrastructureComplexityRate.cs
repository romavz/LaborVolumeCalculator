using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Инфраструктурный коэффициент", GroupName = "Инфраструктурные коэффициенты")]
    public class InfrastructureComplexityRate : BasicModel
    {
        public InfrastructureComplexityRate() : base()
        {
        }

        public InfrastructureComplexityRate(string name, float value) : base(name)
        {
            Value = value;
        }

        public float Value { get; set; }
    }
}