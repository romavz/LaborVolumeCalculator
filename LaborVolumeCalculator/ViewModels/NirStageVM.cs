using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.ViewModels
{
    public class NirStageVM : NirStage
    {
        public NirStageVM()
        {
        }

        public NirStageVM(string name, NiokrCategory niokrCategory) : base(name, niokrCategory)
        {
        }

        public NirStageVM(NirStage nirStage)
        {
            ID = nirStage.ID;
            Name = nirStage.Name;
            NiokrCategory = nirStage.NiokrCategory;
            NiokrCategoryID = nirStage.NiokrCategoryID;
        }

        public IEnumerable<LaborVolumeReg> AttachedLaborVolumes { get; set; }
    }
}
