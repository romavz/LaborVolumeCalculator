using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirSoftwareDevLaborGroupProfile : Profile
    {
        public NirSoftwareDevLaborGroupProfile()
        {
            CreateMap<NirSoftwareDevLaborGroup, NirSoftwareDevLaborGroupDto>().ReverseMap();
        }
    }
}