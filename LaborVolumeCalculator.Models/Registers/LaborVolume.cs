using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Registers
{
    public class LaborVolume : LaborVolumeBase
    {
        public LaborVolume()
        {

        }

        public int LaborID { get; set; }
    }
}
