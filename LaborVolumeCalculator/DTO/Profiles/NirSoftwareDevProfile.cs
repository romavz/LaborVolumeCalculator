using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirSoftwareDevLaborGroupProfile : Profile
    {
        public NirSoftwareDevLaborGroupProfile()
        {
            CreateMap<NirSoftwareDevLaborGroup, NirSoftwareDevLaborGroupDto>().ReverseMap();
            CreateMap<NirSoftwareDevLaborGroupCreateDto, NirSoftwareDevLaborGroup>();
            
            CreateMap<SolutionInnovationRate, SolutionInnovationRateDto>().ReverseMap();
            CreateMap<SolutionInnovationRateCreateDto, SolutionInnovationRate>();

            CreateMap<StandardModulesUsingRate, StandardModulesUsingRateDto>().ReverseMap();
            CreateMap<StandardModulesUsingRateCreateDto, StandardModulesUsingRate>();

            CreateMap<InfrastructureComplexityRate, InfrastructureComplexityRateDto>().ReverseMap();
            CreateMap<InfrastructureComplexityRateCreateDto, InfrastructureComplexityRate>();

            CreateMap<ComponentsMicroArchitecture, ComponentsMicroArchitectureDto>().ReverseMap();
            CreateMap<ComponentsMicroArchitectureCreateDto, ComponentsMicroArchitecture>();

            CreateMap<TestsScale, TestsScaleDto>().ReverseMap();
            CreateMap<TestsScaleCreateDto, TestsScale>();

            CreateMap<TestsCoverageLevel, TestsCoverageLevelDto>().ReverseMap();
            CreateMap<TestsCoverageLevelCreateDto, TestsCoverageLevel>();
            
            CreateMap<TestsDevelopmentRate, TestsDevelopmentRateDto>();
            CreateMap<TestsDevelopmentRateCreateDto, TestsDevelopmentRate>();
            CreateMap<TestsDevelopmentRateUpdateDto, TestsDevelopmentRate>();
            
            CreateMap<ComponentsMakroArchitecture, ComponentsMacroArchitectureDto>().ReverseMap();
            CreateMap<ComponentsMacroArchitectureCreateDto, ComponentsMakroArchitecture>();
            
            CreateMap<ComponentsInteractionArchitecture, ComponentsInteractionArchitectureDto>().ReverseMap();
            CreateMap<ComponentsInteractionArchitectureCreateDto, ComponentsInteractionArchitecture>();
            
            CreateMap<ArchitectureComplexityRate, ArchitectureComplexityRateDto>();
            CreateMap<ArchitectureComplexityRateCreateDto, ArchitectureComplexityRate>();
            CreateMap<ArchitectureComplexityRateCnageDto, ArchitectureComplexityRate>().ReverseMap();

            CreateMap<NirStageSoftwareDevLaborGroup, StageSoftwareDevLaborGroupDto>();
            CreateMap<StageSoftwareDevLaborGroupCreateDto, NirStageSoftwareDevLaborGroup>();

            CreateMap<NirDevelopmentLaborVolume, DevLaborVolumeDto>().ReverseMap();
            CreateMap<DevLaborVolumeCreateDto, NirDevelopmentLaborVolume>();
        }
    }
}