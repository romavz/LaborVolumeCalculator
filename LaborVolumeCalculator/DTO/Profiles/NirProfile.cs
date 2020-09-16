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
            CreateMap<Nir, NirDto>().ReverseMap();
            CreateMap<NirStage, NirStageDto>().ReverseMap();
            CreateMap<NirLabor, NirLaborDto>().ReverseMap();

            CreateMap<NirScale, NirScaleDto>().ReverseMap();
            CreateMap<NirInnovationProperty, NirInnovationPropertyDto>().ReverseMap();
            CreateMap<NirInnovationRate, NirInnovationRateDto>().ReverseMap();
            
            // Регистры
            CreateMap<NirLaborVolumeReg, NirLaborVolumeRegDto>().ReverseMap();
            CreateMap<NirStageReg, NirStageRegDto>().ReverseMap();
        }
    }
}