using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Reflection.Emit;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LaborVolumeCalculator.Data.Nir;
using LaborVolumeCalculator.Data.DevLabors;
using LaborVolumeCalculator.Data.Ontd;
using LaborVolumeCalculator.Data.Rates;

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

            new NirSeeds(dbContext).Initialize();
            new DevelopmentLaborSeeds(dbContext).Initialize();
            new OntdSeeds(dbContext).Initialize();
            var sdlgrSeeds = new SoftwareDevLaborGroupRateSeeds(dbContext).Initialize();
            new CorrectionRatesBundleSeeds(dbContext, sdlgrSeeds).Initialize();

            dbContext.SaveChanges();
        }               
    }
}
