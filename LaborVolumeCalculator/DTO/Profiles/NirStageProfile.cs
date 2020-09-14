using AutoMapper;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.DTO.Profiles
{
    public class NirStageProfile : Profile
    {
        public NirStageProfile()
        {
            CreateMap<NirStage, NirStageDto>();
        }
    }
}