using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Коэффициент новизны ОКР", GroupName = "Коэффициенты новозны ОКР")]
    public class OkrInnovationRate
    {
        public OkrInnovationRate() { }

        public OkrInnovationRate(OkrInnovationProperty okrInnovationProperty, DeviceComposition deviceComposition, double value): this()
        {
            OkrInnovationProperty = okrInnovationProperty;
            OkrInnovationPropertyID = okrInnovationProperty.ID;

            DeviceComposition = deviceComposition;
            DeviceCompositionID = deviceComposition.ID;
            Value = value;
        }

        public int ID { get; set; }

        [Display(Name = "Свойство новизны ОКР")]
        public int OkrInnovationPropertyID { get; set; }

        [Display(Name = "Свойство новизны ОКР")]
        public OkrInnovationProperty OkrInnovationProperty { get; set; }

        [Display(Name = "Тип устройства")]
        public int DeviceCompositionID { get; set; }

        [Display(Name = "Тип устройства")]
        public DeviceComposition DeviceComposition { get; set; }

        [DisplayName("Значение")]
        public double Value { get; set; }
    }
}
