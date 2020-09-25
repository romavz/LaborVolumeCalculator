using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.ViewModels
{
    public class NirStageVM : Models.Dictionary.StageForNir
    {
        public NirStageVM()
        {
        }

        public NirStageVM(string name) : base(name)
        {
        }

        public NirStageVM(Models.Dictionary.StageForNir nirStage)
        {
            ID = nirStage.ID;
            Name = nirStage.Name;
        }

        public IEnumerable<NirLaborVolumeReg> AttachedLaborVolumes { get; set; }
    }
}
