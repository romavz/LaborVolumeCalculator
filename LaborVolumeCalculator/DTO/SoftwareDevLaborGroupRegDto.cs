namespace LaborVolumeCalculator.DTO
{
    public class StageSoftwareDevLaborGroupDto
    {
        public int ID { get; set; }

        public int StageID { get; set; }

        public int SoftwareDevLaborGroupID { get; set; }
        public string SoftwareDevLaborGroupName { get; set; }

        public int SolutionInnovationRateID { get; set; }
        public double SolutionInnovationRateValue { get; set; }

        public int StandardModulesUsingRateID { get; set; }
        public double StandardModulesUsingRateValue { get; set; }

        public int InfrastructureComplexityRateID { get; set; }
        public double InfrastructureComplexityRateValue { get; set; }

        public int TestsDevelopmentRateID { get; set; }
        public double TestsDevelopmentRateValue { get; set; }

        public int ArchitectureComplexityRateID { get; set; }
        public double ArchitectureComplexityRateValue { get; set; }
    }
}