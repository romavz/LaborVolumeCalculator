using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NiokrStage
    {
        public NiokrStage() { }

        public NiokrStage(string name, NiokrCategory niokrCategory)
        {
            Name = name ?? throw new ArgumentNullException("name");
            NiokrCategory = niokrCategory ?? throw new ArgumentNullException("niokrCategory");
            NiokrCategoryID = niokrCategory.ID;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int NiokrCategoryID { get; set; }
        public NiokrCategory NiokrCategory { get; set; }
    }
}
