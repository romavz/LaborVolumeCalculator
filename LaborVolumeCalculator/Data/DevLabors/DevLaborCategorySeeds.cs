using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class DevLaborCategorySeeds
    {
        private readonly LVCContext dbContext;
        public DevLaborCategorySeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DevelopmentLaborCategory[] Categories { get; private set; }

        public DevLaborCategorySeeds Initialize()
        {
            Categories = new DevelopmentLaborCategory[]
            {
                new DevelopmentLaborCategory(1, "Обработка входных потоков"),
                new DevelopmentLaborCategory(2, "Управление ПО"),
                new DevelopmentLaborCategory(3, "Выходные потоки"),
                new DevelopmentLaborCategory(4, "Специальные функции обработки данных"),
                new DevelopmentLaborCategory(5, "Взаимодействие со сторонними ПО"),
                new DevelopmentLaborCategory(6, "Взаимодействие с внешним оборудованием"),
                new DevelopmentLaborCategory(7, "Сетевой взаимодействие"),
                new DevelopmentLaborCategory(8, "Архитектура компоненты"),
                new DevelopmentLaborCategory(9, "Создание базы данных"),
                new DevelopmentLaborCategory(10, "Функционирование базы данных"),
                new DevelopmentLaborCategory(11, "Разработка печатной платы")
            };
            dbContext.AddRange(Categories);

            return this;
        }
    }
}