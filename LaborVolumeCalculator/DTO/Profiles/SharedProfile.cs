using System.Runtime.InteropServices;
using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            CreateMap<SoftwareDevLabor, DevelopmentLaborDto>()
                .ReverseMap()
                .ForPath(p => p.LaborCategory, opt => opt.Ignore());
        }
    }
}