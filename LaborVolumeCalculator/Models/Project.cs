using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Display(Name = "Проект", GroupName = "Проекты")]
    public class Project : BasicModel
    {
        public Project() : base() { }

        public Project(string name) : base(name) { }
    }
}
