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
            DbEntityCountRange[] dbEntityCountRanges = SeedDbEntityCountRanges();
            DbDevLabor[] dbLabors = SeedDbDevLabors(laborCategories);
            SeedDbDevLaborVolumeRanges(dbLabors, dbEntityCountRanges);
        }

        private void SeedDbDevLaborVolumeRanges(DbDevLabor[] dbLabors, DbEntityCountRange[] dbEntityCountRanges)
        {
            DbEntityCountRange _0_10 = dbEntityCountRanges[0];
            DbEntityCountRange _10_30 = dbEntityCountRanges[1];
            DbEntityCountRange _30_50 = dbEntityCountRanges[2];

            DbDevLabor get(string code) {
                return dbLabors.First(l => l.Code == code);
            }

            DbDevLaborVolumeRange[] dbDevLaborVolumeRanges = {
                new DbDevLaborVolumeRange(get("901"), _0_10, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("901"), _10_30, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("901"), _30_50, 1.0, 1.0),
                
                new DbDevLaborVolumeRange(get("902"), _0_10, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("902"), _10_30, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("902"), _30_50, 1.0, 1.0),

                new DbDevLaborVolumeRange(get("903"), _0_10, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("903"), _10_30, 1.0, 1.0),
                new DbDevLaborVolumeRange(get("903"), _30_50, 1.0, 1.5),

                new DbDevLaborVolumeRange(get("904"), _0_10, 0.0, 0.5),
                new DbDevLaborVolumeRange(get("904"), _10_30, 0.5, 1.0),
                new DbDevLaborVolumeRange(get("904"), _30_50, 1.0, 1.0),

                new DbDevLaborVolumeRange(get("1001"), _0_10, 0.5, 1.0),
                new DbDevLaborVolumeRange(get("1001"), _10_30, 0.5, 1.0),
                new DbDevLaborVolumeRange(get("1001"), _30_50, 1.0, 1.5),

                new DbDevLaborVolumeRange(get("1002"), _0_10, 1.0, 1.0),
                new DbDevLaborVolumeRange(get("1002"), _10_30, 1.0, 1.0),
                new DbDevLaborVolumeRange(get("1002"), _30_50, 1.5, 2.0),
            };
            dbContext.AddRange(dbDevLaborVolumeRanges);
        }

        private DbEntityCountRange[] SeedDbEntityCountRanges()
        {
            DbEntityCountRange[] ranges = {
                new DbEntityCountRange("0 - 10"),
                new DbEntityCountRange("10 - 30"),
                new DbEntityCountRange("30 - 50")
            };
            dbContext.AddRange(ranges);
            return ranges;
        }

        private DbDevLabor[] SeedDbDevLabors(DevelopmentLaborCategory[] laborCategories)
        {
            // new DevelopmentLaborCategory(9, "Создание базы данных"),
            // new DevelopmentLaborCategory(10, "Функционирование базы данных"),
            var createDbCat = laborCategories[8];
            var functioningDbCat = laborCategories[9];
            DbDevLabor[] labors = {
                new DbDevLabor("901", "Разработка логической схемы данных для модели сущность-связь", createDbCat),
                new DbDevLabor("902", "Разработка физической модели данных SQL-СУБД", createDbCat),
                new DbDevLabor("903", "Разработка сложной или распределенной физической схемы данных SQL-СУБД", createDbCat),
                new DbDevLabor("904", "Разработка физической модели NoSQL-СУБД", createDbCat),

                new DbDevLabor("1001", "Организация резервного копирования с возможностью остановки системы", functioningDbCat),
                new DbDevLabor("1002", "Организация резервного копировния системы постоянной доступности", functioningDbCat)
            };
            return labors;
        }
    }
}