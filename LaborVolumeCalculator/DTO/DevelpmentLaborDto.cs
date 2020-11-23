namespace LaborVolumeCalculator.DTO
{
    public class DevelopmentLaborFullDto
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DevelopmentLaborCategoryDto LaborCategory { get; set; }
    }

    public class DevelopmentLaborCreateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int LaborCategoryID { get; set; }
    }

    public class DevelopmentLaborChangeDto
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int LaborCategoryID { get; set; }
    }

    public class DevelopmentLaborCreateDto_ListItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public class DevelopmentLaborDto_ListItem
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }


}