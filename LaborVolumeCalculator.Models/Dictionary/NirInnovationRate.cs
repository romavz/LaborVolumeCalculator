using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name ="Коэфициент новизны НИР", GroupName ="Коэффициенты новизны НИР")]
    public class NirInnovationRate
    {
        public NirInnovationRate()
        {
            CreateTime = DateTime.Now;
        }

        public NirInnovationRate(NirScale nirScale, NirInnovationProperty innovationProperty, double value):this()
        {
            NirScale = nirScale;
            NirScaleID = nirScale.ID;
            NirInnovationProperty = innovationProperty;
            NirInnovationPropertyID = innovationProperty.ID;
            Value = value;
        }

        public int ID { get; set; }

        public int NirScaleID { get; set; }

        public NirScale NirScale { get; set; }

        public int NirInnovationPropertyID { get; set; }

        public NirInnovationProperty NirInnovationProperty { get; set; }
        
        [DisplayName("Значение")]
        public double Value { get; set; }
     
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата создания")]
        public DateTime CreateTime { get; set; }
    }
        
}
