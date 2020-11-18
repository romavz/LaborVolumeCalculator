using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class DevelopmentLaborSeeds
    {
        private readonly LVCContext dbContext;

        public DevelopmentLaborSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize()
        {
            RangeFeatureCategory[] rangeFeatureCategories = SeedRangeFeatureCategories();
            var dlcs = new DevLaborCategorySeeds(dbContext).Initialize();
            new SoftwareDevSeeds(dbContext, rangeFeatureCategories[0]).Initialize(dlcs.Categories);
            new DbDevSeeds(dbContext, rangeFeatureCategories[1]).Initialize(dlcs.Categories);
        }

        private RangeFeatureCategory[] SeedRangeFeatureCategories()
        {
            RangeFeatureCategory[] rangeFeatureCategories = {
                new RangeFeatureCategory("Среда разработки"),
                new RangeFeatureCategory("Количество сущностей БД"),
                new RangeFeatureCategory("Количество точек на плате")
            };

            dbContext.AddRange(rangeFeatureCategories);
            return rangeFeatureCategories;
        }
    }
}