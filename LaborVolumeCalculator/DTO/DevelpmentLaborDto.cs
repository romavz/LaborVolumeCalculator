namespace LaborVolumeCalculator.DTO
{
    public class DevelopmentLaborDto
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

    public class DevelopmentLaborChangeDto : DevelopmentLaborCreateDto
    {
        public int ID { get; set; }
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