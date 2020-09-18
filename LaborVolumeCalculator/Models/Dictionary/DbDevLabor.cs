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

        public DbDevLabor(string code, string name, LaborCategory laborCategory)
            : base(code, name, laborCategory)
        {
        }
    }
}
