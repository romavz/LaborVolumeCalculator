using System;
using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Nir
{
    public class NirSeeds
    {
        private readonly LVCContext dbContext;
        public NirSeeds(LVCContext context)
        {
            this.dbContext = context;
        }

        public void Initialize()
        {
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

            NirLabor[] nirLabors = SeedNirLabors();
            SeedNirSoftwareDevLaborGroups();
        }

        private NirLabor[] SeedNirLabors()
        {
            NirLabor[] nirLabors = new NirLabor[]
            {
                new NirLabor("1",
                    "Проведение научно-технического анализа состояния исследуемого вопроса, определение направлений (методов) исследований " +
                    "для обеспечения достижения поставленных в НИР целей исследования", 0.5, 1.5),

                new NirLabor("2",
                    "Определение перечня и содержания задач, решение которых в ходе выполнения НИР позволит достичь поставленной в НИР цели. " +
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
                    "Уточнение(корректировка) и согласование с заказчиком состава макета (экспериментального образца), создаваемого при проведении НИР " +
                    "(при наличии соответствующего пункта в ТТЗ)", 0.02, 0.05),

                new NirLabor("11",
                    "Разработка и создание макетов, моделей, экспериментальных образцов технических средств (рекоммендуется разбить на подзадачи)", 0.5, 1.5),

                new NirLabor("13",
                    "Разработка и создание экспериментальных образцов аппаратно-программных комплексов (рекомендуется разбить на подзадачи)", 1.5, 5.0),

                new NirLabor("15",
                    "Установка и автономное тестирование разрабатываемого СПО", 0.2, 0.5),

                new NirLabor("16",
                    "Тестирование и отладка СПО на разрабатываемом экспериментальном образце (макете)", 0.1, 1.5),

                new NirLabor("17",
                    "Разработка и согласование с заказчиком методики встраивания разработканного в ходе выполнения НИР (СЧ НИР) экспериментального образца " +
                    "(макета) в образец ВТ заказчика", 0.3, 0.6),

                new NirLabor("18",
                    "Разработка и согласование с заказчиком Программы и методик исследований (испытаний) созданных в ходе выполнения НИР экспериментальных " +
                    "образцов (макетов, моделей)", 0.5, 1.0),

                new NirLabor("19",
                    "Проведение испытаний (исследований) созданного в ходе выполнения НИР специального программного обеспечения, макетов (моделей, " +
                    "эксперементальных образцов) аппаратно-программных комплексов", 1.0, 2.5),

                new NirLabor("20",
                    "Оформление результатов проведенных исследований (испытаний) созданных в ходе выполнения НИР экспериментальных образцов (макетов, моделей) " +
                    "соответствующими протоколами (атаками)", 0.01, 0.02),

                new NirLabor("21",
                    "Разработка проекта ТЗ (ТТЗ) на ОКР", 0.5, 1.5),

                new NirLabor("22",
                    "Оценка технико-экономической эффективности результатов НИР, определение и обоснование необходимости проведения дальнейших исследований " +
                    "(в рамках НИР, ОКР)", 0.02, 0.08),

                new NirLabor("24",
                    "Выработка рекомендаций по использованию результатов НИР", 0.01, 0.02),

                new NirLabor("25",
                    "Проведение рассмотрения результатов этапа НИР на НТС (секции НТС, техническом совещании специалистов)", 0.02, 0.03),

                new NirLabor("26",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля хода и осуществления приемки НИР", 0.01, 0.02),

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

    }
}