﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Description("Коэффициенты новизны НИР")]
    public class NirInnovationRate
    {
        public NirInnovationRate()
        {
            CreateTime = DateTime.Now;
        }

        public NirInnovationRate(Nir nir, NirInnovationProperty innovationProperty, decimal value):this()
        {
            Nir = nir;
            NirID = nir.ID;
            NirInnovationProperty = innovationProperty;
            NirInnovationPropertyID = innovationProperty.ID;
            Value = value;
        }

        [DisplayName("НИР")]
        public int NirID { get; set; }

        [DisplayName("НИР")]
        public Nir Nir { get; set; }

        [DisplayName("Свойство новизны НИР")]
        public int NirInnovationPropertyID { get; set; }

        [DisplayName("Свойство новизны НИР")]
        public NirInnovationProperty NirInnovationProperty { get; set; }
        
        [DisplayName("Значение")]
        [Column(TypeName = "DECIMAL(8, 4)")]
        public decimal Value { get; set; }
     
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата создания")]
        public DateTime CreateTime { get; set; }
    }
        
}
