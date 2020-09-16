using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

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
            
            CreateMap<TestsDevelopmentRate, TestsDevelopmentRateDto>().ReverseMap();
            CreateMap<ComponentsMakroArchitecture, ComponentsMacroArchitectureDto>().ReverseMap();
            CreateMap<ComponentsInteractionArchitecture, ComponentsInteractionArchitectureDto>().ReverseMap();
            CreateMap<ArchitectureComplexityRate, ArchitectureComplexityRateDto>().ReverseMap();
        }
    }
}