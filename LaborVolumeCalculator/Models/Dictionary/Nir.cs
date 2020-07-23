using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="НИР", GroupName ="НИРы")]
    public class Nir : Niokr
    {
        public Nir() : base() { }

        public Nir(string name) : base(name) { }

        public int NirInnovationRateID { get; set; }
        public NirInnovationRate NirInnovationRate { get; set; }

        public int NirInnovationPropertyID { get; set; }

        public NirInnovationProperty NirInnovationProperty { get; set; }

        public int NirScaleID { get; set; }

        public NirScale NirScale { get; set; }
    }
}
