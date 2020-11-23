using System;
using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class DbDevSeeds
    {
        private readonly LVCContext dbContext;
        private readonly RangeFeatureCategory category;

        public DbDevSeeds(LVCContext dbContext, RangeFeatureCategory category)
        {
            this.dbContext = dbContext;
            this.category = category;
        }

        public void Initialize(DevelopmentLaborCategory[] laborCategories)
        {
            RangeFeature[] dbEntityCountRanges = SeedDbEntityCountRanges(category);
            DevelopmentLabor[] dbLabors = SeedDbDevLabors(laborCategories);
            SeedDbDevLaborVolumeRanges(dbLabors, dbEntityCountRanges);
        }

        private void SeedDbDevLaborVolumeRanges(DevelopmentLabor[] dbLabors, RangeFeature[] dbEntityCountRanges)
        {
            RangeFeature _0_10 = dbEntityCountRanges[0];
            RangeFeature _10_30 = dbEntityCountRanges[1];
            RangeFeature _30_50 = dbEntityCountRanges[2];

            var labors = new DevelopmentLaborsContainer(dbLabors);
            
            var rb = new DevelopmentLaborVolumeRangeBuilder();
            LaborVolumeRange[] dbDevLaborVolumeRanges = {
                rb.SetLabor(labors[901]).Create(_0_10, 0.0, 0.5),
                rb.Create(_10_30, 0.0, 0.5),
                rb.Create(_30_50, 1.0),
                
                rb.SetLabor(labors[902]).Create(_0_10, 0.0, 0.5),
                rb.Create(_10_30, 0.0, 0.5),
                rb.Create(_30_50, 1.0),

                rb.SetLabor(labors[903]).Create(_0_10, 0.0, 0.5),
                rb.Create(_10_30, 1.0),
                rb.Create(_30_50, 1.0, 1.5),

                rb.SetLabor(labors[904]).Create(_0_10, 0.0, 0.5),
                rb.Create(_10_30, 0.5, 1.0),
                rb.Create(_30_50, 1.0),

                rb.SetLabor(labors[1001]).Create(_0_10, 0.5, 1.0),
                rb.Create(_10_30, 0.5, 1.0),
                rb.Create(_30_50, 1.0, 1.5),

                rb.SetLabor(labors[1002]).Create(_0_10, 1.0),
                rb.Create(_10_30, 1.0),
                rb.Create(_30_50, 1.5, 2.0),
            };
            dbContext.AddRange(dbDevLaborVolumeRanges);
        }

        private RangeFeature[] SeedDbEntityCountRanges(RangeFeatureCategory category)
        {
            RangeFeature[] ranges = {
                new RangeFeature("0 - 10", category),
                new RangeFeature("10 - 30", category),
                new RangeFeature("30 - 50", category)
            };
            dbContext.AddRange(ranges);
            return ranges;
        }

        private DevelopmentLabor[] SeedDbDevLabors(DevelopmentLaborCategory[] laborCategories)
        {
            // new DevelopmentLaborCategory(9, "Создание базы данных"),
            // new DevelopmentLaborCategory(10, "Функционирование базы данных"),
            var lb = new DevelopmentLaborBuilder(laborCategories).SetCategory(9);
            DevelopmentLabor[] labors = {
                lb.Create(901, "Разработка логической схемы данных для модели сущность-связь"),
                lb.Create(902, "Разработка физической модели данных SQL-СУБД"),
                lb.Create(903, "Разработка сложной или распределенной физической схемы данных SQL-СУБД"),
                lb.Create(904, "Разработка физической модели NoSQL-СУБД"),

                lb.SetCategory(10).Create(1001, "Организация резервного копирования с возможностью остановки системы"),
                lb.Create(1002, "Организация резервного копировния системы постоянной доступности")
            };

            dbContext.AddRange(labors);
            return labors;
        }
    }
}