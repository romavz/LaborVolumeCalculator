using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class DevelopmentLaborBuilder
    {
        private readonly DevelopmentLaborCategory[] categories;
        public DevelopmentLaborCategory currentCategory { get; private set; }
        public DevelopmentLaborBuilder(DevelopmentLaborCategory[] categories)
        {
            this.categories = categories;
        }

        public DevelopmentLaborBuilder SetCategory(int number)
        {
            currentCategory = categories[number - 1];
            return this;
        }

        public DevelopmentLabor Create(int code, string name)
        {
            return new DevelopmentLabor(code.ToString(), name, currentCategory);
        }
    }
}