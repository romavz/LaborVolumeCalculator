using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Архитектурный коэффициент", GroupName = "Архитектурные коэффициенты")]
    public class ArchitectureComplexityRate
    {
        public ArchitectureComplexityRate()
        {
        }

        public ArchitectureComplexityRate(ComponentsMakroArchitecture componentsMakroArchitecture, ComponentsInteractionArchitecture componentsInteractionArchitecture, double value)
        {
            ComponentsMakroArchitecture = componentsMakroArchitecture;
            ComponentsMakroArchitectureID = componentsMakroArchitecture?.ID ?? 0;
            ComponentsInteractionArchitecture = componentsInteractionArchitecture;
            ComponentsInteractionArchitectureID = componentsInteractionArchitecture?.ID ?? 0;
            Value = value;
        }

        public int ID { get; set; }
        public int ComponentsMakroArchitectureID { get; set; }
        [Required]
        public ComponentsMakroArchitecture ComponentsMakroArchitecture { get; set; }

        public int ComponentsInteractionArchitectureID { get; set; }
        [Required]
        public ComponentsInteractionArchitecture ComponentsInteractionArchitecture { get; set; }

        [DisplayName("Значение")]
        public double Value { get; set; }

    }
}