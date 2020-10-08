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
            CreateMap<ArchitectureComplexityRate, ArchitectureComplexityRateDto>().ReverseMap()
                .ForPath(p => p.ComponentsMakroArchitecture.Name, opt => opt.Ignore())
                .ForPath(p => p.ComponentsInteractionArchitecture.Name, opt => opt.Ignore());

            CreateMap<NirStageSoftwareDevLaborGroup, NirStageSoftwareDevLaborGroupDto>()
                .ReverseMap()
                .ForPath(p => p.SoftwareDevLaborGroup.Name, opt => opt.Ignore());
            
            CreateMap<NirSoftwareDevLaborVolume, NirSoftwareDevLaborVolumeDto>()
                .ReverseMap()
                .ForPath(p => p.LaborVolumeRange, opt => opt.Ignore());
        }
    }
}