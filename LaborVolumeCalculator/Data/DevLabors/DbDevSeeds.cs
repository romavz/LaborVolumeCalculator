using System;
using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class DbDevSeeds
    {
        private readonly LVCContext dbContext;
        public DbDevSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize(DevelopmentLaborCategory[] laborCategories)
        {
            RangeFeatureCategory[] rangeFeatureCategories = SeedRangeFeatureCategories();
            RangeFeature[] dbEntityCountRanges = SeedDbEntityCountRanges(rangeFeatureCategories[1]);
            DevelopmentLabor[] dbLabors = SeedDbDevLabors(laborCategories);
            SeedDbDevLaborVolumeRanges(dbLabors, dbEntityCountRanges);
        }

        private RangeFeatureCategory[] SeedRangeFeatureCategories()
        {
            RangeFeatureCategory[] result = {
                new RangeFeatureCategory("Среда разработки"),
                new RangeFeatureCategory("Количество сущностей БД"),
                new RangeFeatureCategory("Количество точек на плате")
            };

            return result;
        }

        private void SeedDbDevLaborVolumeRanges(DevelopmentLabor[] dbLabors, RangeFeature[] dbEntityCountRanges)
        {
            RangeFeature _0_10 = dbEntityCountRanges[0];
            RangeFeature _10_30 = dbEntityCountRanges[1];
            RangeFeature _30_50 = dbEntityCountRanges[2];

            DevelopmentLabor get(string code) {
                return dbLabors.First(l => l.Code == code);
            }

            LaborVolumeRange[] dbDevLaborVolumeRanges = {
                new LaborVolumeRange(get("901"), _0_10, 0.0, 0.5),
                new LaborVolumeRange(get("901"), _10_30, 0.0, 0.5),
                new LaborVolumeRange(get("901"), _30_50, 1.0, 1.0),
                
                new LaborVolumeRange(get("902"), _0_10, 0.0, 0.5),
                new LaborVolumeRange(get("902"), _10_30, 0.0, 0.5),
                new LaborVolumeRange(get("902"), _30_50, 1.0, 1.0),

                new LaborVolumeRange(get("903"), _0_10, 0.0, 0.5),
                new LaborVolumeRange(get("903"), _10_30, 1.0, 1.0),
                new LaborVolumeRange(get("903"), _30_50, 1.0, 1.5),

                new LaborVolumeRange(get("904"), _0_10, 0.0, 0.5),
                new LaborVolumeRange(get("904"), _10_30, 0.5, 1.0),
                new LaborVolumeRange(get("904"), _30_50, 1.0, 1.0),

                new LaborVolumeRange(get("1001"), _0_10, 0.5, 1.0),
                new LaborVolumeRange(get("1001"), _10_30, 0.5, 1.0),
                new LaborVolumeRange(get("1001"), _30_50, 1.0, 1.5),

                new LaborVolumeRange(get("1002"), _0_10, 1.0, 1.0),
                new LaborVolumeRange(get("1002"), _10_30, 1.0, 1.0),
                new LaborVolumeRange(get("1002"), _30_50, 1.5, 2.0),
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
            var createDbCat = laborCategories[8];
            var functioningDbCat = laborCategories[9];
            DevelopmentLabor[] labors = {
                new DevelopmentLabor("901", "Разработка логической схемы данных для модели сущность-связь", createDbCat),
                new DevelopmentLabor("902", "Разработка физической модели данных SQL-СУБД", createDbCat),
                new DevelopmentLabor("903", "Разработка сложной или распределенной физической схемы данных SQL-СУБД", createDbCat),
                new DevelopmentLabor("904", "Разработка физической модели NoSQL-СУБД", createDbCat),

                new DevelopmentLabor("1001", "Организация резервного копирования с возможностью остановки системы", functioningDbCat),
                new DevelopmentLabor("1002", "Организация резервного копировния системы постоянной доступности", functioningDbCat)
            };
            return labors;
        }
    }
}