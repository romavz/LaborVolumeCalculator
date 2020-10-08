using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты на разработку АЧ", GroupName = "Трудозатраты на разработку АЧ")]
    public class HardwareDevLabor : DevelopmentLabor
    {
        public HardwareDevLabor()
        {
        }

        public HardwareDevLabor(string code, string name, DevelopmentLaborCategory laborCategory)
            : base(code, name, laborCategory)
        {
        }
    }
}
