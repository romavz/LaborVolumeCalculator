using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NiokrCategory
    {
        static NiokrCategory()
        {
            NIR = new NiokrCategory("НИР");
            OKR = new NiokrCategory("ОКР");
        }

        public static NiokrCategory NIR { get; }
        public static NiokrCategory OKR { get; }

        public NiokrCategory() { }

        public NiokrCategory(string name) => Name = name;
        
        public int ID { get; set; }

        public string Name { get; set; }
    }

}
