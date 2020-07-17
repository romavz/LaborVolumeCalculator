using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NirProperties
    {
        public int ID { get; set; }

        public int NiokrID { get; set; }

        public Niokr Niokr { get; set; }

        public int NirInnovationPropertyID { get; set; }

        public NirInnovationProperty NirInnovationProperty { get; set; }

        public int NirScaleID { get; set; }

        public NirScale NirScale { get; set; }
    }
}
