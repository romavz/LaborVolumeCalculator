using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Коэффициент сложности разработки тестов", GroupName = "Коэффициенты сложности разработки тестов")]
    public class TestsDevelopmentRate : IIdentable
    {
        public TestsDevelopmentRate()
        {
        }

        public TestsDevelopmentRate(ComponentsMicroArchitecture componentsMicroArchitecture, TestsScale testsScale, TestsCoverageLevel testsCoverageLevel, double value)
        {
            ComponentsMicroArchitecture = componentsMicroArchitecture;
            ComponentsMicroArchitectureID = componentsMicroArchitecture?.ID ?? 0;
            TestsScale = testsScale;
            TestsScaleID = testsScale?.ID ?? 0;
            TestsCoverageLevel = testsCoverageLevel;
            TestsCoverageLevelID = testsCoverageLevel?.ID ?? 0;
            Value = value;
        }

        public int ID { get; set; }
        
        [DisplayName("Значение")]
        public double Value { get; set; }

        public int ComponentsMicroArchitectureID { get; set; }
        public ComponentsMicroArchitecture ComponentsMicroArchitecture { get; set; }

        public int TestsScaleID { get; set; }
        public TestsScale TestsScale { get; set; }

        public int TestsCoverageLevelID { get; set; }
        public TestsCoverageLevel TestsCoverageLevel { get; set; }
    }
}