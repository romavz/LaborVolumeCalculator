using System.Runtime.InteropServices;
using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            CreateMap<LaborCreateDto, OntdLabor>();
            CreateMap<LaborDto, OntdLabor>();

            CreateMap<SoftwareDevLabor, DevelopmentLaborDto>();
            CreateMap<DevelopmentLaborCreateDto, SoftwareDevLabor>();
            CreateMap<DevelopmentLaborChangeDto, SoftwareDevLabor>();

            CreateMap<DevelopmentLaborCategory, DevelopmentLaborCategoryDto>();

            CreateMap<SoftwareDevLaborVolumeRange, SoftwareDevLaborVolumeRangeDto>()
                .ReverseMap()
                .ForPath(p => p.Labor, opt => opt.Ignore())
                .ForPath(p => p.DevEnv, opt => opt.Ignore());
        
            CreateMap<SoftwareDevEnv, SoftwareDevEnvDto>().ReverseMap();
            CreateMap<SoftwareDevEnvCreateDto, SoftwareDevEnv>();
            CreateMap<SoftwareDevEnvChangeDto, SoftwareDevEnv>();

            CreateMap<CorrectionRatesBundle, CorrectionRatesBundleDto>().ReverseMap();
            CreateMap<CorrectionRatesBundle, CorrectionRatesBundleFullDto>();
            CreateMap<CorrectionRatesBundleCreateDto, CorrectionRatesBundle>();
            
            CreateMap<DbDevLaborVolumeRange, DbDevLaborVolumeRangeDto>();
            CreateMap<DbDevLaborVolumeRangeCreateDto, DbDevLaborVolumeRange>();
            CreateMap<DbDevLaborVolumeRangeChangeDto, DbDevLaborVolumeRange>();

            CreateMap<DbEntityCountRange, DbEntityCountRangeDto>();
            CreateMap<DbEntityCountRangeCreateDto, DbEntityCountRange>();
            
            CreateMap<DbDevLabor, DevelopmentLaborDto>();
            CreateMap<DevelopmentLaborCreateDto, DbDevLabor>();
            CreateMap<DevelopmentLaborChangeDto, DbDevLabor>();
        }
    }
}