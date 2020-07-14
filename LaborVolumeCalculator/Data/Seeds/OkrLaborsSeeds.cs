using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Data.Seeds
{
    public class OkrLaborsSeeds
    { 
        public class Stage1 : LaborsSeeds
        {
            public Stage1(LaborGroup parentGroup) : base(parentGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.1.1",
                    "Рарзработка укрупненного сетевого плана-графика работ на ОКР, перечня комплектности эскизного проекта");

                AddLabor("2.1.2",
                    "Поиск, сбор изучение технической информации, Выбор путей реализации основных СРЭУ системы (комплекса)");

                AddLabor("2.1.3",
                    "Разработка алгоритмов функционирования разрабатываемых в ходе выполнения  ОКР (СЧ ОКР) опытного образца " +
                    "(опытных образцов и специального программного обеспечения (на один ОО) (рекоммендуется разбить на подзадачи)");
            }
        }

        public class Stage2 : LaborsSeeds
        {
            public Stage2(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.2.1",
                    "Корректировка укрупненного сетевого плана-графика работ по ОКР");
                
                AddLabor("2.2.2",
                    "Разработка перечней комплектности технического проекта: \n" +
                    " - РКД на ОО;\n" +
                    " - ЭД на ОО;");
                
                AddLabor("2.2.3",
                    "Разработка, согласование, утверждение схемы деления изделия на составные части");
            }
        }

        public class Stage3 : LaborsSeeds
        {
            public Stage3(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.3.3",
                    "Разработка программы и методик предварительных испытаний опытного образца изделия");
                
                AddLabor("2.3.4",
                    "Разработка и согласование ис заказчиком состава опытного образца (опытных образцов)," +
                    "создаваемого при проведении ОКР");
                
                AddLabor("2.3.5",
                    "Разработка и согласование с заказчиком инструкции по защите от ТСР ИГ и ее утечки по техническим каналам на этапе" +
                    "изготовления ОО и проведения предварительных испытаний");
                
                AddLabor("2.3.6",
                    "Рассмотрение сводки отзывов и результатов технического проекта на НТС, участие в работе комиссии по приемке этапа," +
                    "подготовка заключения заказчика и акта приемки этапа ОКР");
            }
        }

        public class Stage4 : LaborsSeeds
        {
            public Stage4(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.4.1",
                    "Разработка и создание опытного образца (рекомендуется разбить на подзадачи)");
                AddLabor("2.4.4",
                    "Комплексирование технических и программных средств ОО");
            }
        }

        public class Stage5 : LaborsSeeds
        {
            public Stage5(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.5.1",
                    "Разработка и согласование с заказчиком программы и методик государственных испытаний опытного образца изделия");
                
                AddLabor("2.5.2", 
                    "Участие в государственных испытаниях, проводимых заказчиком");
            }
        }

        public class Stage6 : LaborsSeeds
        {
            public Stage6(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.6.2",
                    "Разработка и согласование с заказчиком документов по сервисному обслуживанию");
                
                AddLabor("2.6.3",
                    "Подготовка отчета о патентных исследованиях");
            }
        }

        public class SharedLabors : LaborsSeeds
        {
            public SharedLabors(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("2.7.1", 
                    "При наличии в ОКР составных частей, выполнение функции заказчика по отношению к исполнителям СЧ ОКР, включая " +
                    "разработку ТТЗ, координацию и контроль выполнения работ исполнителями СЧ ОКР на всех этапах выполнения СЧ ОКР");
                
                AddLabor("2.7.2",
                    "Обеспечение заказчику (его представителям) необходимых условий для контроля работ, выполняемых как на отдельных " +
                    "этапах, так и по ОКР в целом");
                
                AddLabor("2.7.3",
                    "Осуществление мероприятий по защите от ТСР ИГ в период проведения ОКР");
                
                AddLabor("2.7.4",
                    "Осуществление мероприятий по защите гостударственной тайны в период проведения ОКР");
                
                AddLabor("2.7.5",
                    "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ)");
            }
        }
    }
}
