namespace LaborVolumeCalculator.DTO
{
    public class TestsDevelopmentRateDto
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public int TestsScaleID { get; set; }
        public int TestsScaleCode { get; set; }
        public string TestsScaleName { get; set; }

        public int TestsCoverageLevelID { get; set; }
        public int TestsCoverageLevelCode { get; set; }

        public string TestsCoverageLevelName { get; set; }

        public int ComponentsMicroArchitectureID { get; set; }
        public int ComponentsMicroArchitectureCode { get; set; }

        public string ComponentsMicroArchitectureName { get; set; } 
    }

    public class TestsDevelopmentRateCreateDto
    {
        public int TestsScaleID { get; set; }
        public int TestsCoverageLevelID { get; set; }
        public int ComponentsMicroArchitectureID { get; set; }
        public double Value { get; set; }
    }

    public class TestsDevelopmentRateUpdateDto : TestsDevelopmentRateCreateDto
    {
        public int ID { get; set; }
    }

}