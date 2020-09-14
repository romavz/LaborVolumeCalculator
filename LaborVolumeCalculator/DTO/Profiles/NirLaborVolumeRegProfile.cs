using AutoMapper;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirLaborVolumeRegProfile : Profile
    {
        public NirLaborVolumeRegProfile()
        {
            CreateMap<NirLaborVolumeReg, NirLaborVolumeRegDto>();
        }
    }
}