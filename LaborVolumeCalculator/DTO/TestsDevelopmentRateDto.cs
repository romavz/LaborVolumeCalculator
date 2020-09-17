namespace LaborVolumeCalculator.DTO
{
    public class TestsDevelopmentRateDto
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public int TestsScaleID { get; set; }
        public string TestsScaleName { get; set; }

        public int TestsCoverageLevelID { get; set; }

        public string TestsCoverageLevelName { get; set; }

        public int ComponentsMicroArchitectureID { get; set; }

        public string ComponentsMicroArchitectureName { get; set; } 
    }
}