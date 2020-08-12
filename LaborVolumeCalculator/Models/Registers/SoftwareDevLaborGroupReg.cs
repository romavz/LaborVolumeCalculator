using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Models.Registers
{
    public class SoftwareDevLaborGroupReg
    {
        public SoftwareDevLaborGroupReg()
        {
        }

        public int ID { get; set; }

        public int NiokrID { get; set; }
        public Niokr Niokr { get; set;}

        public int NiokrStageID { get; set; }
        public NiokrStage NiokrStage { get; set; }

        public int SoftwareDevLaborGroupID { get; set; }
        public SoftwareDevLaborGroup SoftwareDevLaborGroup { get; set; }

        public int SolutionInnovationRateID { get; set; }
        public SolutionInnovationRate SolutionInnovationRate { get; set; }

        public int StandardModulesUsingRateID { get; set; }
        public StandardModulesUsingRate StandardModulesUsingRate { get; set; }

        public int InfrastructureComplexityRateID { get; set; }
        public InfrastructureComplexityRate InfrastructureComplexityRate { get; set; }

        public int TestsDevelopmentRateID { get; set; }
        public TestsDevelopmentRate TestsDevelopmentRate { get; set; }

        public int ArchitectureComplexityRateID { get; set; }
        public ArchitectureComplexityRate ArchitectureComplexityRate { get; set; }
    }
}