using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Масштаб НИР", GroupName = "Масштабы НИР")]
    public class NirScale : BasicModel
    {
        public NirScale() : base() { }

        public NirScale(string name) : base(name) { }
    }
}
