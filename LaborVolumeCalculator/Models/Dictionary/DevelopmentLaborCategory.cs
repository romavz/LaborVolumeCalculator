using System.Collections.Generic;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class DevelopmentLaborCategory
    {
        public DevelopmentLaborCategory(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public int ID { get; set; }

        public int Number { get; set; }
        public string Name { get; set; }

        public IList<DevelopmentLabor> Labors { get; set; }

        public override string ToString()
        {
            return $"{Number}. {Name}";
        }
    }
}