﻿using LaborVolumeCalculator.Models;
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
                new NirInnovationRate(nirScales[0], nirProps[0], (decimal)1.3 ),
                new NirInnovationRate(nirScales[0], nirProps[1], (decimal)1.7 ),
                new NirInnovationRate(nirScales[0], nirProps[2], (decimal)2.9 ),
                new NirInnovationRate(nirScales[1], nirProps[0], (decimal)1.0 ),
                new NirInnovationRate(nirScales[1], nirProps[1], (decimal)1.4 ),
                new NirInnovationRate(nirScales[1], nirProps[2], (decimal)2.5 ),
                new NirInnovationRate(nirScales[2], nirProps[0], (decimal)1.2 ),
                new NirInnovationRate(nirScales[2], nirProps[1], (decimal)1.7 ),
                new NirInnovationRate(nirScales[2], nirProps[2], (decimal)2.7 )
            );

            var dcREFU = new DeviceComposition("РЭФУ");
            var dcREU = new DeviceComposition("РЭУ");
            var dcSREU = new DeviceComposition("СРЭУ");

            dbContext.DeviceCompositions.AddRange(dcREFU, dcREU, dcSREU);

            var dcRange_1_5 = new DeviceCountRange("1 .. 5");
            var dcRange_6_10 = new DeviceCountRange("6 .. 10");
            var dcRange_11_20 = new DeviceCountRange("11 .. 20");

            dbContext.DeviceCountRange.AddRange(dcRange_1_5, dcRange_6_10, dcRange_11_20);

            dbContext.DeviceComplexityRates.AddRange(
                new DeviceComplexityRate(dcREFU,    dcRange_1_5,    (decimal)1.0),
                new DeviceComplexityRate(dcREFU,    dcRange_6_10,   (decimal)1.5),
                new DeviceComplexityRate(dcREFU,    dcRange_11_20,  (decimal)2.0),
                new DeviceComplexityRate(dcREU,     dcRange_1_5,    (decimal)1.0),
                new DeviceComplexityRate(dcREU,     dcRange_6_10,   (decimal)1.25),
                new DeviceComplexityRate(dcREU,     dcRange_11_20,  (decimal)1.5),
                new DeviceComplexityRate(dcSREU,    dcRange_1_5,    (decimal)1.0),
                new DeviceComplexityRate(dcSREU,    dcRange_6_10,   (decimal)1.4),
                new DeviceComplexityRate(dcSREU,    dcRange_11_20,  (decimal)1.8)
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

            double[] refuRatesValues =  { 3.0, 2.5, 2.0, 1.8, 1.6, 1.4, 1.2, 1.0, 0.9, 0.8, 0.7, 0.6, 0.5 };
            double[] reuRatesValues =   { 3.0, 2.5, 2.0, 1.5, 1.4, 1.3, 1.2, 1.1, 1.0, 0.9, 0.9, 0.8, 0.7, 0.6 };
            double[] sreuRatesValues =  { 4.0, 3.0, 2.5, 2.0, 1.5, 1.4, 1.3, 1.2, 1.1, 1.05, 1.0, 0.95, 0.9, 0.85, 0.8, 0.7 };

            var REFU_ratesBinder = new InnovationRatesBinder(dcREFU, okrInoProps.TakeLast(13));
            IEnumerable<OkrInnovationRate> refuRates = REFU_ratesBinder.Bind(refuRatesValues);
            dbContext.OkrInnovationRates.AddRange(refuRates);

            var REU_ratesBinder = new InnovationRatesBinder(dcREU, okrInoProps.TakeLast(14));
            IEnumerable<OkrInnovationRate> reuRates = REU_ratesBinder.Bind(reuRatesValues);
            dbContext.OkrInnovationRates.AddRange(reuRates);

            var SREU_ratesBinder = new InnovationRatesBinder(dcSREU, okrInoProps);
            IEnumerable<OkrInnovationRate> sreuRates = SREU_ratesBinder.Bind(sreuRatesValues);
            dbContext.OkrInnovationRates.AddRange(sreuRates);

            SeedNirStages();
            OkrStage[] okrStages = SeedOkrStages();

            SeedNirLabors();
            SeedNirSoftwareDevLaborGroups();

            SeedOkrLabors(okrStages);
            SeedOkrSoftwareDevLaborGroups(okrStages);

            SoftwareDevEnv[] devEnvironments = SeedSoftwareDevEnvironments();
            LaborCategory[] laborCategories = SeedLaborsCategories();
            SeedSoftwareDevLabors(laborCategories, devEnvironments);

            dbContext.SaveChanges();
        }

        private LaborCategory[] SeedLaborsCategories()
        {
            LaborCategory[] categories = 
            {
                new LaborCategory(1, "Обработка входных потоков"),
                new LaborCategory(2, "Управление ПО"),
                new LaborCategory(3, "Выходные потоки"),
                new LaborCategory(4, "Специальные функции обработки данных"),
                new LaborCategory(5, "Взаимодействие со сторонними ПО"),
                new LaborCategory(6, "Взаимодействие с внешним оборудованием"),
                new LaborCategory(7, "Сетевой взаимодействие"),
                new LaborCategory(8, "Архитектура компоненты"),
                new LaborCategory(9, "Создание базы данных"),
                new LaborCategory(10, "Функционирование базы данных"),
                new LaborCategory(11, "Разработка печатной платы")
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

        private void SeedSoftwareDevLabors(LaborCategory[] laborCategories, SoftwareDevEnv[] devEnvironments)
        {
            List<SoftwareDevLabor> labors = new List<SoftwareDevLabor>();

            void newLabor(string code, string name, LaborCategory category, SoftwareDevEnv[] devEnvironments, float[,]volumes)
            {
                int index = 0;
                foreach (var env in devEnvironments)
                {
                    var labor = new SoftwareDevLabor(code, name, category, env, (float)volumes[index, 0], (float)volumes[index, 1]);
                    labors.Add(labor);
                    index++;
                };
            };

            var category = laborCategories;
            var env = devEnvironments;
            newLabor("101", "Разбор файлов входных данных заданного формата", category[0], env[1..3], new [,]{ {0.5f, 1f}, {0.5f, 1.5f} });
            newLabor("102", "Разрбор потока данных заданного формата", category[0], env[1..3], new [,]{ {0.5f, 1.5f}, {2, 2} });
            newLabor("103", "Графический интерфейс ввода", category[0], new SoftwareDevEnv[]{ env[0], env[2] }, new [,]{ {1f, 2f}, {3, 4} });
            newLabor("104", "Консольный интерфейс ввода", category[0], env, new [,]{ {1f, 1f}, {1, 2}, {2, 2}, {3, 4} });
            newLabor("105", "Графический веб интерфейс (формы ввода данных)", category[0], env[0..1], new [,]{ {1f, 2f} });
            newLabor("106", "Интерфейс управления миниатюрным устройством, оснащенным тачскрином", category[0], env[2..3], new float[,]{ {1,5f, 2f} });
            newLabor("107", "Обработка входящий сообщений от системы обмена сообщениями", category[0], env[0..3], new float[,]{ {1.5f, 1.5f}, {1.5f, 1.5f}, {1.5f, 1.5f} });

            dbContext.SoftwareDevLabors.AddRange(labors);
        }

        private void SeedOkrSoftwareDevLaborGroups(OkrStage[] okrStages)
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

        private void SeedOkrLabors(OkrStage[] okrStages)
        {
            Func<string, string, float, float, OkrLabor> newOkrLabor = (code, name, minVolume, maxVolume) =>
            {
                int stageIndex = GetStageNumber(code);
                return new OkrLabor(code, name, okrStages[stageIndex - 1], minVolume, maxVolume);
            };

            OkrLabor[] okrLabors = new OkrLabor[]
            {
                newOkrLabor("1.1",
                    "Рарзработка укрупненного сетевого плана-графика работ на ОКР, перечня комплектности эскизного проекта",
                    0.1f, 0.25f),

                newOkrLabor("1.2",
                    "Поиск, сбор изучение технической информации, Выбор путей реализации основных СРЭУ системы (комплекса)",
                    0.5f, 1.5f),

                newOkrLabor("1.3",
                    "Разработка алгоритмов функционирования разрабатываемых в ходе выполнения  ОКР (СЧ ОКР) опытного образца " +
                    "(опытных образцов и специального программного обеспечения (на один ОО) (рекоммендуется разбить на подзадачи)",
                    0.5f, 2.5f ),

                // --- Stage 2 ---
                
                newOkrLabor("2.1",
                    "Корректировка укрупненного сетевого плана-графика работ по ОКР",
                    0.1f, 0.25f),

                newOkrLabor("2.2",
                    "Разработка перечней комплектности технического проекта: \n" +
                    " - РКД на ОО;\n" +
                    " - ЭД на ОО;",
                    0.1f, 0.35f),

                newOkrLabor("2.3",
                    "Разработка, согласование, утверждение схемы деления изделия на составные части",
                    0.1f, 0.25f),

                // --- Stage 3 ---

                newOkrLabor("3.3",
                    "Разработка программы и методик предварительных испытаний опытного образца изделия",
                    0.5f, 1.5f),

                newOkrLabor("3.4",
                    "Разработка и согласование ис заказчиком состава опытного образца (опытных образцов)," +
                    "создаваемого при проведении ОКР",
                    0.1f, 0.3f),

                newOkrLabor("3.5",
                    "Разработка и согласование с заказчиком инструкции по защите от ТСР ИГ и ее утечки по техническим каналам на этапе" +
                    "изготовления ОО и проведения предварительных испытаний",
                     0.1f, 0.3f),

                newOkrLabor("3.6",
                    "Рассмотрение сводки отзывов и результатов технического проекта на НТС, участие в работе комиссии по приемке этапа," +
                    "подготовка заключения заказчика и акта приемки этапа ОКР",
                    0.05f, 0.15f),

                // --- Stage 4 ---

                newOkrLabor("4.1",
                    "Разработка и создание опытного образца (рекомендуется разбить на подзадачи)",
                    0.5f, 10.0f),
                newOkrLabor("4.4",
                    "Комплексирование технических и программных средств ОО",
                    0.2f, 2.0f),

                // --- Stage 5 ---

                newOkrLabor("5.1",
                    "Разработка и согласование с заказчиком программы и методик государственных испытаний опытного образца изделия",
                    0.5f, 1.5f),

                newOkrLabor("5.2",
                    "Участие в государственных испытаниях, проводимых заказчиком",
                    0.15f, 0.3f),

                // --- Stage 6 ---

                newOkrLabor("6.2",
                    "Разработка и согласование с заказчиком документов по сервисному обслуживанию",
                    0.5f, 1.2f),

                newOkrLabor("6.3",
                    "Подготовка отчета о патентных исследованиях",
                    0.2f, 2.0f),

                // --- Stage 7 ---

                newOkrLabor("7.1",
                    "При наличии в ОКР составных частей, выполнение функции заказчика по отношению к исполнителям СЧ ОКР, включая " +
                    "разработку ТТЗ, координацию и контроль выполнения работ исполнителями СЧ ОКР на всех этапах выполнения СЧ ОКР",
                    0.5f, 2.0f),

                newOkrLabor("7.2",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля работ, выполняемых как на отдельных " +
                    "этапах, так и по ОКР в целом",
                    0.01f, 0.02f),

                newOkrLabor("7.3",
                    "Осуществление мероприятий по защите от ТСР ИГ в период проведения ОКР",
                    0.1f, 0.2f),

                newOkrLabor("7.4",
                    "Осуществление мероприятий по защите гостударственной тайны в период проведения ОКР",
                    0.1f, 0.2f),

                newOkrLabor("7.5",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ)",
                    0.1f, 0.25f),
            };

            dbContext.OkrLabors.AddRange(okrLabors);
        }

        private void SeedNirSoftwareDevLaborGroups()
        {
            Func<string, string, NirSoftwareDevLaborGroup> newNirGroup = (code, name) => {
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

        private void SeedNirLabors()
        {
            NirLabor[] nirLabors = new NirLabor[]
            {
                new NirLabor("1",
                    "Проведение научно-технического анализа состояния исследуемого вопроса, определение направлений(методов) исследований " +
                    "для обеспечения достижения поставленных в НИР целей исследования", 0.5f, 1.5f),

                new NirLabor("2",
                    "Определение перечня и содержания задач, решение которых в ходе выполнения НИР позволит достичь поставленной в НИР цели." +
                    "При наличии задач, сформулированных в ТТЗ в общем виде.", 0.5f, 0.6f),

                new NirLabor("3",
                    "Подготовка и направление заказчику необходимых документов для государственной регистрации, учета НИР и ОИС, " +
                    "получаемых в рамках НИР (СЧ НИР)", 0.1f, 0.2f),

                new NirLabor("4",
                    "При наличии в НИР составных частей выполнение функции заказчика по отношению к исполнителям СЧ НИР. " +
                    "Применяется либо п. 7, либо п.4", 0.2f, 1.0f),

                new NirLabor("5",
                    "Проведение патентных исследований, изучение на патентную чистоту ОИС, используемых при выполнении НИР, согласование с заказчиком " +
                    "лицензионных договоров на использование в НИР ОИС", 1.5f, 2.2f),

                new NirLabor("6",
                    "Подготовка отчета о патентных исследованиях", 0.2f, 1.0f),

                new NirLabor("7",
                    "Коордитация и контроль выполнения работ исполнителями СЧ НИР на всех этапах, опеспечение исполнителей СЧ НИР необходимыми материалам " +
                    "и информацией. Применяется либо п.7, либо п.4 ", 0.2f, 1.0f),

                new NirLabor("9",
                    "Уточнение(корректировка) и согласование с заказчиком состава макета(экспериментального образца), создаваемого при проведении НИР " +
                    "(при наличии соответствующего пункта в ТТЗ)", 0.02f, 0.05f),

                new NirLabor("11",
                    "Разработка и создание макетов, моделей, экспериментальных образцов технических средств (рекоммендуется разбить на подзадачи)", 0.5f, 1.5f),

                new NirLabor("13",
                    "Разработка и создание экспериментальных образцов аппаратно-программных комплексов (рекомендуется разбить на подзадачи)", 1.5f, 5.0f),

                new NirLabor("15",
                    "Установка и автономное тестирование разрабатываемого СПО", 0.2f, 0.5f),

                new NirLabor("16",
                    "Тестирование и отладка СПО на разрабатываемом экспериментальном образце", 0.1f, 1.5f),

                new NirLabor("17",
                    "Разработка и согласование с заказчиком методики встраивания разработканного в ходе выполнения НИР (СЧ НИР) экспериментального образца " +
                    "(макета) в образец ВТ заказчика", 0.3f, 0.6f),

                new NirLabor("18",
                    "Разработка и согласование с заказчиком Программы и методик исследований (испытаний) созданных в ходе выполнения НИР экспериментальных" +
                    "образцов (макетов, моделей)", 0.5f, 1.0f),

                new NirLabor("19",
                    "Проведение испытаний (исследований) созданного в ходе выполнения НИР специального программного обеспечения, макетов (моделей," +
                    "эксперементальных образцов) аппаратно-программных комплексов", 1.0f, 2.5f),

                new NirLabor("20",
                    "Оформление результатов проведенных исследований (испытаний) созданных в ходе выполнения НИР экспериментальных образцов (макетов, моделей)" +
                    "соответствующими протоколами (атаками)", 0.01f, 0.02f),

                new NirLabor("21",
                    "Разработка проекта ТЗ (ТТЗ) на ОКР", 0.5f, 1.5f),

                new NirLabor("22",
                    "Оценка технико-экономической эффективности результатов НИР, определение и обоснование необходимости проведения дальнейших исследований" +
                    " (в рамках НИР, ОКР", 0.02f, 0.08f),

                new NirLabor("24",
                    "Выборка рекомендаций по использованию результатов НИР", 0.01f, 0.02f),

                new NirLabor("25",
                    "Проведение рассмотрения результатов этапа НИР на НТС (секции НТС, техническом совещании специалистов)", 0.02f, 0.03f),

                new NirLabor("26",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля ходя и осуществления приемки НИР", 0.01f, 0.02f),

                new NirLabor("27",
                    "Осуществление мероприятий по защите государственной тайны в период проведения НИР", 0.1f, 0.2f),

                new NirLabor("28",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ) и условий контракта на " +
                    "выполнение НИР (СЧ НИР)", 0.1f, 0.25f),

                new NirLabor("29",
                    "Участие в работе комиссии по приемке этапов НИР и НИР в целом", 0.01f, 0.05f),
            };

            dbContext.NirLabors.AddRange(nirLabors);
        }

        private void SeedNirStages()
        {
            NirStage[] nirStages = new NirStage[]
            {
                new NirStage("Этап 1."),
                new NirStage("Этап 2."),
                new NirStage("Этап 3."),
                new NirStage("Этап 4."),
            };
            dbContext.NirStages.AddRange(nirStages);
        }

        private OkrStage[] SeedOkrStages()
        {
            OkrStage[] okrStages = new OkrStage[]
            {
                new OkrStage("Этап 1. Эскизный проект"),
                new OkrStage("Этап 2. Технический проект"),
                new OkrStage("Этап 3. Разработка РКД для изготовления ОО изделия"),
                new OkrStage("Этап 4. Изготовление ОО изделия"),
                new OkrStage("Этап 5. Проведение ГИ ОО"),
                new OkrStage("Этап 6. Утверждение РКД для организации промышленного(серийного) производства изделия"),
                new OkrStage("Работы, осуществляемые в ходе всей ОКР"),
            };
            dbContext.OkrStages.AddRange(okrStages);
            return okrStages;
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

            foreach(var rateValue in rateValues)
            {
                rates.Add(new OkrInnovationRate(innovationProperties.Current, deviceComposition, (decimal)rateValue));
                innovationProperties.MoveNext();
            }

            return rates;
        }
    }
}
