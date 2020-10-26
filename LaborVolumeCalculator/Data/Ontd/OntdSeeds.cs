using System.Reflection.Emit;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Ontd
{
    public class OntdSeeds
    {
        private readonly LVCContext dbContext;
        public OntdSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public OntdSeeds Initialize()
        {
            var lb = new OntdLaborBuilder(); 
            OntdLabor[] labors = {
                lb.Create(1, "Пояснительная записка технического проекта", 0.05),
                lb.Create(2, "Научно-технический отчет", 0.01, 0.1),
                lb.Create(3, "Пояснительная записка эскизного проекта", 0.04),
                lb.Create(4, "Ведомость технического (эскизного) проекта", 0.003),
                lb.Create(5, "Чертеж (общего вида, сборочный, габаритный, монтажный, электромонтажный", 0.043, 0.566),
                lb.Create(6, "Электрическая схема", 0.079, 0.767),
                lb.Create(7, "Спецификация", 0.001),
                lb.Create(8, "Ведомость покупных изделий", 0.002),
                lb.Create(9, "Технические условия", 0.017),
                lb.Create(10, "Программа и методика испытаний", 0.02),
                lb.Create(11, "Документы эксплуатационные", 0.019),
                lb.Create(12, "Документы ремонтные", 0.022),
                lb.Create(13, "Сопроводительное писмо", 0.015),
                lb.Create(14, "Служебная записка, справка", 0.02)
            };
            dbContext.AddRange(labors);

            return this;
        }
    }
}