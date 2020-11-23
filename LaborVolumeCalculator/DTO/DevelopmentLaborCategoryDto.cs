using System.Collections.Generic;

namespace LaborVolumeCalculator.DTO
{
    public class DevelopmentLaborCategoryDto
    {
        public int ID { get; set; }

        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class DevelopmentLaborCategoryCreateDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public List<DevelopmentLaborCreateDto_ListItem> Labors { get; set; }
    }

    public class DevelopmentLaborCategoryFullDto
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public List<DevelopmentLaborDto_ListItem> Labors { get; set;}
    }
}