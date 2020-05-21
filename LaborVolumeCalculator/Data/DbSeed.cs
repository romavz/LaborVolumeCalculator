using LaborVolumeCalculator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            if (dbContext.Nirs.Any())
            {
                return;
            }

            Nir[] nirs =
            {
                new Nir("Фундаметнальная НИР"),
                new Nir("Прикладная НИР, без создания ЭО или макета"),
                new Nir("Прикладная НИР, с разработкой и изготовлением ЭО или макета")
            };

            dbContext.Nirs.AddRange(nirs);

            NirInnovationProperty[] nirProps =
            {
                new NirInnovationProperty("Работа в развитие предшествующей"),
                new NirInnovationProperty("Работа с известным аналогом"),
                new NirInnovationProperty("Работа, не имеющая известных аналогов")
            };

            dbContext.NirInnovationProperties.AddRange(nirProps);

            dbContext.NirInnovationRates.AddRange(
                new NirInnovationRate(nirs[0], nirProps[0], (decimal)1.3 ),
                new NirInnovationRate(nirs[0], nirProps[1], (decimal)1.7 ),
                new NirInnovationRate(nirs[0], nirProps[2], (decimal)2.9 ),
                new NirInnovationRate(nirs[1], nirProps[0], (decimal)1.0 ),
                new NirInnovationRate(nirs[1], nirProps[1], (decimal)1.4 ),
                new NirInnovationRate(nirs[1], nirProps[2], (decimal)2.5 ),
                new NirInnovationRate(nirs[2], nirProps[0], (decimal)1.2 ),
                new NirInnovationRate(nirs[2], nirProps[1], (decimal)1.7 ),
                new NirInnovationRate(nirs[2], nirProps[2], (decimal)2.7 )
            );

            dbContext.SaveChanges();
        }
    }
}
