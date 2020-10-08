using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Диапазон количества сущностей БД", GroupName = "Диапазоны колличества сущностей БД")]
    public class DbEntityCountRange
    {
        public DbEntityCountRange() { }

        public DbEntityCountRange(string name)
        {
            Name = name;
        }

        public int ID { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
