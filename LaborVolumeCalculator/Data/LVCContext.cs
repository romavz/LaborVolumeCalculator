﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LaborVolumeCalculator.Models.Documents;

namespace LaborVolumeCalculator.Data
{
    public class LVCContext : DbContext
    {
        public LVCContext (DbContextOptions<LVCContext> options)
            : base(options)
        {
            new TimeUpdateService(this.ChangeTracker);
        }

        public DbSet<Niokr> Niokrs { get; set; }

        public DbSet<Nir> Nirs { get; set; }

        public DbSet<Okr> Okrs { get; set; }

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

        public DbSet<LaborGroupRelation> LaborGroupRelations { get; set; }

        public DbSet<LaborVolume> LaborVolumes { get; set; }
        public DbSet<NiokrCategory> NiokrCategories { get; set; }
        public DbSet<NiokrStage> NiokrStages { get; set; }

        public DbSet<NirLaborVolumesDoc> NirLaborVolumesDocs { get; set; }

        public DbSet<NirLaborVolumesDocRecord> NirLaborVolumesDocRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Niokr>(e =>
            {
                e.ToTable("Niokr", Schema.Dictionary);
                e.HasDiscriminator<string>("NiokrCategory")
                    .HasValue<Nir>("НИР")
                    .HasValue<Okr>("ОКР");
            });

            modelBuilder.Entity<Nir>(e =>
            {
                e.HasOne(n => n.NirInnovationRate).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.NirInnovationProperty).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.NirScale).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Okr>(e => 
            {
                e.HasOne(n => n.OkrInnovationRate).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceComplexityRate).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.OkrInnovationProperty).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceComposition).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceCountRange).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<NirScale>().ToTable("NirScale");
            modelBuilder.Entity<NirInnovationProperty>().ToTable("NirInnovationProperty");
            modelBuilder
                .Entity<NirInnovationRate>().ToTable("NirInnovationRate")
                .HasIndex(key => new { key.NirScaleID, key.NirInnovationPropertyID })
                .IsUnique();

            modelBuilder.Entity<DeviceComposition>().ToTable("DeviceComposition");
            modelBuilder.Entity<OkrInnovationProperty>().ToTable("OkrInnovationProperty");

            modelBuilder.Entity<OkrInnovationRate>().ToTable("OkrInnovationRate")
                .HasIndex(key => new { key.OkrInnovationPropertyID, key.DeviceCompositionID })
                .IsUnique();
            modelBuilder.Entity<OkrInnovationRate>()
                .Property("Value").HasColumnType("DECIMAL(8, 4)");

            modelBuilder.Entity<DeviceCountRange>().ToTable("DeviceCountRange");

            modelBuilder.Entity<DeviceComplexityRate>().ToTable("DeviceComplexityRate")
                .HasIndex(key => new { key.DeviceCompositionID, key.DeviceCountRangeID })
                .IsUnique();
            modelBuilder.Entity<DeviceComplexityRate>()
                .Property("Value").HasColumnType("DECIMAL(8, 4)");

            modelBuilder.Entity<LaborGroup>(LaborGroupConfigure);
            modelBuilder.Entity<LaborGroupRelation>(LaborGroupRelationConfigure);
            modelBuilder.Entity<Labor>(LaborConfigure);
            
            modelBuilder.Entity<LaborVolume>().ToTable("LaborVolume", Schema.Dictionary)
                .HasOne(i => i.Labor)
                .WithOne();

            modelBuilder.Entity<NiokrCategory>().ToTable("NiokrCategory", Schema.Dictionary);

            modelBuilder.Entity<NiokrStage>().ToTable("NiokrStage", Schema.Dictionary)
                .HasOne(s => s.NiokrCategory)
                .WithMany();

            modelBuilder.Entity<NirLaborVolumesDoc>(d =>
            {
                d.ToTable("NirLaborVolumesDoc", Schema.Documents);
                d.HasMany(r => r.NirLaborVolumesDocRecords)
                    .WithOne(r => r.NirLaborVolumesDoc).OnDelete(DeleteBehavior.Cascade);

                d.Property(p => p.IsImplemented).HasDefaultValue(false);
                d.HasOne(r => r.Nir).WithMany().OnDelete(DeleteBehavior.NoAction);
                d.HasOne(r => r.NiokrStage).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<NirLaborVolumesDocRecord>(e =>
            {
                e.ToTable("NirLaborVolumesDocRecord", Schema.Documents);
                e.HasOne<NirLaborVolumesDoc>(d => d.NirLaborVolumesDoc)
                    .WithMany(r => r.NirLaborVolumesDocRecords)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne<Labor>(r => r.Labor).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

        }

        private void LaborGroupConfigure(EntityTypeBuilder<LaborGroup> entity)
        {
            entity.ToTable("LaborGroup", Schema.Dictionary);

            entity.HasIndex(i => new { i.ParentGroupId });

            entity
                .HasIndex(i => new { i.Code })
                .IsUnique();

            entity
                .Property(p => p.Code)
                .IsRequired();

            entity
                .Property(p => p.Name)
                .IsRequired();

            entity
                .HasMany(lg => lg.Labors)
                .WithOne(l => l.LaborGroup);

            entity
                .Property(p => p.Level)
                .IsRequired()
                .HasDefaultValue(0);
        }

        private void LaborGroupRelationConfigure(EntityTypeBuilder<LaborGroupRelation> entity)
        {
            entity.ToTable("LaborGroupRelation", Schema.Dictionary)
                .HasKey(k => new { k.ID });

            entity
                .HasIndex(i => new { i.LaborGroupId, i.ParentGroupId })
                .IsUnique()
                .HasFilter("LaborGroupId IS NOT NULL");

            entity
                .HasIndex(i => i.LaborGroupId);

            entity
                .Property(p => p.LaborGroupId)
                .IsRequired();

            entity
                .HasOne(ulg => ulg.LaborGroup)
                .WithMany(lg => lg.ParentGroups)
                .HasForeignKey(fk => fk.LaborGroupId);

            entity
                .Property(p => p.ParentGroupId)
                .IsRequired(false);
        }

        private void LaborConfigure(EntityTypeBuilder<Labor> laborEntity)
        {
            laborEntity.ToTable("Labor", Schema.Dictionary);

            laborEntity
                .HasIndex(i => i.Code)
                .IsUnique();

            laborEntity
                .Property(p => p.Code)
                .IsRequired();

            laborEntity
                .Property(p => p.Name)
                .IsRequired();
        }

        private class Schema
        {
            public static string Dictionary => "Dictionary";
            public static string Registers => "Registers";
            public static string Documents => "Documents";
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
