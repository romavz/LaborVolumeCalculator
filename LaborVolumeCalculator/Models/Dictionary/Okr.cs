using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class Okr : BasicModel
    {
        public Okr()
        {
        }

        public Okr(string name) : base(name)
        {
        }

        public int OkrInnovationPropertyID { get; set; }

        public OkrInnovationProperty OkrInnovationProperty { get; set; }

        public int DeviceCompositionID { get; set; }

        public DeviceComposition DeviceComposition { get; set; }

        public int DeviceCountRangeID { get; set; }

        public DeviceCountRange DeviceCountRange { get; set; }

        public int OkrInnovationRateID { get; set; }
        public OkrInnovationRate OkrInnovationRate { get; set; }

        public int DeviceComplexityRateID { get; set; }
        public DeviceComplexityRate DeviceComplexityRate { get; set; }
    }
}
