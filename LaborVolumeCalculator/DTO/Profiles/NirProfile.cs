using System.Security.Cryptography.X509Certificates;
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
                .ForPath(p => p.CreateTime, opt => opt.Ignore());

            CreateMap<NirCreateDto, Nir>();
            CreateMap<NirChangeDto, Nir>().ReverseMap();

            CreateMap<Labor, LaborDto>().ReverseMap();

            CreateMap<NirScale, NirScaleDto>().ReverseMap();
            CreateMap<NirScaleCreateDto, NirScale>();
            
            CreateMap<NirInnovationProperty, NirInnovationPropertyDto>().ReverseMap();
            CreateMap<NirInnovationPropertyCreateDto, NirInnovationProperty>();

            CreateMap<NirInnovationRate, NirInnovationRateDto>();
            CreateMap<NirInnovationRateCreateDto, NirInnovationRate>();
            CreateMap<NirInnovationRateUpdateDto, NirInnovationRate>();
            
            // Регистры
            CreateMap<NirStageLaborVolume, StageLaborVolumeDto>();
            CreateMap<StageLaborVolumeDto_ListItem, NirStageLaborVolume>();

            CreateMap<NirStageOntdLaborVolume, StageLaborVolumeDto>();
            CreateMap<StageLaborVolumeDto_ListItem, NirStageOntdLaborVolume>();

            CreateMap<NirStage, NirStageDto>().ReverseMap()
                .ForPath(p => p.NirInnovationRate, opt => opt.Ignore());
            
            CreateMap<NirStageCreateDto, NirStage>()
                .ForPath(p => p.NirInnovationRate, opt => opt.Ignore());
            
            CreateMap<NirStageChangeDto, NirStage>()
                .ForPath(p => p.NirInnovationRate, opt => opt.Ignore());
            
            CreateMap<NirStage, NirStageDeleteDto>();
        }
    }
}