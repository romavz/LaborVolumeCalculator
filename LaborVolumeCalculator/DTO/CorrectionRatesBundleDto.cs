using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
namespace LaborVolumeCalculator.DTO
{
    public class CorrectionRatesBundleCreateDto
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public int SolutionInnovationRateID { get; set; }
        public double SolutionInnovationRateValue { get; set; }

        public int StandardModulesUsingRateID { get; set; }
        public double StandardModulesUsingRateValue { get; set; }

        public int InfrastructureComplexityRateID { get; set; }
        public double InfrastructureComplexityRateValue { get; set; }
        
        public int ArchitectureComplexityRateID { get; set; }
        public double ArchitectureComplexityRateValue { get; set; }

        public int TestsDevelopmentRateID { get; set; }
        public double TestsDevelopmentRateValue { get; set; }
    }

    public class CorrectionRatesBundleDto : CorrectionRatesBundleCreateDto
    {
        public int ID { get; set; }
    }

    public class CorrectionRatesBundleFullDto : CorrectionRatesBundleDto
    {
        public SolutionInnovationRateDto SolutionInnovationRate { get; set; }
        public StandardModulesUsingRateDto StandardModulesUsingRate { get; set; }
        public InfrastructureComplexityRateDto InfrastructureComplexityRate { get; set; }
        public ArchitectureComplexityRateDto ArchitectureComplexityRate { get; set; }
        public TestsDevelopmentRateDto TestsDevelopmentRate { get; set; }
    }

}