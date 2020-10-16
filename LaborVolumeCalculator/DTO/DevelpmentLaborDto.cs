namespace LaborVolumeCalculator.DTO
{
    public class DevelopmentLaborBaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class DevelopmentLaborDto : DevelopmentLaborBaseDto
    {
        public int ID { get; set; }
        public DevelopmentLaborCategoryDto LaborCategory { get; set; }
    }

    public class DevelopmentLaborCreateDto : DevelopmentLaborBaseDto
    {
        public int LaborCategoryID { get; set; }
    }

    public class DevelopmentLaborChangeDto : DevelopmentLaborCreateDto
    {
        public int ID { get; set; }
    }
}