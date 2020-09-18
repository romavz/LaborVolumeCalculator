using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="Трудозатраты на разработку ПО", GroupName = "Трудозатраты на разработку ПО")]
    public class SoftwareDevLabor : DevelopmentLabor
    {
        public SoftwareDevLabor() : base() { }
        
        public SoftwareDevLabor(string code, string name, LaborCategory laborCategory)
            : base(code, name, laborCategory)
        {
        }
    }
}
