using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class SoftwareDevLaborGroupRateSeeds
    {
        private readonly LVCContext dbContext;
        public SoftwareDevLaborGroupRateSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize()
        {
            SolutionInnovationRate[] inoRate = {
                new SolutionInnovationRate("Разработка решения, предусматривающая применение принципиально новых методов разработки,"+
                    " проведение научно-исследовательских работ", 1.6),
                new SolutionInnovationRate("Разработка типовых решений, оригитальных задач и систем, не имеющих аналогов", 1.3),
                new SolutionInnovationRate("Разработка проекта ис использование типовыхпроектных решений при условии их изменения", 1.1),
                new SolutionInnovationRate("Разработка проектов, имеющих аналогичные решения", 0.8)
            };
            dbContext.AddRange(inoRate);

            StandardModulesUsingRate[] standardRate = {
                new StandardModulesUsingRate("60-80%", 0.5),
                new StandardModulesUsingRate("40-60%", 0.6),
                new StandardModulesUsingRate("25-40%", 0.7),
                new StandardModulesUsingRate("20-25%", 0.8),
                new StandardModulesUsingRate("0-20%", 1)
            };
            dbContext.AddRange(standardRate);

            InfrastructureComplexityRate[] infraRate = {
                new InfrastructureComplexityRate("Стандартная инфраструктура разработки", 1),
                new InfrastructureComplexityRate("Инфраструктура, включающая сложные логические и составные взаимодействия либо" +
                    " взаимодействия большого числа элементов", 1.25),
                new InfrastructureComplexityRate("Сложная виртуальная инфраструктура, содержащая взаимосвязанные виртуальные сети "+
                    "и средства автоматизации управлением виртуальными машинами", 1.4),
                new InfrastructureComplexityRate("Инфраструктура с повышенными требованиями безопасности, на всех этапах выполнения проекта, "+
                    "в том числе: обособление элементов, использование дополнительных средств защиты и т.д.", 1.6),
                new InfrastructureComplexityRate("Инфраструктура, включающая механическое взаимодействие компонентов", 1.9)
            };
            dbContext.AddRange(infraRate);

            ComponentsMakroArchitecture[] makroArch = {
                new ComponentsMakroArchitecture("Процедурная"),
                new ComponentsMakroArchitecture("Асинхронная"),
                new ComponentsMakroArchitecture("Микроядерная")
            };
            dbContext.AddRange(makroArch);

            ComponentsInteractionArchitecture[] interactArch = {
                new ComponentsInteractionArchitecture("Монолитная"),
                new ComponentsInteractionArchitecture("N-звенная(в том числе клиент-серверная)"),
                new ComponentsInteractionArchitecture("Микросервисная"),
                new ComponentsInteractionArchitecture("С общей распределенной памятью")
            };
            dbContext.AddRange(interactArch);

            ArchitectureComplexityRate[] acr = {
                new ArchitectureComplexityRate(makroArch[0], interactArch[0], 1.15),
                new ArchitectureComplexityRate(makroArch[0], interactArch[1], 1.1),
                new ArchitectureComplexityRate(makroArch[0], interactArch[2], 1),
                new ArchitectureComplexityRate(makroArch[0], interactArch[3], 1.15),
                new ArchitectureComplexityRate(makroArch[1], interactArch[0], 1.1),
                new ArchitectureComplexityRate(makroArch[1], interactArch[1], 1.05),
                new ArchitectureComplexityRate(makroArch[1], interactArch[2], 1),
                new ArchitectureComplexityRate(makroArch[1], interactArch[3], 1.15),
                new ArchitectureComplexityRate(makroArch[2], interactArch[0], 1),
                new ArchitectureComplexityRate(makroArch[2], interactArch[1], 1),
                new ArchitectureComplexityRate(makroArch[2], interactArch[2], 0.9),
                new ArchitectureComplexityRate(makroArch[2], interactArch[3], 1.1)
            };
            dbContext.AddRange(acr);

            ComponentsMicroArchitecture[] microArch = {
                new ComponentsMicroArchitecture("Процедурная"),
                new ComponentsMicroArchitecture("Объектно-ориентированная"),
                new ComponentsMicroArchitecture("Функциональная"),
                new ComponentsMicroArchitecture("Смешанная")
            };
            dbContext.AddRange(microArch);

            TestsScale[] testsScales = {
                new TestsScale("Модульное"),
                new TestsScale("Функциональное"),
                new TestsScale("Интеграционное")
            };
            dbContext.AddRange(testsScales);

            TestsCoverageLevel[] testCovers = {
                new TestsCoverageLevel("0-40%"),
                new TestsCoverageLevel("40-60%"),
                new TestsCoverageLevel("60-80%")
            };
            dbContext.AddRange(testCovers);


            TestsDevelopmentRateBuilder tdrb = new TestsDevelopmentRateBuilder(microArch[0], testsScales[0], testCovers[0]);
            TestsDevelopmentRate[] testDevRates = {
                tdrb.Create(1.1),
                tdrb.Create(testCovers[1], 1.2),
                tdrb.Create(testCovers[2], 1.5),
                tdrb.WithTestsScale(testsScales[1]).Create(testCovers[0], 1.05),
                tdrb.Create(testCovers[1], 1.1),
                tdrb.Create(testCovers[2], 1.3),
                tdrb.WithTestsScale(testsScales[2]).Create(testCovers[0], 1.2),
                tdrb.Create(testCovers[1], 1.3),
                tdrb.Create(testCovers[2], 1.6),

                tdrb.Create(microArch[1], testsScales[0], testCovers[0], 1),
                tdrb.Create(testCovers[1], 1.05),
                tdrb.Create(testCovers[2], 1.2),
                tdrb.WithTestsScale(testsScales[1]).Create(testCovers[0], 1.05),
                tdrb.Create(testCovers[1], 1.1),
                tdrb.Create(testCovers[2], 1.3),
                tdrb.WithTestsScale(testsScales[2]).Create(testCovers[0], 1.2),
                tdrb.Create(testCovers[1], 1.3),
                tdrb.Create(testCovers[2], 1.6),

                tdrb.Create(microArch[2], testsScales[0], testCovers[0], 1),
                tdrb.Create(testCovers[1], 1.05),
                tdrb.Create(testCovers[2], 1.2),
                tdrb.WithTestsScale(testsScales[1]).Create(testCovers[0], 1.05),
                tdrb.Create(testCovers[1], 1.05),
                tdrb.Create(testCovers[2], 1.2),
                tdrb.WithTestsScale(testsScales[2]).Create(testCovers[0], 1.2),
                tdrb.Create(testCovers[1], 1.3),
                tdrb.Create(testCovers[2], 1.6),

                tdrb.Create(microArch[3], testsScales[0], testCovers[0], 1.1),
                tdrb.Create(testCovers[1], 1.2),
                tdrb.Create(testCovers[2], 1.5),
                tdrb.WithTestsScale(testsScales[1]).Create(testCovers[0], 1.1),
                tdrb.Create(testCovers[1], 1.2),
                tdrb.Create(testCovers[2], 1.5),
                tdrb.WithTestsScale(testsScales[2]).Create(testCovers[0], 1.2),
                tdrb.Create(testCovers[1], 1.3),
                tdrb.Create(testCovers[2], 1.6)
            };
            dbContext.AddRange(testDevRates);
        }
    }
}