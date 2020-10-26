using System;
using System.Collections.Generic;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Okr
{
    internal class InnovationRatesBinder
    {

        public InnovationRatesBinder(DeviceComposition deviceComposition, IEnumerable<OkrInnovationProperty> okrInnovationProperties)
        {
            this.deviceComposition = deviceComposition ?? throw new ArgumentNullException("deviceComposition");
            this.okrInnovationProperties = okrInnovationProperties ?? throw new ArgumentNullException("okrInnovationProperties");
        }

        private readonly DeviceComposition deviceComposition;
        private readonly IEnumerable<OkrInnovationProperty> okrInnovationProperties;

        public IEnumerable<OkrInnovationRate> Bind(IEnumerable<double> rateValues)
        {
            List<OkrInnovationRate> rates = new List<OkrInnovationRate>();
            IEnumerator<OkrInnovationProperty> innovationProperties = okrInnovationProperties.GetEnumerator();
            innovationProperties.MoveNext();

            foreach (var rateValue in rateValues)
            {
                rates.Add(new OkrInnovationRate(innovationProperties.Current, deviceComposition, rateValue));
                innovationProperties.MoveNext();
            }

            return rates;
        }
    }
}