using AutoMapper;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirStageRegProfile : Profile
    {
        public NirStageRegProfile()
        {
            CreateMap<NirStageReg, NirStageRegDto>().ReverseMap();
        }
    }
}