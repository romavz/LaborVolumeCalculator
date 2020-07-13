using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="Трудозатраты на разработку ПО", GroupName = "Трудозатраты на разработку ПО")]
    public class SoftwareDevLaborVolume : LaborVolume
    {
        public SoftwareDevLaborVolume() : base() { }
        
        public SoftwareDevLaborVolume(Labor labor, SoftwareDevEnv softwareDevEnv, float minValue, float maxValue) : base(labor, minValue, maxValue)
        {
            SoftwareDevEnvId = softwareDevEnv.ID;
            SoftwareDevEnv = softwareDevEnv;
        }

        public int ID { get; set; }

        public int SoftwareDevEnvId { get; set; }
        [Display(Name ="Среда разработки ПО")]
        public SoftwareDevEnv SoftwareDevEnv { get; set; }
    }
}
