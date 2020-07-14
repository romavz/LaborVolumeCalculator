using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data
{
    public class LVCContext : DbContext
    {
        public LVCContext (DbContextOptions<LVCContext> options)
            : base(options)
        {
            new TimeUpdateService(this.ChangeTracker);
        }

        public DbSet<Nir> Nirs { get; set; }
        public DbSet<NirScale> NirScales { get; set; }

        public DbSet<NirInnovationRate> NirInnovationRates { get; set; }
        public DbSet<NirInnovationProperty> NirInnovationProperties { get; set; }
        public DbSet<DeviceComposition> DeviceCompositions { get; set; }
        public DbSet<OkrInnovationProperty> OkrInnovationProperties { get; set; }
        public DbSet<DeviceComplexityRate> DeviceComplexityRates { get; set; }
        public DbSet<OkrInnovationRate> OkrInnovationRates { get; set; }
        public DbSet<DeviceCountRange> DeviceCountRange { get; set; }

        public DbSet<LaborGroup> LaborGroups { get; set; }

        public DbSet<Labor> Labors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nir>().ToTable("Nir");
            modelBuilder.Entity<NirScale>().ToTable("NirScale");
            modelBuilder.Entity<NirInnovationProperty>().ToTable("NirInnovationProperty");
            modelBuilder
                .Entity<NirInnovationRate>()
                .ToTable("NirInnovationRate")
                .HasKey(key => new { key.NirScaleID, key.NirInnovationPropertyID });
            
            modelBuilder.Entity<DeviceComposition>().ToTable("DeviceComposition");
            modelBuilder.Entity<OkrInnovationProperty>().ToTable("OkrInnovationProperty");
            
            modelBuilder.Entity<OkrInnovationRate>().ToTable("OkrInnovationRate")
                .HasKey(key => new { key.OkrInnovationPropertyID, key.DeviceCompositionID });
            modelBuilder.Entity<OkrInnovationRate>()
                .Property("Value").HasColumnType("DECIMAL(8, 4)");

            modelBuilder.Entity<DeviceCountRange>().ToTable("DeviceCountRange");

            modelBuilder.Entity<DeviceComplexityRate>().ToTable("DeviceComplexityRate")
                .HasIndex(key => new { key.DeviceCompositionID, key.DeviceCountRangeID })
                .IsUnique();
            modelBuilder.Entity<DeviceComplexityRate>()
                .Property("Value").HasColumnType("DECIMAL(8, 4)");

            var lg_entity = modelBuilder.Entity<LaborGroup>().ToTable("LaborGroup", Schema.Dictionary);
                
            lg_entity.HasIndex(i => new { i.ParentGroupId });
            
            lg_entity
                .HasIndex(i => new { i.Code })
                .IsUnique();

            lg_entity
                .Property(p => p.Code)
                .IsRequired();

            lg_entity
                .Property(p => p.Name)
                .IsRequired();

            lg_entity
                .HasMany(lg => lg.Labors)
                .WithOne(l => l.LaborGroup);

            lg_entity
                .Property(p => p.Level)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<LaborGroupRelation>().ToTable("LaborGroupRelation", Schema.Dictionary)
                .HasKey(k => new { k.ID });

            modelBuilder.Entity<LaborGroupRelation>()
                .HasIndex(i => new { i.LaborGroupId, i.ParentGroupId })
                .IsUnique()
                .HasFilter("LaborGroupId IS NOT NULL");

            modelBuilder.Entity<LaborGroupRelation>()
                .HasIndex(i => i.LaborGroupId);

            modelBuilder.Entity<LaborGroupRelation>()
                .Property(p => p.LaborGroupId)
                .IsRequired();

            modelBuilder.Entity<LaborGroupRelation>()
                .HasOne(ulg => ulg.LaborGroup)
                .WithMany(lg => lg.ParentGroups)
                .HasForeignKey(fk => fk.LaborGroupId);

            modelBuilder.Entity<LaborGroupRelation>()
                .Property(p => p.ParentGroupId)
                .IsRequired(false);


            var laborsEntity = modelBuilder.Entity<Labor>().ToTable("Labor", Schema.Dictionary);

            laborsEntity
                .HasIndex(i => i.Code)
                .IsUnique();

            laborsEntity
                .Property(p => p.Code)
                .IsRequired();

            laborsEntity
                .Property(p => p.Name)
                .IsRequired();

        }
    
        private class Schema
        {
            public static string Dictionary => "Dictionary";
        }

        private class TimeUpdateService
        {
            public TimeUpdateService(ChangeTracker changeTracker)
            {
                changeTracker.StateChanged += ChangeTracker_StateChanged;
            }
            public void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
            {
                if (e.NewState == EntityState.Modified)
                {
                    UpdateTimeStampField(e.Entry, "UpdateTime", DateTime.Now);
                }
            }

            private void UpdateTimeStampField(EntityEntry entityEntry, string fieldName, DateTime newTime)
            {
                IProperty timeProperty = entityEntry.Metadata.FindProperty(fieldName);
                if (timeProperty == null) return;

                entityEntry.Property(fieldName).CurrentValue = newTime;
            }
        }
    }
}
