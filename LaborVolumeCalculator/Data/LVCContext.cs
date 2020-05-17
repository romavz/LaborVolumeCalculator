using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models;

namespace LaborVolumeCalculator.Data
{
    public class LVCContext : DbContext
    {
        public LVCContext (DbContextOptions<LVCContext> options)
            : base(options)
        {
        }

        public DbSet<Nir> Nirs { get; set; }
        public DbSet<NirInnovationRate> NirInnovationRates { get; set; }
        public DbSet<NirInnovationProperty> NirInnovationProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nir>().ToTable("Nir");
            modelBuilder.Entity<NirInnovationRate>().ToTable("NirInnovationRate");
            modelBuilder.Entity<NirInnovationProperty>().ToTable("NirInnovationProperty");
        }
    }
}
