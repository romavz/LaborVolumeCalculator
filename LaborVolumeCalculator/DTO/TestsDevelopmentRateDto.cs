namespace LaborVolumeCalculator.DTO
{
    public class TestsDevelopmentRateDto
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public int TestScaleID { get; set; }
        public string TestScaleName { get; set; }

        public int TestsCoverageLevelID { get; set; }

        public string TestsCoverageLevelName { get; set; }

        public int ComponentsMicroArchitectureID { get; set; }

        public string ComponentsMicroArchitectureName { get; set; } 
    }
}