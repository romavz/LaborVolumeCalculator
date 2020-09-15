using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirLaborProfile : Profile
    {
        public NirLaborProfile()
        {
            CreateMap<NirLabor, NirLaborDto>().ReverseMap();
        }
    }
}