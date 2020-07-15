using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозартраты на разработку БД", GroupName = "Трудозатраты на разработку БД")]
    public class DbDevLaborVolume : LaborVolume
    {
        public DbDevLaborVolume() { }

        public DbDevLaborVolume(Labor labor, DbEntityCountRange dbEntityCountRange, float minValue, float maxValue) : base(labor, minValue, maxValue)
        {
            DbEntityCountRangeId = dbEntityCountRange.ID;
            DbEntityCountRange = dbEntityCountRange;
        }

        public int ID { get; set; }

        public int DbEntityCountRangeId { get; set; }

        [Display(Name ="Количество сущностей БД")]
        public DbEntityCountRange DbEntityCountRange { get; set; }

    }
}
