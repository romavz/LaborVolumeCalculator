using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class DevelopmentLaborsContainer
    {
        private readonly DevelopmentLabor[] softLabors;
        public DevelopmentLaborsContainer(DevelopmentLabor[] softLabors)
        {
            this.softLabors = softLabors;
        }

        public DevelopmentLabor this[int code]
        {
            get
            {
                return softLabors.FirstOrDefault(m => m.Code == code.ToString());
            }
        }
    }
}