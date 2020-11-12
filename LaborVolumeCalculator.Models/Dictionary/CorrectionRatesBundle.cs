namespace LaborVolumeCalculator.Models.Dictionary
{
    public class CorrectionRatesBundle : BasicModel
    {
        public CorrectionRatesBundle()
        {
        }

        public CorrectionRatesBundle(
            int number,
            string name,
            SolutionInnovationRate solutionInnovationRate,
            StandardModulesUsingRate standardModulesUsingRate,
            InfrastructureComplexityRate infrastructureComplexityRate,
            ArchitectureComplexityRate architectureComplexityRate,
            TestsDevelopmentRate testsDevelopmentRate
        )
        {
            Number = number;
            Name = name;

            SolutionInnovationRate = solutionInnovationRate;
            StandardModulesUsingRate = standardModulesUsingRate;
            InfrastructureComplexityRate = infrastructureComplexityRate;
            ArchitectureComplexityRate = architectureComplexityRate;
            TestsDevelopmentRate = testsDevelopmentRate;

            SolutionInnovationRateID = solutionInnovationRate?.ID ?? 0;
            StandardModulesUsingRateID = standardModulesUsingRate?.ID ?? 0;
            InfrastructureComplexityRateID = infrastructureComplexityRate?.ID ?? 0;
            ArchitectureComplexityRateID = infrastructureComplexityRate?.ID ?? 0;
            TestsDevelopmentRateID = testsDevelopmentRate?.ID ?? 0;

            SolutionInnovationRateValue = solutionInnovationRate?.Value ?? 0;
            StandardModulesUsingRateValue = standardModulesUsingRate?.Value ?? 0;
            InfrastructureComplexityRateValue = infrastructureComplexityRate?.Value ?? 0;
            ArchitectureComplexityRateValue = architectureComplexityRate?.Value ?? 0;
            TestsDevelopmentRateValue = testsDevelopmentRate?.Value ?? 0;
        }

        public int Number { get; set; }

        public SolutionInnovationRate SolutionInnovationRate { get; set; }
        public int SolutionInnovationRateID { get; set; }
        public double SolutionInnovationRateValue { get; set;}

        public StandardModulesUsingRate StandardModulesUsingRate { get; set; }
        public int StandardModulesUsingRateID { get; set; }
        public double StandardModulesUsingRateValue { get; set; }

        public InfrastructureComplexityRate InfrastructureComplexityRate { get; set; }
        public int InfrastructureComplexityRateID { get; set; }
        public double InfrastructureComplexityRateValue { get; set; }

        public ArchitectureComplexityRate ArchitectureComplexityRate { get; set; }
        public int ArchitectureComplexityRateID { get; set; }
        public double ArchitectureComplexityRateValue { get; set; }

        public TestsDevelopmentRate TestsDevelopmentRate { get; set; }
        public int TestsDevelopmentRateID { get; set; }
        public double TestsDevelopmentRateValue { get; set; }
    }
}