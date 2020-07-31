using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозартраты на разработку БД", GroupName = "Трудозатраты на разработку БД")]
    public class DbDevLabor : Labor
    {
        public DbDevLabor() { }

        public DbDevLabor(string code, string name, DbEntityCountRange dbEntityCountRange, float minVolume, float maxVolume) : base(code, name, minVolume, maxVolume)
        {
            DbEntityCountRange = dbEntityCountRange ?? throw new ArgumentNullException("dbEntityCountRange");
            DbEntityCountRangeId = dbEntityCountRange.ID;
        }

        public int DbEntityCountRangeId { get; set; }

        [Display(Name ="Количество сущностей БД")]
        public DbEntityCountRange DbEntityCountRange { get; set; }

    }
}
