using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Уровень покрытия тестами", GroupName = "Уровни покрытия тестами")]
    public class TestsCoverageLevel : BasicModel
    {
        public TestsCoverageLevel() : base()
        {
        }

        public TestsCoverageLevel(string name) : base(name)
        {
        }
    }
}