using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class SoftwareDevSeeds
    {
        private readonly LVCContext dbContext;
        public SoftwareDevSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize(DevelopmentLaborCategory[] laborCategories)
        {
            SoftwareDevEnv[] devEnvironments = SeedSoftwareDevEnvironments();
            SoftwareDevLabor[] softLabors = SeedSoftwareDevLabors(laborCategories);
            SeedSoftwareDevLaborVolumeRanges(softLabors, devEnvironments);

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

        private SoftwareDevEnv[] SeedSoftwareDevEnvironments()
        {
            SoftwareDevEnv[] environments =
            {
                new SoftwareDevEnv("PHP/JavaScript"),
                new SoftwareDevEnv("Perl/Ruby/Python"),
                new SoftwareDevEnv("C++/C#/Java/Objective-C"),
                new SoftwareDevEnv("ASM")
            };
            dbContext.SoftwareDevEnvs.AddRange(environments);
            return environments;
        }

        private SoftwareDevLabor[] SeedSoftwareDevLabors(DevelopmentLaborCategory[] categories)
        {
            var lb = new SoftwareDevLaborBuilder(categories).SetCategory(1);

            SoftwareDevLabor[] labors = new SoftwareDevLabor[] {
                lb.Create(101, "Разбор файлов входных данных заданного формата"),
                lb.Create(102, "Разрбор потока данных заданного формата"),
                lb.Create(103, "Графический интерфейс ввода"),
                lb.Create(104, "Консольный интерфейс ввода"),
                lb.Create(105, "Графический веб интерфейс (формы ввода данных)"),
                lb.Create(106, "Интерфейс управления миниатюрным устройством, оснащенным тачскрином"),
                lb.Create(107, "Обработка входящих сообщений от системы обмена сообщениями"),
                
                lb.SetCategory(2).Create(201, "Графический интерфейс мониторинга и управления ПО"),
                lb.Create(202, "Графический интерфейс на базе веб-приложения(одна страница)"),
                lb.Create(203, "Консольный интерфейс управления и мониторинга ПО"),
                lb.Create(204, "Графический веб-интерфейс для приложений для настольных систем (одна страница)"),
                lb.Create(205, "Реализация REST API"),
                lb.Create(206, "Интерфейс управления ПО через систему обмена сообщениями"),
                lb.Create(207, "Интерфейс управления миниатюрным устройством, оснащенным тачскрином"),

                lb.SetCategory(3).Create(301, "Генерация визуальных форм (в том числе и веб-форм)"),
                lb.Create(302, "Формирование потока данных заданного формата"),
                lb.Create(303, "Формирование файлов отчетов"),
                lb.Create(304, "Генерация образцов ПО"),
                lb.Create(305, "Отправка сообщений через систему обмена сообщениями"),
                lb.Create(306, "Подсистема взаимодействия с базой данных"),

                lb.SetCategory(4).Create(401, "Кодирование/декодирование данных"),
                lb.Create(402, "Сжатие/распаковка данных"),
                lb.Create(403, "Сложное математическое преобразование данных"),

                lb.SetCategory(5).Create(501, "Создание входных потоков данных для стороннего ПО"),
                lb.Create(502, "Модификация выходных потоков стороннего ПО"),
                lb.Create(503, "Взаимодействие с пользовательским интерфейсом стороннего ПО"),
                lb.Create(504, "Модификация модуля стороннего ПО (с программным кодом)"),
                lb.Create(505, "Модификация модуля стороннего ПО (без программного кода)"),
                lb.Create(506, "Реализация подключаемого модуля для стороннего ПО"),
                lb.Create(507, "Модуль мониторинга активности стороннего ПО (на один модуль)"),
                lb.Create(508, "Автоматизация работы стороннего ПО"),
                lb.Create(509, "Автоматизация настройки сетевого ПО"),

                lb.SetCategory(6).Create(601, "Создание драйверов устройств"),
                lb.Create(602, "Разработка модулей программ, функционирующих на внешнем оборудовании"),
                lb.Create(603, "Создание программ загрузки модулей на внешнее оборудование"),
                lb.Create(604, "Разработка модулей программ, взаимодействующих с внешним оборудованием (без разработки драйверов)"),
                lb.Create(605, "Разработка компонентов ОС кроме драйверов устройств (файловой системы, сетевой подсистемы, службы безопасности"),
                
                lb.SetCategory(7).Create(701, "Модуль клиента сети"),
                lb.Create(702, "Серверный модуль"),
                lb.Create(703, "Модуль поиска оборудования"),
                lb.Create(704, "Модуль взаимодействия с системой сообщений"),
                lb.Create(705, "Разработка и (или) реализация сетевых протоколов"),

                lb.SetCategory(8).Create(801, "Процедурная архитектура"),
                lb.Create(802, "Асинхронная архитектура"),
                lb.Create(803, "Микроядерная архитектура")
            };

            dbContext.SoftwareDevLabors.AddRange(labors);
            return labors;
        }

        private SoftwareDevLaborVolumeRange[] SeedSoftwareDevLaborVolumeRanges(SoftwareDevLabor[] labors, SoftwareDevEnv[] devEnv)
        {
            var _PHP_JS = devEnv[0];
            var _Perl_Ruby_Pyton = devEnv[1];
            var _Cpp_Cs_Java_ObjC = devEnv[2];
            var _Asm = devEnv[3];

            var rb = new SoftwareDevLaborVolumeRangeBuilder(labors[0]);
            SoftwareDevLaborVolumeRange[] ranges = new SoftwareDevLaborVolumeRange[]
            {
                rb.Create(_Perl_Ruby_Pyton, 0.5, 1),
                rb.Create(_Cpp_Cs_Java_ObjC, 0.5, 1.5),
                
                rb.Create(labors[1], _Perl_Ruby_Pyton, 0.5, 1.5),
                rb.Create(_Cpp_Cs_Java_ObjC, 2),
                
                rb.Create(labors[2], _PHP_JS, 1, 2),
                rb.Create(_Cpp_Cs_Java_ObjC, 3, 4),
                
                rb.Create(labors[3], _PHP_JS, 1),
                rb.Create(_Perl_Ruby_Pyton, 1, 2),
                rb.Create(_Cpp_Cs_Java_ObjC, 2),
                rb.Create(_Asm, 3, 4),

                rb.Create(labors[4], _PHP_JS, 1, 2),
                rb.Create(labors[5], _Cpp_Cs_Java_ObjC, 1.5, 2),
                
                rb.Create(labors[6], _PHP_JS, 1.5),
                rb.Create(_Perl_Ruby_Pyton, 1.5),
                rb.Create(_Cpp_Cs_Java_ObjC, 1.5)
            };
            
            dbContext.SoftwareDevLaborVolumeRanges.AddRange(ranges);
            return ranges;
        }
    }
}