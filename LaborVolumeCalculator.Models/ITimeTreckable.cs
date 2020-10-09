using System;
namespace LaborVolumeCalculator.Models
{
    public interface ITimeTreckable
    {
         DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
    }
}