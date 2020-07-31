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

            var NirCategory = NiokrCategory.NIR;
            var OkrCategory = NiokrCategory.OKR;
            dbContext.NiokrCategories.Add(NirCategory);
            dbContext.NiokrCategories.Add(OkrCategory);

            SeedNirStages(NirCategory);
            SeedOkrStages(OkrCategory);
            dbContext.SaveChanges();

            SeedNirLabors();
            SeedOkrLabors();

            dbContext.SaveChanges();
        }

        private void SeedOkrLabors()
        {
            OkrStage okrStage1 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 1."));
            OkrStage okrStage2 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 2."));
            OkrStage okrStage3 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 3."));
            OkrStage okrStage4 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 4."));
            OkrStage okrStage5 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 5."));
            OkrStage okrStage6 = dbContext.OkrStages.First(n => n.Name.Contains("Этап 6."));
            OkrStage okrStage7 = dbContext.OkrStages.First(n => n.Name.Contains("Работы, осуществляемые в ходе всей ОКР"));

            OkrLabor[] okrLabors = new OkrLabor[]
            {
                new OkrLabor("2.1.1",
                    "Рарзработка укрупненного сетевого плана-графика работ на ОКР, перечня комплектности эскизного проекта",
                    okrStage1, 0.1f, 0.25f),

                new OkrLabor("2.1.2",
                    "Поиск, сбор изучение технической информации, Выбор путей реализации основных СРЭУ системы (комплекса)",
                    okrStage1, 0.5f, 1.5f),

                new OkrLabor("2.1.3",
                    "Разработка алгоритмов функционирования разрабатываемых в ходе выполнения  ОКР (СЧ ОКР) опытного образца " +
                    "(опытных образцов и специального программного обеспечения (на один ОО) (рекоммендуется разбить на подзадачи)",
                    okrStage1, 0.5f, 2.5f ),

                // --- Stage 2 ---
                
                new OkrLabor("2.2.1",
                    "Корректировка укрупненного сетевого плана-графика работ по ОКР",
                    okrStage2, 0.1f, 0.25f),

                new OkrLabor("2.2.2",
                    "Разработка перечней комплектности технического проекта: \n" +
                    " - РКД на ОО;\n" +
                    " - ЭД на ОО;"
                    , okrStage2, 0.1f, 0.35f),

                new OkrLabor("2.2.3",
                    "Разработка, согласование, утверждение схемы деления изделия на составные части",
                    okrStage2, 0.1f, 0.25f),

                // --- Stage 3 ---

                new OkrLabor("2.3.3",
                    "Разработка программы и методик предварительных испытаний опытного образца изделия",
                    okrStage3, 0.5f, 1.5f),

                new OkrLabor("2.3.4",
                    "Разработка и согласование ис заказчиком состава опытного образца (опытных образцов)," +
                    "создаваемого при проведении ОКР",
                    okrStage3, 0.1f, 0.3f),

                new OkrLabor("2.3.5",
                    "Разработка и согласование с заказчиком инструкции по защите от ТСР ИГ и ее утечки по техническим каналам на этапе" +
                    "изготовления ОО и проведения предварительных испытаний",
                    okrStage3,  0.1f, 0.3f),

                new OkrLabor("2.3.6",
                    "Рассмотрение сводки отзывов и результатов технического проекта на НТС, участие в работе комиссии по приемке этапа," +
                    "подготовка заключения заказчика и акта приемки этапа ОКР",
                    okrStage3, 0.05f, 0.15f),

                // --- Stage 4 ---

                new OkrLabor("2.4.1",
                    "Разработка и создание опытного образца (рекомендуется разбить на подзадачи)",
                    okrStage4, 0.5f, 10.0f),
                new OkrLabor("2.4.4",
                    "Комплексирование технических и программных средств ОО",
                    okrStage4, 0.2f, 2.0f),

                // --- Stage 5 ---

                new OkrLabor("2.5.1",
                    "Разработка и согласование с заказчиком программы и методик государственных испытаний опытного образца изделия",
                    okrStage5, 0.5f, 1.5f),

                new OkrLabor("2.5.2",
                    "Участие в государственных испытаниях, проводимых заказчиком",
                    okrStage5, 0.15f, 0.3f),

                // --- Stage 6 ---

                new OkrLabor("2.6.2",
                    "Разработка и согласование с заказчиком документов по сервисному обслуживанию",
                    okrStage6, 0.5f, 1.2f),

                new OkrLabor("2.6.3",
                    "Подготовка отчета о патентных исследованиях",
                    okrStage6, 0.2f, 2.0f),

                // --- Stage 7 ---

                new OkrLabor("2.7.1",
                    "При наличии в ОКР составных частей, выполнение функции заказчика по отношению к исполнителям СЧ ОКР, включая " +
                    "разработку ТТЗ, координацию и контроль выполнения работ исполнителями СЧ ОКР на всех этапах выполнения СЧ ОКР",
                    okrStage7, 0.5f, 2.0f),

                new OkrLabor("2.7.2",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля работ, выполняемых как на отдельных " +
                    "этапах, так и по ОКР в целом",
                    okrStage7, 0.01f, 0.02f),

                new OkrLabor("2.7.3",
                    "Осуществление мероприятий по защите от ТСР ИГ в период проведения ОКР",
                    okrStage7, 0.1f, 0.2f),

                new OkrLabor("2.7.4",
                    "Осуществление мероприятий по защите гостударственной тайны в период проведения ОКР",
                    okrStage7, 0.1f, 0.2f),

                new OkrLabor("2.7.5",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ)",
                    okrStage7, 0.1f, 0.25f),
            };

            dbContext.OkrLabors.AddRange(okrLabors);
        }

        private void SeedNirLabors()
        {
            NirLabor[] nirLabors = new NirLabor[]
            {
                new NirLabor("1.1",
                    "Проведение научно-технического анализа состояния исследуемого вопроса, определение направлений(методов) исследований " +
                    "для обеспечения достижения поставленных в НИР целей исследования", 0.5f, 1.5f),

                new NirLabor("1.2",
                    "Определение перечня и содержания задач, решение которых в ходе выполнения НИР позволит достичь поставленной в НИР цели." +
                    "При наличии задач, сформулированных в ТТЗ в общем виде.", 0.5f, 0.6f),

                new NirLabor("1.3",
                    "Подготовка и направление заказчику необходимых документов для государственной регистрации, учета НИР и ОИС, " +
                    "получаемых в рамках НИР (СЧ НИР)", 0.1f, 0.2f),

                new NirLabor("1.4",
                    "При наличии в НИР составных частей выполнение функции заказчика по отношению к исполнителям СЧ НИР. " +
                    "Применяется либо п. 7, либо п.4", 0.2f, 1.0f),

                new NirLabor("1.5",
                    "Проведение патентных исследований, изучение на патентную чистоту ОИС, используемых при выполнении НИР, согласование с заказчиком " +
                    "лицензионных договоров на использование в НИР ОИС", 1.5f, 2.2f),

                new NirLabor("1.6",
                    "Подготовка отчета о патентных исследованиях", 0.2f, 1.0f),

                new NirLabor("1.7",
                    "Коордитация и контроль выполнения работ исполнителями СЧ НИР на всех этапах, опеспечение исполнителей СЧ НИР необходимыми материалам " +
                    "и информацией. Применяется либо п.7, либо п.4 ", 0.2f, 1.0f),

                new NirLabor("1.9",
                    "Уточнение(корректировка) и согласование с заказчиком состава макета(экспериментального образца), создаваемого при проведении НИР " +
                    "(при наличии соответствующего пункта в ТТЗ)", 0.02f, 0.05f),

                new NirLabor("1.11",
                    "Разработка и создание макетов, моделей, экспериментальных образцов технических средств (рекоммендуется разбить на подзадачи)", 0.5f, 1.5f),

                new NirLabor("1.13",
                    "Разработка и создание экспериментальных образцов аппаратно-программных комплексов (рекомендуется разбить на подзадачи)", 1.5f, 5.0f),

                new NirLabor("1.15",
                    "Установка и автономное тестирование разрабатываемого СПО", 0.2f, 0.5f),

                new NirLabor("1.16",
                    "Тестирование и отладка СПО на разрабатываемом экспериментальном образце", 0.1f, 1.5f),

                new NirLabor("1.17",
                    "Разработка и согласование с заказчиком методики встраивания разработканного в ходе выполнения НИР (СЧ НИР) экспериментального образца " +
                    "(макета) в образец ВТ заказчика", 0.3f, 0.6f),

                new NirLabor("1.18",
                    "Разработка и согласование с заказчиком Программы и методик исследований (испытаний) созданных в ходе выполнения НИР экспериментальных" +
                    "образцов (макетов, моделей)", 0.5f, 1.0f),

                new NirLabor("1.19",
                    "Проведение испытаний (исследований) созданного в ходе выполнения НИР специального программного обеспечения, макетов (моделей," +
                    "эксперементальных образцов) аппаратно-программных комплексов", 1.0f, 2.5f),

                new NirLabor("1.20",
                    "Оформление результатов проведенных исследований (испытаний) созданных в ходе выполнения НИР экспериментальных образцов (макетов, моделей)" +
                    "соответствующими протоколами (атаками)", 0.01f, 0.02f),

                new NirLabor("1.21",
                    "Разработка проекта ТЗ (ТТЗ) на ОКР", 0.5f, 1.5f),

                new NirLabor("1.22",
                    "Оценка технико-экономической эффективности результатов НИР, определение и обоснование необходимости проведения дальнейших исследований" +
                    " (в рамках НИР, ОКР", 0.02f, 0.08f),

                new NirLabor("1.24",
                    "Выборка рекомендаций по использованию результатов НИР", 0.01f, 0.02f),

                new NirLabor("1.25",
                    "Проведение рассмотрения результатов этапа НИР на НТС (секции НТС, техническом совещании специалистов)", 0.02f, 0.03f),

                new NirLabor("1.26",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля ходя и осуществления приемки НИР", 0.01f, 0.02f),

                new NirLabor("1.27",
                    "Осуществление мероприятий по защите государственной тайны в период проведения НИР", 0.1f, 0.2f),

                new NirLabor("1.28",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ) и условий контракта на " +
                    "выполнение НИР (СЧ НИР)", 0.1f, 0.25f),

                new NirLabor("1.29",
                    "Участие в работе комиссии по приемке этапов НИР и НИР в целом", 0.01f, 0.05f),
            };

            dbContext.NirLabors.AddRange(nirLabors);
        }

        private void SeedNirStages(NiokrCategory nirCategory)
        {
            NirStage[] nirStages = new NirStage[]
            {
                new NirStage("Этап 1.", nirCategory),
                new NirStage("Этап 2.", nirCategory),
                new NirStage("Этап 3.", nirCategory),
                new NirStage("Этап 4.", nirCategory),
            };
            Array.Reverse(nirStages);
            dbContext.NirStages.AddRange(nirStages);
        }

        private void SeedOkrStages(NiokrCategory okrCategory)
        {
            OkrStage[] okrStages = new OkrStage[]
            {
                new OkrStage("Этап 1. Эскизный проект", okrCategory),
                new OkrStage("Этап 2. Технический проект", okrCategory),
                new OkrStage("Этап 3. Разработка РКД для изготовления ОО изделия", okrCategory),
                new OkrStage("Этап 4. Изготовление ОО изделия", okrCategory),
                new OkrStage("Этап 5. Проведение ГИ ОО", okrCategory),
                new OkrStage("Этап 6. Утверждение РКД для организации промышленного(серийного) производства изделия", okrCategory),
                new OkrStage("Работы, осуществляемые в ходе всей ОКР", okrCategory),
            };
            Array.Reverse(okrStages);
            dbContext.OkrStages.AddRange(okrStages);
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
