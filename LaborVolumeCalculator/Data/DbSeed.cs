using LaborVolumeCalculator.Data.Seeds;
using LaborVolumeCalculator.Migrations;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            SeedNirLabors();
            SeedOkrLabors();
            SeedLaborVolumes();

            var NirCategory = NiokrCategory.NIR;
            var OkrCategory = NiokrCategory.OKR;
            dbContext.NiokrCategories.Add(NirCategory);
            dbContext.NiokrCategories.Add(OkrCategory);

            SeedNirStages(NirCategory);
            SeedOkrStages(OkrCategory);

            dbContext.SaveChanges();
        }

        private void SeedNirStages(NiokrCategory nirCategory)
        {
            NiokrStage[] niokrStages = new NiokrStage[]
            {
                new NiokrStage("Этап 1.", nirCategory),
                new NiokrStage("Этап 2.", nirCategory),
                new NiokrStage("Этап 3.", nirCategory),
                new NiokrStage("Этап 4.", nirCategory),
            };
            Array.Reverse(niokrStages);
            dbContext.AddRange(niokrStages);
        }

        private void SeedOkrStages(NiokrCategory okrCategory)
        {
            NiokrStage[] niokrStages = new NiokrStage[]
            {
                new NiokrStage("Этап 1. Эскизный проект", okrCategory),
                new NiokrStage("Этап 2. Технический проект", okrCategory),
                new NiokrStage("Этап 3. Разработка РКД для изготовления ОО изделия", okrCategory),
                new NiokrStage("Этап 4. Изготовление ОО изделия", okrCategory),
                new NiokrStage("Этап 5. Проведение ГИ ОО", okrCategory),
                new NiokrStage("Этап 6. Утверждение РКД для организации промышленного(серийного) производства изделия", okrCategory),
                new NiokrStage("Работы, осуществляемые в ходе всей ОКР", okrCategory),
            };
            Array.Reverse(niokrStages);
            dbContext.AddRange(niokrStages);
        }

        private void SeedNirLabors()
        {
            LaborGroup lg_NIR = new LaborGroup("1", "НИР");

            dbContext.LaborGroups.Add(lg_NIR);
            dbContext.Labors.AddRange(new NirLaborsSeeds(lg_NIR));
        }

        private void SeedOkrLabors()
        {
            LaborGroup lg_OKR = new LaborGroup("2", "ОКР");
            LaborGroup[] OKR_Stages = new LaborGroup[] {
                lg_OKR,
                new LaborGroup("2.1", "Этап 1. Эскизный проект", lg_OKR),
                new LaborGroup("2.2", "Этап 2. Технический проект", lg_OKR),
                new LaborGroup("2.3", "Этап 3. Разработка РКД для изготовления ОО изделия", lg_OKR),
                new LaborGroup("2.4", "Этап 4. Изготовление ОО изделия", lg_OKR),
                new LaborGroup("2.5", "Этап 5. Проведение ГИ ОО", lg_OKR),
                new LaborGroup("2.6", "Этап 6. Утверждение РКД для организации промышленного(серийного) производства изделия", lg_OKR),
                new LaborGroup("2.7", "Работы, осуществляемые в ходе всей ОКР", lg_OKR)
            };

            foreach (LaborGroup okrStage in OKR_Stages)
            {
                dbContext.LaborGroups.Add(okrStage);
            }

            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage1(OKR_Stages[1]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage2(OKR_Stages[2]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage3(OKR_Stages[3]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage4(OKR_Stages[4]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage5(OKR_Stages[5]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.Stage6(OKR_Stages[6]));
            dbContext.Labors.AddRange(new OkrLaborsSeeds.SharedLabors(OKR_Stages[7]));
            dbContext.SaveChanges();
        }

        private void SeedLaborVolumes()
        {
            dbContext.LaborVolumes.AddRange(new LaborVolumesSeeds(dbContext.Labors).Data);
            
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
