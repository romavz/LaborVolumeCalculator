using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirProfile : Profile
    {
        public NirProfile()
        {
            CreateMap<Nir, NirDto>().ReverseMap();

            CreateMap<NirInnovationRate, NirInnovationRateDto>().ReverseMap();
            CreateMap<NirScale, NirScaleDto>().ReverseMap();
            CreateMap<NirInnovationProperty, NirInnovationPropertyDto>().ReverseMap();
        }
    }
}