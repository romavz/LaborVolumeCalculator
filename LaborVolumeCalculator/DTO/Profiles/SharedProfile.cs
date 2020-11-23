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

            CreateMap<DevelopmentLabor, DevelopmentLaborFullDto>();
            CreateMap<DevelopmentLaborCreateDto, DevelopmentLabor>();
            CreateMap<DevelopmentLaborChangeDto, DevelopmentLabor>();
            CreateMap<DevelopmentLaborCreateDto_ListItem, DevelopmentLabor>();
            CreateMap<DevelopmentLabor, DevelopmentLaborDto_ListItem>();


            CreateMap<DevelopmentLaborCategory, DevelopmentLaborCategoryDto>().ReverseMap();
            CreateMap<DevelopmentLaborCategory, DevelopmentLaborCategoryFullDto>();
            CreateMap<DevelopmentLaborCategoryCreateDto, DevelopmentLaborCategory>();


            CreateMap<CorrectionRatesBundle, CorrectionRatesBundleDto>().ReverseMap();
            CreateMap<CorrectionRatesBundle, CorrectionRatesBundleFullDto>();
            CreateMap<CorrectionRatesBundleCreateDto, CorrectionRatesBundle>();

            CreateMap<LaborVolumeRange, LaborVolumeRangeDto>();
            CreateMap<LaborVolumeRangeChangeDto, LaborVolumeRange>();
            CreateMap<LaborVolumeRangeCreateDto, LaborVolumeRange>();

            CreateMap<RangeFeature, RangeFeatureDto>();
            CreateMap<RangeFeatureCreateDto, RangeFeature>();
            CreateMap<RangeFeatureChangeDto, RangeFeature>();
            CreateMap<RangeFeature, RangeFeatureDto_ListItem>();
            CreateMap<RangeFeatureCreateDto_ListItem, RangeFeature>();

            CreateMap<RangeFeatureCategory, RangeFeatureCategoryDto>().ReverseMap();
            CreateMap<RangeFeatureCategoryCreateDto, RangeFeatureCategory>();
            CreateMap<RangeFeatureCategory, RangeFeatureCategoryFullDto>();
            CreateMap<RangeFeatureCategoryFullCreateDto, RangeFeatureCategory>();
        }
    }
}