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
            
            CreateMap<SolutionInnovationRate, SolutionInnovationRateDto>().ReverseMap();
            CreateMap<StandardModulesUsingRate, StandardModulesUsingRateDto>().ReverseMap();
            CreateMap<InfrastructureComplexityRate, InfrastructureComplexityRateDto>().ReverseMap();

            CreateMap<ComponentsMicroArchitecture, ComponentsMicroArchitectureDto>().ReverseMap();
            CreateMap<TestsScale, TestsScaleDto>().ReverseMap();
            CreateMap<TestsCoverageLevel, TestsCoverageLevelDto>().ReverseMap();
            CreateMap<TestsDevelopmentRate, TestsDevelopmentRateDto>().ReverseMap()
                .ForPath(p => p.ComponentsMicroArchitecture.Name, opt => opt.Ignore())
                .ForPath(p => p.TestsCoverageLevel.Name, opt => opt.Ignore())
                .ForPath(p => p.TestsScale.Name, opt => opt.Ignore());
            
            CreateMap<ComponentsMakroArchitecture, ComponentsMacroArchitectureDto>().ReverseMap();
            CreateMap<ComponentsInteractionArchitecture, ComponentsInteractionArchitectureDto>().ReverseMap();
            
            CreateMap<ArchitectureComplexityRate, ArchitectureComplexityRateDto>();
            CreateMap<ArchitectureComplexityRateCreateDto, ArchitectureComplexityRate>();
            CreateMap<ArchitectureComplexityRateShortDto, ArchitectureComplexityRate>().ReverseMap();

            CreateMap<NirStageSoftwareDevLaborGroup, StageSoftwareDevLaborGroupDto>();
            CreateMap<StageSoftwareDevLaborGroupDto_ListItem, NirStageSoftwareDevLaborGroup>();

            CreateMap<NirDevelopmentLaborVolume, DevLaborVolumeDto>().ReverseMap();
            CreateMap<DevLaborVolumeDto_ListItem, NirDevelopmentLaborVolume>();
        }
    }
}