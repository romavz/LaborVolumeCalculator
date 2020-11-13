using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Rates
{
    public class CorrectionRatesBundleSeeds
    {

        public CorrectionRatesBundleSeeds(LVCContext dbContext, SoftwareDevLaborGroupRateSeeds sdlgrSeeds)
        {
            solutionInnovationRates = sdlgrSeeds.SolutionInnovationRates;
            standardModulesUsingRates = sdlgrSeeds.StandardModulesUsingRates;
            infrastructureComplexityRates = sdlgrSeeds.InfrastructureComplexityRates;
            architectureComplexityRates = sdlgrSeeds.ArchitectureComplexityRates;
            testsDevelopmentRates = sdlgrSeeds.TestsDevelopmentRates;
            this.dbContext = dbContext;
        }

        private readonly SolutionInnovationRate[] solutionInnovationRates;
        private readonly StandardModulesUsingRate[] standardModulesUsingRates;
        private readonly InfrastructureComplexityRate[] infrastructureComplexityRates;
        private readonly ArchitectureComplexityRate[] architectureComplexityRates;
        private readonly TestsDevelopmentRate[] testsDevelopmentRates;
        private readonly LVCContext dbContext;

        public void Initialize()
        {
            var rb = new CorrectionRatesBundleBuilder();
            CorrectionRatesBundle[] ratesBundles = {
                 rb.Create(1, "Веб-ориентированный проект с алалогичным решением",
                    solutionInnovationRates[3], standardModulesUsingRates[2], infrastructureComplexityRates[0], architectureComplexityRates[10], testsDevelopmentRates[0]
                 ),
                 rb.Create(2, "Веб-ориентированный проект с аналогичным решением, предназначенный для размещения в сети Интернет",
                    solutionInnovationRates[3], standardModulesUsingRates[2], infrastructureComplexityRates[1], architectureComplexityRates[10], testsDevelopmentRates[17], bundle => bundle.TestsDevelopmentRateValue = 1.58
                    ),
                 rb.Create(3, "Типовое клиент-серверное решение с взаимодействием множества объектов",
                    solutionInnovationRates[2], standardModulesUsingRates[3], infrastructureComplexityRates[1], architectureComplexityRates[6], testsDevelopmentRates[9]
                    ),
                 rb.Create(4, "Автоматизация работы сторонних программных средств на инфраструктуре виртуализации с необходимым тестированием",
                    solutionInnovationRates[1], standardModulesUsingRates[4], infrastructureComplexityRates[2], architectureComplexityRates[6], testsDevelopmentRates[1]
                    ),
                 rb.Create(5, "Решение специальной задачи с высоким требованием безопасности разработки",
                    solutionInnovationRates[1], standardModulesUsingRates[4], infrastructureComplexityRates[3], architectureComplexityRates[4], testsDevelopmentRates[9]
                    ),
                 rb.Create(6, "Решение специальной задачи с высоким требованием безопасности разработки и уровнем тестирования кода",
                    solutionInnovationRates[1], standardModulesUsingRates[4], infrastructureComplexityRates[3], architectureComplexityRates[4], testsDevelopmentRates[17], bundle => bundle.TestsDevelopmentRateValue = 1.46
                    ),
                 rb.Create(7, "Аппаратное решение типовой задачи",
                    solutionInnovationRates[2], standardModulesUsingRates[4], infrastructureComplexityRates[4], architectureComplexityRates[0], testsDevelopmentRates[9]
                 ),
                 rb.Create(8, "Аппаратное решение с высокими требованиями к тестированию кода",
                    solutionInnovationRates[2], standardModulesUsingRates[4], infrastructureComplexityRates[4], architectureComplexityRates[0], testsDevelopmentRates[14]
                    ),
                 rb.Create(9, "Модули, внедряемые в сторонние программные продукты",
                    solutionInnovationRates[1], standardModulesUsingRates[4], infrastructureComplexityRates[0], architectureComplexityRates[0], testsDevelopmentRates[28]
                    ),
                 rb.Create(10, "Решение новой, алгоритмически сложной задачи с обработкой информации, передаваемой между сетевыми приложениями",
                    solutionInnovationRates[0], standardModulesUsingRates[4], infrastructureComplexityRates[1], architectureComplexityRates[6], testsDevelopmentRates[9]
                    )
            };
            dbContext.AddRange(ratesBundles);
        }

    }
}