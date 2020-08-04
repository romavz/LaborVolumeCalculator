

using System;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class OkrSoftwareDevLaborGroup : SoftwareDevLaborGroup
    {
        public OkrSoftwareDevLaborGroup() : base() { }
        public OkrSoftwareDevLaborGroup(string code, string name, OkrStage okrStage) : base(code, name)
        {
            this.OkrStage = okrStage ?? throw new ArgumentNullException("okrStage");
            this.OkrStageID = okrStage.ID;
        }

        public int OkrStageID  { get; set; }
        public OkrStage OkrStage { get; set; }
    }
}