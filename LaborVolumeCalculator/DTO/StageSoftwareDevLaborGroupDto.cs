using System.Collections.Generic;

namespace LaborVolumeCalculator.DTO
{

    public class StageSoftwareDevLaborGroupBaseDto
    {
        public int SoftwareDevLaborGroupID { get; set; }
        public int? CorrectionRatesBundleID { get; set; }

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

    public class StageSoftwareDevLaborGroupDto : StageSoftwareDevLaborGroupBaseDto
    {
        public int ID { get; set; }

        public string SoftwareDevLaborGroupName { get; set; }
        public string SoftwareDevLaborGroupCode { get; set; }
        public List<DevLaborVolumeDto> LaborVolumes { get; set; }
    }

    public class StageSoftwareDevLaborGroupCreateDto : StageSoftwareDevLaborGroupBaseDto
    {
        public List<DevLaborVolumeCreateDto> LaborVolumes { get; set; }
    }

}