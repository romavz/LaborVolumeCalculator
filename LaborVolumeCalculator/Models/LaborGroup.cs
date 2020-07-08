using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Display( Name = "Группа работ", GroupName = "Группы работ")]
    public class LaborGroup
    {
        public LaborGroup() { }

        public LaborGroup(int? id, string code, string name)
        {
            ID = id;
            Code = code;
            Name = name;
        }


        private static LaborGroup _rootGroup = new LaborGroup(null, "000", "..");
        public static LaborGroup RootGroup => _rootGroup;

        public int? ID { get; set; }

        public int? ParentGroupId { get; set; }
        [Display(Name = "Родительская группа")]
        public LaborGroup ParentGroup { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }


    }
}
