using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Reflection.Emit;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaborVolumeCalculator.Data
{
    public class DbSeed : IDisposable
    {
        private LVCContext dbContext;

        public DbSeed(LVCContext context)
        {
            this.dbContext = context;
        }

        public void Dispose()
        {
            dbContext = null;
        }

        public void Initialize()
        {
            dbContext.Database.Migrate();

            if (dbContext.NirScales.Any())
            {
                return;
            }

            NirScale[] nirScales =
            {
                new NirScale("Фундаметнальная НИР"),
                new NirScale("Прикладная НИР, без создания ЭО или макета"),
                new NirScale("Прикладная НИР, с разработкой и изготовлением ЭО или макета")
            };

            dbContext.NirScales.AddRange(nirScales);

            NirInnovationProperty[] nirProps =
            {
                new NirInnovationProperty("Работа в развитие предшествующей"),
                new NirInnovationProperty("Работа с известным аналогом"),
                new NirInnovationProperty("Работа, не имеющая известных аналогов")
            };

            dbContext.NirInnovationProperties.AddRange(nirProps);

            dbContext.NirInnovationRates.AddRange(
                new NirInnovationRate(nirScales[0], nirProps[0], 1.3),
                new NirInnovationRate(nirScales[0], nirProps[1], 1.7),
                new NirInnovationRate(nirScales[0], nirProps[2], 2.9),
                new NirInnovationRate(nirScales[1], nirProps[0], 1.0),
                new NirInnovationRate(nirScales[1], nirProps[1], 1.4),
                new NirInnovationRate(nirScales[1], nirProps[2], 2.5),
                new NirInnovationRate(nirScales[2], nirProps[0], 1.2),
                new NirInnovationRate(nirScales[2], nirProps[1], 1.7),
                new NirInnovationRate(nirScales[2], nirProps[2], 2.7)
            );

            var dcREFU = new DeviceComposition("РЭФУ");
            var dcREU = new DeviceComposition("РЭУ");
            var dcSREU = new DeviceComposition("СРЭУ");

            dbContext.DeviceCompositions.AddRange(dcREFU, dcREU, dcSREU);

            var dcRange_1_5 = new DeviceCountRange("1 .. 5");
            var dcRange_6_10 = new DeviceCountRange("6 .. 10");
            var dcRange_11_20 = new DeviceCountRange("11 .. 20");

            dbContext.DeviceCountRanges.AddRange(dcRange_1_5, dcRange_6_10, dcRange_11_20);

            dbContext.DeviceComplexityRates.AddRange(
                new DeviceComplexityRate(dcREFU, dcRange_1_5, 1.0),
                new DeviceComplexityRate(dcREFU, dcRange_6_10, 1.5),
                new DeviceComplexityRate(dcREFU, dcRange_11_20, 2.0),
                new DeviceComplexityRate(dcREU, dcRange_1_5, 1.0),
                new DeviceComplexityRate(dcREU, dcRange_6_10, 1.25),
                new DeviceComplexityRate(dcREU, dcRange_11_20, 1.5),
                new DeviceComplexityRate(dcSREU, dcRange_1_5, 1.0),
                new DeviceComplexityRate(dcSREU, dcRange_6_10, 1.4),
                new DeviceComplexityRate(dcSREU, dcRange_11_20, 1.8)
            );

            OkrInnovationProperty[] okrInoProps =
            {
                new OkrInnovationProperty("Заданные значения основных технических характеристик превышают достигнутые в мировой практике для изделий аналогичного назначения**"),
                new OkrInnovationProperty("Заданные значения 1-2 основных технических характеристик превышают достигнутые в мировой практике для изделий аналогичного назначения**"),
                new OkrInnovationProperty("Заданные значения основных технических характеристик соответствуют достигнутым в мировой практике для изделий аналогичного назначения**"),
                new OkrInnovationProperty("Изделие не имеющее аналогов в практике исполнителя"),
                new OkrInnovationProperty("Ужесточение требовний к двум и более основным техническим характеристикам*"),
                new OkrInnovationProperty("Ужесточение требований по подавлению НЭМИ*"),
                new OkrInnovationProperty("Ужесточение требования к основной технической характеристике* и условиям эксплуатации*"),
                new OkrInnovationProperty("Ужесточение требования к основной технической характеристике*"),
                new OkrInnovationProperty("Ужесточение требований по надежности*"),
                new OkrInnovationProperty("Ужесточение 1-2 неосновных тежнических характеристик*"),
                new OkrInnovationProperty("Новая конструкция аналога по техническим характеристикам"),
                new OkrInnovationProperty("Заимствование конструкции, наличие ранее созданного аналога по техническим характеристикам"),
                new OkrInnovationProperty("25% заимствование ранее созданного аналога"),
                new OkrInnovationProperty("50% заимствование ранее созданного аналога"),
                new OkrInnovationProperty("75% заимствование ранее созданного аналога"),
                new OkrInnovationProperty("Повторное изготовление изделия без изменений в ТД и КД")
            };

            dbContext.OkrInnovationProperties.AddRange(okrInoProps);

            double[] refuRatesValues = { 3.0, 2.5, 2.0, 1.8, 1.6, 1.4, 1.2, 1.0, 0.9, 0.8, 0.7, 0.6, 0.5 };
            double[] reuRatesValues = { 3.0, 2.5, 2.0, 1.5, 1.4, 1.3, 1.2, 1.1, 1.0, 0.9, 0.9, 0.8, 0.7, 0.6 };
            double[] sreuRatesValues = { 4.0, 3.0, 2.5, 2.0, 1.5, 1.4, 1.3, 1.2, 1.1, 1.05, 1.0, 0.95, 0.9, 0.85, 0.8, 0.7 };

            var REFU_ratesBinder = new InnovationRatesBinder(dcREFU, okrInoProps.TakeLast(13));
            IEnumerable<OkrInnovationRate> refuRates = REFU_ratesBinder.Bind(refuRatesValues);
            dbContext.OkrInnovationRates.AddRange(refuRates);

            var REU_ratesBinder = new InnovationRatesBinder(dcREU, okrInoProps.TakeLast(14));
            IEnumerable<OkrInnovationRate> reuRates = REU_ratesBinder.Bind(reuRatesValues);
            dbContext.OkrInnovationRates.AddRange(reuRates);

            var SREU_ratesBinder = new InnovationRatesBinder(dcSREU, okrInoProps);
            IEnumerable<OkrInnovationRate> sreuRates = SREU_ratesBinder.Bind(sreuRatesValues);
            dbContext.OkrInnovationRates.AddRange(sreuRates);

            StageForOkr[] okrStages = SeedOkrStages();

            NirLabor[] nirLabors = SeedNirLabors();
            SeedNirSoftwareDevLaborGroups();

            SeedOkrLabors(okrStages);
            SeedOkrSoftwareDevLaborGroups(okrStages);

            SoftwareDevEnv[] devEnvironments = SeedSoftwareDevEnvironments();
            DevelopmentLaborCategory[] laborCategories = SeedLaborsCategories();
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

            dbContext.SaveChanges();
        }

        private void SeedNirStageDefaultLabors(StageForNir[] nirStages, NirLabor[] nirLabors)
        {
            NirLabor getLabor(string code) {
                return nirLabors.First(l => l.Code == code);
            }

            var nslb = new NirStageDefaultLaborsBuilder(nirStages[0]);
            NirStageDefaultLabor[] nirStageDefaultLabors = new NirStageDefaultLabor[] {
                nslb.Create(getLabor("5")),
                nslb.Create(getLabor("6")),
                nslb.Create(getLabor("1")),
                nslb.Create(getLabor("2")),
                nslb.Create(getLabor("9")),
                nslb.Create(getLabor("25")),
                nslb.Create(getLabor("29"))
            };
            dbContext.AddRange(nirStageDefaultLabors);
        }

        private DevelopmentLaborCategory[] SeedLaborsCategories()
        {
            DevelopmentLaborCategory[] categories =
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
            dbContext.LaborCategories.AddRange(categories);

            return categories;
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
            SoftwareDevLabor[] labors = new SoftwareDevLabor[] {
                new SoftwareDevLabor("101", "Разбор файлов входных данных заданного формата", categories[0]),
                new SoftwareDevLabor("102", "Разрбор потока данных заданного формата", categories[0]),
                new SoftwareDevLabor("103", "Графический интерфейс ввода", categories[0]),
                new SoftwareDevLabor("104", "Консольный интерфейс ввода", categories[0]),
                new SoftwareDevLabor("105", "Графический веб интерфейс (формы ввода данных)", categories[0]),
                new SoftwareDevLabor("106", "Интерфейс управления миниатюрным устройством, оснащенным тачскрином", categories[0]),
                new SoftwareDevLabor("107", "Обработка входящих сообщений от системы обмена сообщениями", categories[0])
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

        private void SeedOkrSoftwareDevLaborGroups(StageForOkr[] okrStages)
        {
            Func<string, string, OkrSoftwareDevLaborGroup> newOkrGroup = (code, name) =>
            {
                int stageIndex = GetStageNumber(code);
                return new OkrSoftwareDevLaborGroup(code, name, okrStages[stageIndex - 1]);
            };

            OkrSoftwareDevLaborGroup[] OkrSoftwareGroups = new OkrSoftwareDevLaborGroup[]
            {
                newOkrGroup("2.7", "Разрабока состава, уточнение функций и перечня задач СПО"),
                newOkrGroup("2.13", "Разработка СПО функционирования комплекса, СРЭУ"),
                newOkrGroup("2.15", "Комплексная регулировка СРЭУ, проверка С"),
                newOkrGroup("3.2", "Разработка одного программного модуля (программного компонента), опытного образца СПО"),
                newOkrGroup("4.2", "Разработка СПО"),
                newOkrGroup("4.3", "Консолидация и адаптация программных компонентов разрабатываемого СПО"),
                newOkrGroup("4.5", "Тестирование и отладка СПО на разрабатываемом опытном образце"),
                newOkrGroup("4.17", "Комплексная регулировка ОО комплекса. Отработка СПО. Подготовка к предъявлению ОТК и ПЗ"),
                newOkrGroup("4.26", "Корректировка СПО по результатам ПИ ОО изделия")
            };

            dbContext.OkrSoftwareDevLaborGroups.AddRange(OkrSoftwareGroups);
        }

        private static int GetStageNumber(string code)
        {
            return int.Parse(code.Split('.')[0]);
        }

        private void SeedOkrLabors(StageForOkr[] okrStages)
        {
            Func<string, string, double, double, OkrLabor> newOkrLabor = (code, name, minVolume, maxVolume) =>
            {
                int stageIndex = GetStageNumber(code);
                return new OkrLabor(code, name, okrStages[stageIndex - 1], minVolume, maxVolume);
            };

            OkrLabor[] okrLabors = new OkrLabor[]
            {
                newOkrLabor("1.1",
                    "Рарзработка укрупненного сетевого плана-графика работ на ОКР, перечня комплектности эскизного проекта",
                    0.1, 0.25),

                newOkrLabor("1.2",
                    "Поиск, сбор изучение технической информации, Выбор путей реализации основных СРЭУ системы (комплекса)",
                    0.5, 1.5),

                newOkrLabor("1.3",
                    "Разработка алгоритмов функционирования разрабатываемых в ходе выполнения  ОКР (СЧ ОКР) опытного образца " +
                    "(опытных образцов и специального программного обеспечения (на один ОО) (рекоммендуется разбить на подзадачи)",
                    0.5, 2.5),

                // --- Stage 2 ---
                
                newOkrLabor("2.1",
                    "Корректировка укрупненного сетевого плана-графика работ по ОКР",
                    0.1, 0.25),

                newOkrLabor("2.2",
                    "Разработка перечней комплектности технического проекта: \n" +
                    " - РКД на ОО;\n" +
                    " - ЭД на ОО;",
                    0.1, 0.35),

                newOkrLabor("2.3",
                    "Разработка, согласование, утверждение схемы деления изделия на составные части",
                    0.1, 0.25),

                // --- Stage 3 ---

                newOkrLabor("3.3",
                    "Разработка программы и методик предварительных испытаний опытного образца изделия",
                    0.5, 1.5),

                newOkrLabor("3.4",
                    "Разработка и согласование ис заказчиком состава опытного образца (опытных образцов)," +
                    "создаваемого при проведении ОКР",
                    0.1, 0.3),

                newOkrLabor("3.5",
                    "Разработка и согласование с заказчиком инструкции по защите от ТСР ИГ и ее утечки по техническим каналам на этапе" +
                    "изготовления ОО и проведения предварительных испытаний",
                     0.1, 0.3),

                newOkrLabor("3.6",
                    "Рассмотрение сводки отзывов и результатов технического проекта на НТС, участие в работе комиссии по приемке этапа," +
                    "подготовка заключения заказчика и акта приемки этапа ОКР",
                    0.05, 0.15),

                // --- Stage 4 ---

                newOkrLabor("4.1",
                    "Разработка и создание опытного образца (рекомендуется разбить на подзадачи)",
                    0.5, 10.0),
                newOkrLabor("4.4",
                    "Комплексирование технических и программных средств ОО",
                    0.2, 2.0),

                // --- Stage 5 ---

                newOkrLabor("5.1",
                    "Разработка и согласование с заказчиком программы и методик государственных испытаний опытного образца изделия",
                    0.5, 1.5),

                newOkrLabor("5.2",
                    "Участие в государственных испытаниях, проводимых заказчиком",
                    0.15, 0.3),

                // --- Stage 6 ---

                newOkrLabor("6.2",
                    "Разработка и согласование с заказчиком документов по сервисному обслуживанию",
                    0.5, 1.2),

                newOkrLabor("6.3",
                    "Подготовка отчета о патентных исследованиях",
                    0.2, 2.0),

                // --- Stage 7 ---

                newOkrLabor("7.1",
                    "При наличии в ОКР составных частей, выполнение функции заказчика по отношению к исполнителям СЧ ОКР, включая " +
                    "разработку ТТЗ, координацию и контроль выполнения работ исполнителями СЧ ОКР на всех этапах выполнения СЧ ОКР",
                    0.5, 2.0),

                newOkrLabor("7.2",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля работ, выполняемых как на отдельных " +
                    "этапах, так и по ОКР в целом",
                    0.01, 0.02),

                newOkrLabor("7.3",
                    "Осуществление мероприятий по защите от ТСР ИГ в период проведения ОКР",
                    0.1, 0.2),

                newOkrLabor("7.4",
                    "Осуществление мероприятий по защите гостударственной тайны в период проведения ОКР",
                    0.1, 0.2),

                newOkrLabor("7.5",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ)",
                    0.1, 0.25),
            };

            dbContext.OkrLabors.AddRange(okrLabors);
        }

        private void SeedNirSoftwareDevLaborGroups()
        {
            Func<string, string, NirSoftwareDevLaborGroup> newNirGroup = (code, name) =>
            {
                return new NirSoftwareDevLaborGroup(code, name);
            };

            NirSoftwareDevLaborGroup[] NirSoftwareGroups = new NirSoftwareDevLaborGroup[]
            {
                newNirGroup("8", "Разработка алгоритмов функционирования, разрабатываемых в ходе выполнения НИР (СЧ НИР) СПО, " +
                                "макетов (моделей, экспериментальных образцов) аппаратно-программных комплексов"),
                newNirGroup("10", "Исследование возможности разработки, разработка одного программного модуля (программного компонента) СПО"),
                newNirGroup("12", "Разработки и создание СПО (программных модулей)"),
                newNirGroup("14", "Консолидация и адаптация программных компонентов, разрабатываемого СПО")
            };

            dbContext.SoftwareDevLaborGroups.AddRange(NirSoftwareGroups);
        }

        private NirLabor[] SeedNirLabors()
        {
            NirLabor[] nirLabors = new NirLabor[]
            {
                new NirLabor("1",
                    "Проведение научно-технического анализа состояния исследуемого вопроса, определение направлений(методов) исследований " +
                    "для обеспечения достижения поставленных в НИР целей исследования", 0.5, 1.5),

                new NirLabor("2",
                    "Определение перечня и содержания задач, решение которых в ходе выполнения НИР позволит достичь поставленной в НИР цели." +
                    "При наличии задач, сформулированных в ТТЗ в общем виде.", 0.5, 0.6),

                new NirLabor("3",
                    "Подготовка и направление заказчику необходимых документов для государственной регистрации, учета НИР и ОИС, " +
                    "получаемых в рамках НИР (СЧ НИР)", 0.1, 0.2),

                new NirLabor("4",
                    "При наличии в НИР составных частей выполнение функции заказчика по отношению к исполнителям СЧ НИР. " +
                    "Применяется либо п. 7, либо п.4", 0.2, 1.0),

                new NirLabor("5",
                    "Проведение патентных исследований, изучение на патентную чистоту ОИС, используемых при выполнении НИР, согласование с заказчиком " +
                    "лицензионных договоров на использование в НИР ОИС", 1.5, 2.2),

                new NirLabor("6",
                    "Подготовка отчета о патентных исследованиях", 0.2, 1.0),

                new NirLabor("7",
                    "Коордитация и контроль выполнения работ исполнителями СЧ НИР на всех этапах, опеспечение исполнителей СЧ НИР необходимыми материалам " +
                    "и информацией. Применяется либо п.7, либо п.4 ", 0.2, 1.0),

                new NirLabor("9",
                    "Уточнение(корректировка) и согласование с заказчиком состава макета(экспериментального образца), создаваемого при проведении НИР " +
                    "(при наличии соответствующего пункта в ТТЗ)", 0.02, 0.05),

                new NirLabor("11",
                    "Разработка и создание макетов, моделей, экспериментальных образцов технических средств (рекоммендуется разбить на подзадачи)", 0.5, 1.5),

                new NirLabor("13",
                    "Разработка и создание экспериментальных образцов аппаратно-программных комплексов (рекомендуется разбить на подзадачи)", 1.5, 5.0),

                new NirLabor("15",
                    "Установка и автономное тестирование разрабатываемого СПО", 0.2, 0.5),

                new NirLabor("16",
                    "Тестирование и отладка СПО на разрабатываемом экспериментальном образце", 0.1, 1.5),

                new NirLabor("17",
                    "Разработка и согласование с заказчиком методики встраивания разработканного в ходе выполнения НИР (СЧ НИР) экспериментального образца " +
                    "(макета) в образец ВТ заказчика", 0.3, 0.6),

                new NirLabor("18",
                    "Разработка и согласование с заказчиком Программы и методик исследований (испытаний) созданных в ходе выполнения НИР экспериментальных" +
                    "образцов (макетов, моделей)", 0.5, 1.0),

                new NirLabor("19",
                    "Проведение испытаний (исследований) созданного в ходе выполнения НИР специального программного обеспечения, макетов (моделей," +
                    "эксперементальных образцов) аппаратно-программных комплексов", 1.0, 2.5),

                new NirLabor("20",
                    "Оформление результатов проведенных исследований (испытаний) созданных в ходе выполнения НИР экспериментальных образцов (макетов, моделей)" +
                    "соответствующими протоколами (атаками)", 0.01, 0.02),

                new NirLabor("21",
                    "Разработка проекта ТЗ (ТТЗ) на ОКР", 0.5, 1.5),

                new NirLabor("22",
                    "Оценка технико-экономической эффективности результатов НИР, определение и обоснование необходимости проведения дальнейших исследований" +
                    " (в рамках НИР, ОКР", 0.02, 0.08),

                new NirLabor("24",
                    "Выборка рекомендаций по использованию результатов НИР", 0.01, 0.02),

                new NirLabor("25",
                    "Проведение рассмотрения результатов этапа НИР на НТС (секции НТС, техническом совещании специалистов)", 0.02, 0.03),

                new NirLabor("26",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля ходя и осуществления приемки НИР", 0.01, 0.02),

                new NirLabor("27",
                    "Осуществление мероприятий по защите государственной тайны в период проведения НИР", 0.1, 0.2),

                new NirLabor("28",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ) и условий контракта на " +
                    "выполнение НИР (СЧ НИР)", 0.1, 0.25),

                new NirLabor("29",
                    "Участие в работе комиссии по приемке этапов НИР и НИР в целом", 0.01, 0.05),
            };

            dbContext.NirLabors.AddRange(nirLabors);
            return nirLabors;
        }

        private StageForOkr[] SeedOkrStages()
        {
            StageForOkr[] okrStages = new StageForOkr[]
            {
                new StageForOkr("Этап 1. Эскизный проект"),
                new StageForOkr("Этап 2. Технический проект"),
                new StageForOkr("Этап 3. Разработка РКД для изготовления ОО изделия"),
                new StageForOkr("Этап 4. Изготовление ОО изделия"),
                new StageForOkr("Этап 5. Проведение ГИ ОО"),
                new StageForOkr("Этап 6. Утверждение РКД для организации промышленного(серийного) производства изделия"),
                new StageForOkr("Работы, осуществляемые в ходе всей ОКР"),
            };
            dbContext.StagesForOkr.AddRange(okrStages);
            return okrStages;
        }

    }

    internal class TestsDevelopmentRateBuilder
    {
        public TestsDevelopmentRateBuilder(ComponentsMicroArchitecture componentsMicroArchitecture, TestsScale testsScale, TestsCoverageLevel testsCoverageLevel)
        {
            ComponentsMicroArchitecture = componentsMicroArchitecture;
            TestsScale = testsScale;
            TestsCoverageLevel = testsCoverageLevel;
        }

        private ComponentsMicroArchitecture ComponentsMicroArchitecture { get; set; }

        private TestsScale TestsScale { get; set; }
        private TestsCoverageLevel TestsCoverageLevel { get; set; }

        public TestsDevelopmentRate Create(double value)
        {
            return new TestsDevelopmentRate(ComponentsMicroArchitecture, TestsScale, TestsCoverageLevel, value);
        }

        public TestsDevelopmentRateBuilder WithMicroArch(ComponentsMicroArchitecture arch)
        {
            this.ComponentsMicroArchitecture = arch;
            return this;
        }

        public TestsDevelopmentRateBuilder WithTestsScale(TestsScale scale)
        {
            this.TestsScale = scale;
            return this;
        }

        public TestsDevelopmentRateBuilder WithTestsCoverLevel(TestsCoverageLevel level)
        {
            this.TestsCoverageLevel = level;
            return this;
        }

        public TestsDevelopmentRate Create(TestsCoverageLevel level, double value)
        {
            return this.WithTestsCoverLevel(level).Create(value);
        }

        public TestsDevelopmentRate Create(ComponentsMicroArchitecture arch, TestsScale scale, TestsCoverageLevel coverLevel, double value)
        {
            return this.WithMicroArch(arch).WithTestsScale(scale).WithTestsCoverLevel(coverLevel).Create(value);
        }

    }

    internal class InnovationRatesBinder
    {

        public InnovationRatesBinder(DeviceComposition deviceComposition, IEnumerable<OkrInnovationProperty> okrInnovationProperties)
        {
            this.deviceComposition = deviceComposition ?? throw new ArgumentNullException("deviceComposition");
            this.okrInnovationProperties = okrInnovationProperties ?? throw new ArgumentNullException("okrInnovationProperties");
        }

        private readonly DeviceComposition deviceComposition;
        private readonly IEnumerable<OkrInnovationProperty> okrInnovationProperties;

        public IEnumerable<OkrInnovationRate> Bind(IEnumerable<double> rateValues)
        {
            List<OkrInnovationRate> rates = new List<OkrInnovationRate>();
            IEnumerator<OkrInnovationProperty> innovationProperties = okrInnovationProperties.GetEnumerator();
            innovationProperties.MoveNext();

            foreach (var rateValue in rateValues)
            {
                rates.Add(new OkrInnovationRate(innovationProperties.Current, deviceComposition, rateValue));
                innovationProperties.MoveNext();
            }

            return rates;
        }
    }

    internal class NirStageDefaultLaborsBuilder
    {
        private StageForNir _nirStage;
        public NirStageDefaultLaborsBuilder(StageForNir stage)
        {
            this._nirStage = stage;
        }

        public NirStageDefaultLaborsBuilder WithStage(StageForNir stage) {
            _nirStage = stage;
            return this;
        }

        public NirStageDefaultLabor Create(NirLabor labor) 
        {
            return new NirStageDefaultLabor(_nirStage, labor);
        }
    }

    internal class SoftwareDevLaborVolumeRangeBuilder
    {
        private SoftwareDevLabor _labor;

        public SoftwareDevLaborVolumeRangeBuilder(SoftwareDevLabor labor)
        {
            this._labor = labor;
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double volume)
        {
            return Create(labor, devEnv, volume, volume);
        }

        public SoftwareDevLaborVolumeRange Create(SoftwareDevLabor labor, SoftwareDevEnv devEnv, double minVolume, double maxVolume)
        {
            this._labor = labor;
            return Create(devEnv, minVolume, maxVolume);
        }
        
        public SoftwareDevLaborVolumeRange Create(SoftwareDevEnv devEnv, double volume)
        {
            return Create(devEnv, volume, volume);
        }
        public SoftwareDevLaborVolumeRange Create(SoftwareDevEnv devEnv, double minVolume, double maxVolume)
        {
            return new SoftwareDevLaborVolumeRange(_labor, devEnv, minVolume, maxVolume);
        }
    }
}
