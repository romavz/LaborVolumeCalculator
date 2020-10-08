using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты НИР", GroupName = "Трудозатраты НИР")]
    public class NirLabor : Labor

    {
        public NirLabor() : base() { }


        public NirLabor(string code, string name, float minVolume, float maxVolume) : base(code, name, minVolume, maxVolume)
        {
        }
    }
}
