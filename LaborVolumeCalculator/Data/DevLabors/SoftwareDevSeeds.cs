using System.Reflection.Metadata;
using Microsoft.CSharp.RuntimeBinder;
using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    public class SoftwareDevSeeds
    {
        private readonly LVCContext dbContext;
        private SoftwareDevLabor[] softLabors;
        private SoftwareDevEnv[] devEnvironments;
        public SoftwareDevSeeds(LVCContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Initialize(DevelopmentLaborCategory[] laborCategories)
        {
            devEnvironments = SeedSoftwareDevEnvironments();
            softLabors = SeedSoftwareDevLabors(laborCategories);
            SeedSoftwareDevLaborVolumeRanges();
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

        private SoftwareDevLaborVolumeRange[] SeedSoftwareDevLaborVolumeRanges()
        {
            var _PHP_JS = this.devEnvironments[0];
            var _Perl_Ruby_Pyton = this.devEnvironments[1];
            var _Cpp_Cs_Java_ObjC = this.devEnvironments[2];
            var _Asm = this.devEnvironments[3];

            var labors = new SoftwareDevLaborsContainer(softLabors);

            var rb = new SoftwareDevLaborVolumeRangeBuilder(_PHP_JS);
            SoftwareDevLaborVolumeRange[] ranges = new SoftwareDevLaborVolumeRange[]
            {
                // _PHP_JS
                rb.Create(labors[103], 1, 2),
                rb.Create(labors[104], 1),
                rb.Create(labors[105], 1, 2),
                rb.Create(labors[107], 1.5),
                
                rb.Create(labors[202], 0.5, 1.5),
                rb.Create(labors[203], 1, 1.5),
                rb.Create(labors[204], 1.5),
                rb.Create(labors[205], 2.5),
                rb.Create(labors[206], 1.5),
                
                rb.Create(labors[301], 0.5, 1),
                rb.Create(labors[303], 1),
                rb.Create(labors[305], 1),
                
                rb.Create(labors[401], 0.5, 1),
                rb.Create(labors[402], 1),
                
                rb.Create(labors[501], 3.5),
                rb.Create(labors[504], 0.5, 1),
                rb.Create(labors[506], 1),
                
                rb.Create(labors[704], 1),
                
                rb.Create(labors[801], 0),
                rb.Create(labors[802], 0, 0.5),
                rb.Create(labors[803], 0.5, 1),
                
                //_Perl_Ruby_Pyton
                rb.Create(labors[101],_Perl_Ruby_Pyton, 0.5, 1),
                rb.Create(labors[102], 0.5, 1.5),
                rb.Create(labors[104], 1, 2),
                rb.Create(labors[107], 1.5),

                rb.Create(labors[201], 2, 3),
                rb.Create(labors[203], 1, 1.5),
                rb.Create(labors[205], 2.5),
                rb.Create(labors[206], 1.5),

                rb.Create(labors[301], 2, 2.5),
                rb.Create(labors[302], 1.5),
                rb.Create(labors[303], 1),
                rb.Create(labors[306], 0, 0.5),

                rb.Create(labors[401], 1),
                rb.Create(labors[402], 1),
                rb.Create(labors[403], 3, 4),

                rb.Create(labors[501], 3.5),
                rb.Create(labors[502], 4),
                rb.Create(labors[503], 1.5, 2.5),
                rb.Create(labors[504], 1),
                rb.Create(labors[505], 1, 2),
                rb.Create(labors[506], 1),
                rb.Create(labors[507], 2, 3),
                rb.Create(labors[508], 2, 3),
                rb.Create(labors[509], 2),

                rb.Create(labors[701], 1),
                rb.Create(labors[702], 2),
                rb.Create(labors[704], 0.5, 1),
                rb.Create(labors[705], 3, 4),

                rb.Create(labors[801], 0),
                rb.Create(labors[802], 0, 0.5),
                rb.Create(labors[803], 0.5, 1),

                
                //_Cpp_Cs_Java_ObjC
                rb.Create(labors[101], _Cpp_Cs_Java_ObjC, 1.5, 2),
                rb.Create(labors[102], 2),
                rb.Create(labors[103], 3, 4),
                rb.Create(labors[104], 2),
                rb.Create(labors[106], 1.5, 2),
                rb.Create(labors[107], 1.5),

                rb.Create(labors[201], 3.5, 4),
                rb.Create(labors[203], 1.5, 2),
                rb.Create(labors[204], 2),
                rb.Create(labors[205], 2.5),
                rb.Create(labors[206], 1.5),
                rb.Create(labors[207], 2, 2.5),

                rb.Create(labors[301], 2.5),
                rb.Create(labors[302], 3.5, 4),
                rb.Create(labors[303], 2, 2.5),
                rb.Create(labors[304], 4.5),
                rb.Create(labors[305], 1),
                rb.Create(labors[306], 2, 2.5),

                rb.Create(labors[401], 2),
                rb.Create(labors[402], 1.5),
                rb.Create(labors[403], 4, 5),

                rb.Create(labors[501], 3.5),
                rb.Create(labors[502], 4),
                rb.Create(labors[504], 3, 4),
                rb.Create(labors[505], 2, 3),
                rb.Create(labors[506], 1, 1.5),
                rb.Create(labors[507], 4),
                rb.Create(labors[508], 4.5),
                rb.Create(labors[509], 3.5),

                rb.Create(labors[601], 4, 5),
                rb.Create(labors[602], 4, 5),
                rb.Create(labors[603], 4, 5),
                rb.Create(labors[604], 2, 3),
                rb.Create(labors[605], 1, 2),

                rb.Create(labors[701], 2, 3),
                rb.Create(labors[702], 3, 4),
                rb.Create(labors[703], 4, 5),
                rb.Create(labors[704], 1),
                rb.Create(labors[705], 4, 5),

                rb.Create(labors[801], 0, 0.5),
                rb.Create(labors[802], 0.5, 1),
                rb.Create(labors[803], 1, 1.5),

                // Asm
                rb.Create(labors[104], _Asm, 3, 4),
                
                rb.Create(labors[203], 2, 2.5),
                
                rb.Create(labors[301], 4.5),
                rb.Create(labors[302], 3, 4),
                
                rb.Create(labors[401], 4, 4.5),
                
                rb.Create(labors[501], 4.5),
                rb.Create(labors[504], 4, 5),
                rb.Create(labors[505], 5, 6),
                rb.Create(labors[506], 2),
                
                rb.Create(labors[601], 6, 7),
                rb.Create(labors[602], 7, 8),
                rb.Create(labors[603], 7, 8),
                rb.Create(labors[604], 4, 5),

                rb.Create(labors[703], 6, 7),
                
                rb.Create(labors[801], 0.5)
            };

            dbContext.SoftwareDevLaborVolumeRanges.AddRange(ranges);
            return ranges;
        }
    }

    internal class SoftwareDevLaborsContainer
    {
        private readonly SoftwareDevLabor[] softLabors;
        public SoftwareDevLaborsContainer(SoftwareDevLabor[] softLabors)
        {
            this.softLabors = softLabors;
        }

        public SoftwareDevLabor this[int code]
        {
            get
            {
                return softLabors.FirstOrDefault(m => m.Code == code.ToString());
            }
        }
    }
}