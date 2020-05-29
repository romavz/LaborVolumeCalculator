using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace LaborVolumeCalculator.Models
{
    [Description("РЭУ, СРЭУ, РЭФУ")]
    [Display(Name = "Компоновка устройства")]
    public class DeviceComposition
    {
        public DeviceComposition() { }
        public DeviceComposition(string name)
        {
            Name = name;
        }

        public int ID { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
