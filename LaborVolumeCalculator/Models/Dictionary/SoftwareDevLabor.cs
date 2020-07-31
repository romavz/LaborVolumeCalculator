using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="Трудозатраты на разработку ПО", GroupName = "Трудозатраты на разработку ПО")]
    public class SoftwareDevLabor : Labor
    {
        public SoftwareDevLabor() : base() { }
        
        public SoftwareDevLabor(string code, string name, SoftwareDevEnv softwareDevEnv, float minVolume, float maxVolume) : base(code, name, minVolume, maxVolume)
        {
            SoftwareDevEnv = softwareDevEnv ?? throw new ArgumentNullException("softwareDevEnv");
            SoftwareDevEnvId = softwareDevEnv.ID;
        }

        public int SoftwareDevEnvId { get; set; }
        [Display(Name ="Среда разработки ПО")]
        public SoftwareDevEnv SoftwareDevEnv { get; set; }
    }
}
