using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозартраты на разработку БД", GroupName = "Трудозатраты на разработку БД")]
    public class DbDevLabor : DevelopmentLabor
    {
        public DbDevLabor() { }

        public DbDevLabor(string code, string name, LaborCategory laborCategory, DbEntityCountRange dbEntityCountRange, float minVolume, float maxVolume) 
            : base(code, name, laborCategory, minVolume, maxVolume)
        {
            DbEntityCountRange = dbEntityCountRange ?? throw new ArgumentNullException("dbEntityCountRange");
            DbEntityCountRangeId = dbEntityCountRange.ID;
        }

        public int DbEntityCountRangeId { get; set; }

        [Display(Name ="Количество сущностей БД")]
        public DbEntityCountRange DbEntityCountRange { get; set; }

    }
}
