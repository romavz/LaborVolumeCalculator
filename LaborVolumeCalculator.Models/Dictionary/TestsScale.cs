using System.ComponentModel.DataAnnotations;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Уровень тестирования", GroupName = "Уровни тестирования")]
    public class TestsScale : BasicModel
    {
        public TestsScale() : base()
        {
        }

        public TestsScale(string name, int code) : base(name)
        {
            this.Code = code;
        }

        public int Code { get; set; }
    }
}