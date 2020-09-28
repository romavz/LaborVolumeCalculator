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

        protected TDto ConvertToDto(TSource item)
        {
            return _mapper.Map<TSource, TDto>(item);
        }

        protected TSource ConvertToSource(TDto itemDto)
        {
            return _mapper.Map<TDto, TSource>(itemDto);
        }

        public TSource ConvertToSource<TSomeOtherDto>(TSomeOtherDto itemDto) where TSomeOtherDto : class
        {
            return _mapper.Map<TSomeOtherDto, TSource>(itemDto);
        }

        protected List<TDto> ConvertToDto(List<TSource> items)
        {
            return _mapper.Map<IEnumerable<TSource>, List<TDto>>(items);
        }
    }

}