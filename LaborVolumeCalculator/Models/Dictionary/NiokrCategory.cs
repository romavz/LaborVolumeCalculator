using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NiokrCategory
    {
        public NiokrCategory() { }

        public NiokrCategory(string name) => Name = name;
        
        public int ID { get; set; }

        public string Name { get; set; }
    }

}
