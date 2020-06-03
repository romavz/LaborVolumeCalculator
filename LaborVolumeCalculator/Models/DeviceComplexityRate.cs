using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Коэффициент сложности МФУ", GroupName = "Коэффициэнты сложности МФУ")]
    public class DeviceComplexityRate
    {
        public DeviceComplexityRate() { }

        public DeviceComplexityRate(DeviceComposition deviceComposition, DeviceCountRange deviceCountRange, decimal value) : this()
        {
            DeviceComposition = deviceComposition;
            DeviceCompositionID = deviceComposition.ID;

            DeviceCountRange = deviceCountRange;
            DeviceCountRangeID = deviceCountRange.ID;

            Value = value;
        }

        public int ID { get; set; }

        [DisplayName("Компановка устройства")]
        public int DeviceCompositionID { get; set; }

        [DisplayName("Компановка устройства")]
        public DeviceComposition DeviceComposition { get; set; }

        [DisplayName("Количество разнотипных устройств")]
        public int DeviceCountRangeID { get; set; }

        [DisplayName("Количество разнотипных устройств")]
        public DeviceCountRange DeviceCountRange { get; set; }

        [DisplayName("Значение")]
        public decimal Value { get; set; }
    }
}
