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