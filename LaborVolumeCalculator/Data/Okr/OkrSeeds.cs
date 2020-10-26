using System;
using System.Collections.Generic;
using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Okr
{
    public class OkrSeeds
    {
        private readonly LVCContext dbContext;
        public OkrSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize()
        {
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

            SeedOkrLabors(okrStages);
            SeedOkrSoftwareDevLaborGroups(okrStages);
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
        
    }
}