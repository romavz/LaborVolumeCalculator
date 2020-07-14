using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Data.Fillers
{
    public class OkrLaborList : LaborsList
    {
        public OkrLaborList(LaborGroup laborGroup) : base(laborGroup)
        {
        }

        protected override void LoadLabors()
        {
            AddLabor("1",
                "При наличии в ОКР составных частей, выполнение йункции заказчика по отношению к исполнителям СЧ ОКР, включая " +
                "разработку ТТЗ, координацию и контроль выполнения работ исполнителями СЧ ОКР на всех этапах выполнения СЧ ОКР");
            AddLabor("2",
                "Обеспечение заказчику (его представителям) необходимых условий для контроля работ, выполняемых как на отдельных " +
                "этапах, так и по ОКР в целом");
            AddLabor("3",
                "Осуществление мероприятий по защите от ТСР ИГ в период проведения ОКР");
            AddLabor("4",
                "Осуществление мероприятий по защите гостударственной тайны в период проведения ОКР");
            AddLabor("5",
                "Уточнение и, при необходимости, корректировка плана совместных работ в пределах ТТЗ (ТЗ)");
        }

        public class Stage1 : LaborsList
        {
            public Stage1(LaborGroup parentGroup) : base(parentGroup)
            {
            }

            protected override void LoadLabors()
            {
                AddLabor("1",
                    "Рарзработка укрупненного сетевого плана-графика работ на ОКР, перечня комплектности эскизного проекта");

                AddLabor("2",
                    "Поиск, сбор изучение технической информации, Выбор путей реализации основных СРЭУ системы (комплекса)");

                AddLabor("3",
                    "Разработка алгоритмов функционирования разрабатываемых в ходе выполнения  ОКР (СЧ ОКР) опытного образца " +
                    "(опытных образцов и специального программного обеспечения (на один ОО) (рекоммендуется разбить на подзадачи)");
            }
        }

        public class Stage2 : LaborsList
        {
            public Stage2(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                throw new NotImplementedException();
            }
        }

        public class Stage3 : LaborsList
        {
            public Stage3(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                throw new NotImplementedException();
            }
        }

        public class Stage4 : LaborsList
        {
            public Stage4(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                throw new NotImplementedException();
            }
        }

        public class Stage5 : LaborsList
        {
            public Stage5(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                throw new NotImplementedException();
            }
        }

        public class Stage6 : LaborsList
        {
            public Stage6(LaborGroup laborGroup) : base(laborGroup)
            {
            }

            protected override void LoadLabors()
            {
                throw new NotImplementedException();
            }
        }
    }

    
}
