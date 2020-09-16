using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace LaborVolumeCalculator.Controllers
{
    public class ControllerBase<TSource, TDto> : ControllerBase
        where TSource : class
        where TDto : class
    {
        protected readonly IMapper _mapper;
        public ControllerBase(IMapper mapper)
        {
            this._mapper = mapper;

        }

        protected TDto ConvertToDto(TSource labor)
        {
            return _mapper.Map<TSource, TDto>(labor);
        }

        protected TSource ConvertToSource(TDto item)
        {
            return _mapper.Map<TDto, TSource>(item);
        }

        protected List<TDto> ConvertToDto(List<TSource> labors)
        {
            return _mapper.Map<IEnumerable<TSource>, List<TDto>>(labors);
        }
    }
}