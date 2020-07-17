using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class NiokrCategory : IEquatable<NiokrCategory>
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

        public bool Equals([AllowNull] NiokrCategory other)
        {
            return (other?.Name == Name); 
        }

        public static bool operator ==(NiokrCategory first, NiokrCategory second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(NiokrCategory first, NiokrCategory second)
        {
            return !first.Equals(second);
        }
    }

}
