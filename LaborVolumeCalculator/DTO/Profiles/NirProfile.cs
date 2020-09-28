using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirProfile : Profile
    {
        public NirProfile()
        {
            // Справочники
            CreateMap<Nir, NirDto>().ReverseMap()
                .ForPath(p => p.NirInnovationProperty.Name, opt => opt.Ignore())
                .ForPath(p => p.NirScale.Name, opt => opt.Ignore())
                .ForPath(p => p.CreateTime, opt => opt.Ignore());

            CreateMap<NirLabor, NirLaborDto>().ReverseMap();

            CreateMap<NirScale, NirScaleDto>().ReverseMap();
            CreateMap<NirInnovationProperty, NirInnovationPropertyDto>().ReverseMap();
            CreateMap<NirInnovationRate, NirInnovationRateDto>().ReverseMap()
                .ForPath(p => p.NirScale.Name, opt => opt.Ignore())
                .ForPath(p => p.NirInnovationProperty.Name, opt => opt.Ignore());
            
            // Регистры
            CreateMap<NirLaborVolumeReg, NirLaborVolumeRegDto>().ReverseMap()
                .ForPath(p => p.Labor, opt => opt.Ignore());

            CreateMap<NirStage, NirStageDto>().ReverseMap();
            CreateMap<NirStageCreateDto, NirStage>().ReverseMap();
        }
    }
}