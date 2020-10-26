using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class SoftwareDevLaborBuilder
    {
        private readonly DevelopmentLaborCategory[] categories;
        public DevelopmentLaborCategory currentCategory { get; private set; }
        public SoftwareDevLaborBuilder(DevelopmentLaborCategory[] categories)
        {
            this.categories = categories;
        }

        public SoftwareDevLaborBuilder SetCategory(int number)
        {
            currentCategory = categories[number - 1];
            return this;
        }

        public SoftwareDevLabor Create(int code, string name)
        {
            return new SoftwareDevLabor(code.ToString(), name, currentCategory);
        }
    }
}