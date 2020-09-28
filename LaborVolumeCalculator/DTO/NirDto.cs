using System;

namespace LaborVolumeCalculator.DTO
{
    public class NirDto : BaseModelDto
    {
        public DateTime CreateTime { get; set; }
    }

    public class NirCreateDto {
        public string Name { get; set; }
    }
}