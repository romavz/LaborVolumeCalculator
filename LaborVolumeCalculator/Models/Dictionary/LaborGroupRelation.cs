using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class LaborGroupRelation
    {

        public int ID { get; set; }

        public int LaborGroupId { get; set; }
        public LaborGroup LaborGroup { get; set; }

        public int? ParentGroupId { get; set; }
        public LaborGroup ParentGroup { get; set; }
    }
}
