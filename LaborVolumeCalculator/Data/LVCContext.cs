using System;
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
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Data
{
    public class LVCContext : DbContext
    {
        public LVCContext(DbContextOptions<LVCContext> options)
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

        public DbSet<Labor> Labors { get; set; }
        public DbSet<NirLabor> NirLabors { get; set; }
        public DbSet<OkrLabor> OkrLabors { get; set; }
        public DbSet<OntdLabor> OntdLabors { get; set; }
        public DbSet<SoftwareDevLabor> SoftwareDevLabors { get; set; }
        public DbSet<DbDevLabor> DbDevLabors { get; set; }
        public DbSet<HardwareDevLabor> HardwareDevLabors { get; set; }

        public DbSet<SoftwareDevLaborGroup> SoftwareDevLaborGroups { get; set; }
        public DbSet<NirSoftwareDevLaborGroup> NirSoftwareDevLaborGroups { get; set; }
        public DbSet<OkrSoftwareDevLaborGroup> OkrSoftwareDevLaborGroups { get; set; }

        public DbSet<NiokrStage> NiokrStages { get; set; }
        public DbSet<NirStage> NirStages { get; set; }
        public DbSet<OkrStage> OkrStages { get; set; }

        public DbSet<NirStageReg> NirStageRegs { get; set; }
        public DbSet<OkrStageReg> OkrStageRegs { get; set; }

        public DbSet<SoftwareDevEnv> SoftwareDevEnvs { get; set; }

        public DbSet<PlatePointsCountRange> PlatePointsCountRanges { get; set; }

        public DbSet<DbEntityCountRange> DbEntityCountRanges { get; set; }

        public DbSet<NirLaborVolumeReg> NirLaborVolumeRegs { get; set; }
        public DbSet<OkrLaborVolumeReg> OkrLaborVolumeRegs { get; set; }

        public DbSet<LaborCategory> LaborCategories { get; set; }

        public DbSet<ArchitectureComplexityRate> ArchitectureComplexityRates { get; set; }
        public DbSet<ComponentsInteractionArchitecture> ComponentsInteractionArchitectures { get; set; }
        public DbSet<ComponentsMakroArchitecture> ComponentsMakroArchitectures { get; set; }
        public DbSet<ComponentsMicroArchitecture> ComponentsMicroArchitectures { get; set; }

        public DbSet<InfrastructureComplexityRate> InfrastructureComplexities { get; set; }
        public DbSet<SolutionInnovationRate> SolutionInnovationRates { get; set; }
        public DbSet<StandardModulesUsingRate> StandardModulesUsingRates { get; set; }
        public DbSet<TestsCoverageLevel> TestsCoverageLevels { get; set; }
        public DbSet<TestsScale> TestsScales { get; set; }

        public DbSet<NirSoftwareDevLaborGroupReg> NirSoftwareDevLaborGroupRegs { get; set; }
        public DbSet<OkrSoftwareDevLaborGroupReg> OkrSoftwareDevLaborGroupRegs { get; set; }
        public DbSet<TestsDevelopmentRate> TestsDevelopmentRates { get; set; }

        public DbSet<NirStageDefaultLabor> NirStageDefaultLabors { get; set; }

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
                e.Property(n => n.NirInnovationRateValue).IsRequired();
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

            modelBuilder.Entity<Labor>(e =>
            {
                e.ToTable("Labor", Schema.Dictionary);
                e.Property(p => p.Code).IsRequired();
                e.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<OkrLabor>()         .HasOne(r => r.OkrStage)                .WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DevelopmentLabor>() .HasOne(r => r.LaborCategory)           .WithMany(r => r.Labors).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DbDevLabor>()       .HasOne(r => r.DbEntityCountRange)      .WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<HardwareDevLabor>() .HasOne(r => r.PlatePointsCountRange)   .WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SoftwareDevLabor>() .HasOne(r => r.SoftwareDevEnv).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NiokrStage>().ToTable("NiokrStage", Schema.Dictionary);

            modelBuilder.Entity<NirStageReg>(e => {
                e.ToTable("NirStageReg", Schema.Registers);
                e.Property(p => p.NirID).IsRequired();
                e.Property(p => p.StageID).IsRequired();
                e.HasOne(r => r.Nir).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(key => new { key.NirID, key.StageID }).IsUnique();
            });

            modelBuilder.Entity<OkrStageReg>(e => {
                e.ToTable("OkrStageReg", Schema.Registers);
                e.Property(p => p.OkrID).IsRequired();
                e.Property(p => p.StageID).IsRequired();
                e.HasOne(r => r.Okr).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(key => new { key.OkrID, key.StageID }).IsUnique();
            });

            modelBuilder.Entity<NirLaborVolumeReg>(e =>
            {
                e.ToTable("NirLaborVolumeReg", Schema.Registers);
                e.HasOne(r => r.Nir).WithMany().OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(key => new { key.NirID, key.StageID, key.LaborID }).IsUnique();
            });

            modelBuilder.Entity<OkrLaborVolumeReg>(e => {
                e.ToTable("OkrLaborVolumeReg", Schema.Registers);
                e.HasOne(r => r.Okr).WithMany().OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(key => new { key.OkrID, key.StageID, key.LaborID }).IsUnique();
            });

            modelBuilder.Entity<SoftwareDevLaborGroup>(e => 
            {   
                e.ToTable("SoftwareDevLaborGroup", Schema.Dictionary);
                e.Property(p => p.Code).IsRequired();
                e.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<OkrSoftwareDevLaborGroup>(e => 
            {
                e.HasOne(r => r.OkrStage).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<LaborCategory>(e => 
            {
                e.ToTable("LaborCategory", Schema.Dictionary);
                e.Property(p => p.Number).IsRequired();
                e.Property(p => p.Name).IsRequired();
            });
            
            modelBuilder.Entity<ArchitectureComplexityRate>(e => 
            {
                e.ToTable("ArchitectureComplexityRate", Schema.Dictionary)
                    .HasIndex(key => new{ key.ComponentsInteractionArchitectureID, key.ComponentsMakroArchitectureID })
                    .IsUnique();
                e.HasOne(r => r.ComponentsInteractionArchitecture).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.ComponentsMakroArchitecture).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ComponentsInteractionArchitecture>(e => 
            {
                e.ToTable("ComponentsInteractionArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<ComponentsMakroArchitecture>(e => 
            {
                e.ToTable("ComponentsMakroArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<ComponentsMicroArchitecture>(e =>
            {
                e.ToTable("ComponentsMicroArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<InfrastructureComplexityRate>(e =>
            {
                e.ToTable("InfrastructureComplexityRate", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<SolutionInnovationRate>(e =>
            {
                e.ToTable("SolutionInnovationRate", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<StandardModulesUsingRate>(e => 
            {
                e.ToTable("StandardModulesUsingRate", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<TestsCoverageLevel>(e => 
            {
                e.ToTable("TestsCoverageLevel", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
            modelBuilder.Entity<TestsScale>(e => 
            {
                e.ToTable("TestsScale", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
            });
                      
            modelBuilder.Entity<NirSoftwareDevLaborGroupReg>(e => 
            {
                e.ToTable("NirSoftwareDevLaborGroupReg", Schema.Registers)
                    .HasIndex(key => new { key.NirID, key.StageID, key.SoftwareDevLaborGroupID })
                    .IsUnique();
                e.HasOne(r => r.Nir).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.SoftwareDevLaborGroup).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OkrSoftwareDevLaborGroupReg>(e => 
            {
                e.ToTable("OkrSoftwareDevLaborGroupReg", Schema.Registers)
                    .HasIndex(key => new { key.OkrID, key.StageID, key.SoftwareDevLaborGroupID })
                    .IsUnique();
                e.HasOne(r => r.Okr).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.SoftwareDevLaborGroup).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });
            
            

            modelBuilder.Entity<TestsDevelopmentRate>(e => 
            {
                e.ToTable("TestsDevelopmentRate", Schema.Dictionary)
                    .HasIndex(key => new { key.ComponentsMicroArchitectureID, key.TestsCoverageLevelID, key.TestsScaleID })
                    .IsUnique();
                e.HasOne(r => r.ComponentsMicroArchitecture).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.TestsScale).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.TestsCoverageLevel).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<NirStageDefaultLabor>(e => {
                e.ToTable("NirStageDefaultLabors", Schema.Dictionary);
                e.Property(p => p.StageID).IsRequired();
                e.Property(p => p.LaborID).IsRequired();
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
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
