using System;

namespace LaborVolumeCalculator.Models.Dictionary
{
    public class DevelopmentLabor : Labor
    {
        public DevelopmentLabor() : base()
        {
        }

        public DevelopmentLabor(string code, string name, LaborCategory laborCategory, float minVolume, float maxVolume) 
            : base(code, name, minVolume, maxVolume)
        {
            LaborCategory = laborCategory ?? throw new ArgumentNullException("laborCategory");
            LaborCategoryID = laborCategory.ID;
        }

        public int LaborCategoryID { get; set; }
        public LaborCategory LaborCategory { get; set; }
    }
}