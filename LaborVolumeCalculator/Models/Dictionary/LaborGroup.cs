using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Группа работ", GroupName = "Группы работ")]
    public class LaborGroup
    {
        public LaborGroup() { Labors = new List<Labor>(); }

        public LaborGroup(string code, string name) : this()
        {
            Code = code;
            Name = name;
        }

        public LaborGroup(string code, string name, LaborGroup parentGroup) : this(code, name)
        {
            ParentGroup = parentGroup;
            ParentGroupId = parentGroup?.ID;
            Level = (ParentGroup?.Level ?? 0) + 1;
        }

        public static LaborGroup RootGroup = new LaborGroup("", "Группы работ");

        public int ID { get; set; }

        public int? ParentGroupId { get; set; }
        [Display(Name = "Родительская группа")]
        public LaborGroup ParentGroup { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public int Level { get; set; }

        public ICollection<Labor> Labors { get; set; }

        public ICollection<LaborGroupRelation> ParentGroups { get; set; }

        public static string ToString(LaborGroup laborGroup)
        {
            string parentCode = RootGroup.Code;
            string parentName = RootGroup.Name;

            if (laborGroup != null)
            {
                parentCode = laborGroup.Code;
                parentName = laborGroup.Name;
            }
            
            return String.Format("{0} {1}", parentCode, parentName);
        }

        public Labor AddLabor(Labor labor)
        {
            Labors.Add(labor);
            return labor;
        }
    }
}
