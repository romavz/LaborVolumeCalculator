using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    public class NirInnovationRate : BasicModel
    {
        public int NirID { get; set; }
        public int NirInnovationPropertyID { get; set; }
        [DisplayName("Значение")]
        [Column(TypeName = "DECIMAL(6, 4)")]
        public decimal Value { get; set; }
    }
}
