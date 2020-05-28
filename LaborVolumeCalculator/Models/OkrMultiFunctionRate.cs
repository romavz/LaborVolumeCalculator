using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Коэффициент многофункциональности")]
    public class OkrMultiFunctionRate 
    {
        public OkrMultiFunctionRate() { }

        public OkrMultiFunctionRate(DeviceComposition deviceComposition, byte minDeviceCount, byte maxDeviceCount, decimal value) : this()
        {
            DeviceComposition = deviceComposition;
            DeviceCompositionID = deviceComposition.ID;

            MinDeviceCount = minDeviceCount;
            MaxDeviceCount = maxDeviceCount;
            Value = value;
        }

        [DisplayName("Компановка устройства")]
        public int DeviceCompositionID { get; set; }

        [DisplayName("Компановка устройства")]
        public DeviceComposition DeviceComposition { get; set; }

        [DisplayName("Минимальное количество устройств")]
        public byte MinDeviceCount { get; set; }
        
        [DisplayName("Максимальное количество устройств")]
        public byte MaxDeviceCount { get; set; }

        [DisplayName("Значение")]
        public decimal Value { get; set; }
    }
}
