using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Models;
using System.Threading.Tasks;
using System.Threading;

namespace LaborVolumeCalculator.Data
{
    public class LVCContext : DbContext
    {
        public LVCContext(DbContextOptions<LVCContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            UpdateStampsOnTimeTreckableEntries();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateStampsOnTimeTreckableEntries();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateStampsOnTimeTreckableEntries()
        {
            var modifiedEntries = ChangeTracker.Entries()
                            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);
            
            DateTime now = DateTime.Now;

            foreach (var entry in modifiedEntries)
            {
                ITimeTreckable entity = entry.Entity as ITimeTreckable;
                if (entity == null) continue; 
                
                if (entry.State == EntityState.Added) entity.CreateTime = now;
                else Entry<ITimeTreckable>(entity).Property(p => p.CreateTime).IsModified = false;

                entity.UpdateTime = now;
            }
        }

        public DbSet<Nir> Nirs { get; set; } 

        public DbSet<Okr> Okrs { get; set; }

        public DbSet<NirScale> NirScales { get; set; }

        public DbSet<NirInnovationRate> NirInnovationRates { get; set; }
        public DbSet<NirInnovationProperty> NirInnovationProperties { get; set; }
        public DbSet<DeviceComposition> DeviceCompositions { get; set; }
        public DbSet<OkrInnovationProperty> OkrInnovationProperties { get; set; }
        public DbSet<DeviceComplexityRate> DeviceComplexityRates { get; set; }
        public DbSet<OkrInnovationRate> OkrInnovationRates { get; set; }
        public DbSet<DeviceCountRange> DeviceCountRanges { get; set; }

        public DbSet<Labor> Labors { get; set; }
        public DbSet<NirLabor> NirLabors { get; set; }
        public DbSet<OkrLabor> OkrLabors { get; set; }
        public DbSet<OntdLabor> OntdLabors { get; set; }
        public DbSet<DevelopmentLabor> DevelopmetnLabors { get; set; }

        public DbSet<SoftwareDevLaborGroup> SoftwareDevLaborGroups { get; set; }
        public DbSet<NirSoftwareDevLaborGroup> NirSoftwareDevLaborGroups { get; set; }
        public DbSet<OkrSoftwareDevLaborGroup> OkrSoftwareDevLaborGroups { get; set; }

        public DbSet<Stage> Stages { get; set; }
        public DbSet<StageForNir> StagesForNir { get; set; }
        public DbSet<StageForOkr> StagesForOkr { get; set; }

        public DbSet<NirStage> NirStages { get; set; }
        public DbSet<OkrStage> OkrStages { get; set; }

        public DbSet<RangeFeatureCategory> RangeFeatureCategories { get; set; }

        public DbSet<RangeFeature> RangeFeatures { get; set; }

        public DbSet<NirStageLaborVolume> NirStageLaborVolumes { get; set; }

        public DbSet<OkrStageLaborVolume> OkrStageLaborVolumes { get; set; }

        public DbSet<DevelopmentLaborCategory> LaborCategories { get; set; }

        public DbSet<ArchitectureComplexityRate> ArchitectureComplexityRates { get; set; }
        public DbSet<ComponentsInteractionArchitecture> ComponentsInteractionArchitectures { get; set; }
        public DbSet<ComponentsMakroArchitecture> ComponentsMakroArchitectures { get; set; }
        public DbSet<ComponentsMicroArchitecture> ComponentsMicroArchitectures { get; set; }

        public DbSet<InfrastructureComplexityRate> InfrastructureComplexities { get; set; }
        public DbSet<SolutionInnovationRate> SolutionInnovationRates { get; set; }
        public DbSet<StandardModulesUsingRate> StandardModulesUsingRates { get; set; }
        public DbSet<TestsCoverageLevel> TestsCoverageLevels { get; set; }
        public DbSet<TestsScale> TestsScales { get; set; }

        public DbSet<NirStageSoftwareDevLaborGroup> NirStageSoftwareDevLaborGroups { get; set; }
        public DbSet<OkrStageSoftwareDevLaborGroup> OkrStageSoftwareDevLaborGroups { get; set; }
        public DbSet<TestsDevelopmentRate> TestsDevelopmentRates { get; set; }

        public DbSet<NirStageDefaultLabor> NirStageDefaultLabors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nir>(e =>
            {
                e.ToTable("Nir", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.DateFrom).IsRequired();
                e.Property(p => p.DateTo).IsRequired();
                e.Property(p => p.AnalogDurationMonthes).IsRequired();
                e.Property(p => p.IntensiveRateValue).IsRequired().HasDefaultValue(1.0);
            });

            modelBuilder.Entity<Okr>(e =>
            {
                e.ToTable("Okr", Schema.Dictionary);
                e.HasOne(n => n.OkrInnovationRate).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceComplexityRate).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.OkrInnovationProperty).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceComposition).WithMany().OnDelete(DeleteBehavior.NoAction);
                e.HasOne(n => n.DeviceCountRange).WithMany().OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<NirScale>().ToTable("NirScale", Schema.Dictionary);
            modelBuilder.Entity<NirInnovationProperty>().ToTable("NirInnovationProperty", Schema.Dictionary);
            modelBuilder
                .Entity<NirInnovationRate>().ToTable("NirInnovationRate", Schema.Dictionary)
                .HasIndex(key => new { key.NirScaleID, key.NirInnovationPropertyID })
                .IsUnique();

            modelBuilder.Entity<DeviceComposition>().ToTable("DeviceComposition", Schema.Dictionary);
            modelBuilder.Entity<OkrInnovationProperty>().ToTable("OkrInnovationProperty", Schema.Dictionary);

            modelBuilder.Entity<OkrInnovationRate>().ToTable("OkrInnovationRate", Schema.Dictionary)
                .HasIndex(key => new { key.OkrInnovationPropertyID, key.DeviceCompositionID })
                .IsUnique();

            modelBuilder.Entity<DeviceCountRange>().ToTable("DeviceCountRange", Schema.Dictionary);

            modelBuilder.Entity<DeviceComplexityRate>().ToTable("DeviceComplexityRate", Schema.Dictionary)
                .HasIndex(key => new { key.DeviceCompositionID, key.DeviceCountRangeID })
                .IsUnique();

            modelBuilder.Entity<Labor>(e =>
            {
                e.ToTable("Labor", Schema.Dictionary);
                e.Property(p => p.Code).IsRequired();
                e.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<OkrLabor>().HasOne(r => r.OkrStage).WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DevelopmentLabor>(e => 
            {
                e.ToTable("DevelopmentLabor", Schema.Dictionary)
                    .HasIndex(key => new { key.LaborCategoryID, key.Code })
                    .IsUnique();
                
                e.HasOne(m => m.LaborCategory).WithMany(lc => lc.Labors).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Stage>().ToTable("Stage", Schema.Dictionary);

            modelBuilder.Entity<NirStage>(e =>
            {
                e.ToTable("NirStage", Schema.Registers);
                e.Property(p => p.NirID).IsRequired();
                e.Property(p => p.NirInnovationRateID).IsRequired();
                e.HasOne(r => r.Nir).WithMany(m => m.Stages).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OkrStage>(e =>
            {
                e.ToTable("OkrStage", Schema.Registers);
                e.Property(p => p.OkrID).IsRequired();
                e.Property(p => p.StageID).IsRequired();
                e.HasOne(r => r.Okr).WithMany().OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(key => new { key.OkrID, key.StageID }).IsUnique();
            });

            modelBuilder.Entity<RangeFeatureCategory>(e => {
                e.ToTable("RangeFeatureCategory", Schema.Dictionary);
                e.Property(m => m.Name).IsRequired();
            });

            modelBuilder.Entity<RangeFeature>(e =>
            {
                e.ToTable("RangeFeature", Schema.Dictionary);
                e.Property(m => m.Name).IsRequired();
                e.HasOne(m => m.RangeFeatureCategory)
                    .WithMany(m => m.RangeFeatures)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<NirStageLaborVolume>(e =>
            {
                e.ToTable("NirStageLaborVolume", Schema.Registers);
                e.HasOne(r => r.Stage).WithMany(l => l.LaborVolumes).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.Property(p => p.Volume).IsRequired();
                e.HasIndex(key => new { key.StageID, key.LaborID }).IsUnique();
            });

            modelBuilder.Entity<NirStageOntdLaborVolume>(e => 
            {
                e.ToTable("NirStageOntdLaborVolume", Schema.Registers);
                e.HasOne(r => r.Stage).WithMany(s => s.OntdLaborVolumes).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.Property(p => p.Volume).IsRequired();
                e.HasIndex(key => new { key.StageID, key.LaborID }).IsUnique();
            });

            modelBuilder.Entity<NirDevelopmentLaborVolume>(e =>
            {
                e.ToTable("NirDevelopmentLaborVolume", Schema.Registers)
                    .HasIndex(key => new { key.SoftwareDevLaborGroupID, key.LaborVolumeRangeID })
                    .IsUnique();
                e.HasOne(r => r.SoftwareDevLaborGroup).WithMany(lg => lg.LaborVolumes).OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<OkrStageLaborVolume>(e =>
            {
                e.ToTable("OkrStageLaborVolume", Schema.Registers);
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.Property(p => p.Volume).IsRequired();
                e.HasIndex(key => new { key.StageID, key.LaborID }).IsUnique();
            });

            modelBuilder.Entity<LaborVolumeRange>(e =>
            {
                e.ToTable("LaborVolumeRange", Schema.Dictionary)
                    .HasIndex(key => new { key.LaborID, key.RangeFeatureID }).IsUnique();
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.RangeFeature).WithMany().OnDelete(DeleteBehavior.Restrict);
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

            modelBuilder.Entity<DevelopmentLaborCategory>(e =>
            {
                e.ToTable("LaborCategory", Schema.Dictionary);
                e.Property(p => p.Number).IsRequired();
                e.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<ArchitectureComplexityRate>(e =>
            {
                e.ToTable("ArchitectureComplexityRate", Schema.Dictionary)
                    .HasIndex(key => new { key.ComponentsInteractionArchitectureID, key.ComponentsMakroArchitectureID })
                    .IsUnique();
                e.HasOne(r => r.ComponentsInteractionArchitecture).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.ComponentsMakroArchitecture).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ComponentsInteractionArchitecture>(e =>
            {
                e.ToTable("ComponentsInteractionArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Code).IsRequired();
            });
            modelBuilder.Entity<ComponentsMakroArchitecture>(e =>
            {
                e.ToTable("ComponentsMakroArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Code).IsRequired();
                
            });
            modelBuilder.Entity<ComponentsMicroArchitecture>(e =>
            {
                e.ToTable("ComponentsMicroArchitecture", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Code).IsRequired();
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
                e.Property(p => p.Code).IsRequired();
            });
            modelBuilder.Entity<TestsScale>(e =>
            {
                e.ToTable("TestsScale", Schema.Dictionary);
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Code).IsRequired();
            });

            modelBuilder.Entity<NirStageSoftwareDevLaborGroup>(e =>
            {
                e.ToTable("NirStageSoftwareDevLaborGroup", Schema.Registers)
                    .HasIndex(key => new { key.StageID, key.SoftwareDevLaborGroupID })
                    .IsUnique();
                e.HasOne(r => r.Stage).WithMany(stage => stage.SoftwareDevLaborGroups).IsRequired().OnDelete(DeleteBehavior.Cascade);
                e.HasOne(r => r.SoftwareDevLaborGroup).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.CorrectionRatesBundle).WithMany().IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OkrStageSoftwareDevLaborGroup>(e =>
            {
                e.ToTable("OkrStageSoftwareDevLaborGroup", Schema.Registers)
                    .HasIndex(key => new { key.StageID, key.SoftwareDevLaborGroupID })
                    .IsUnique();
                e.HasOne(r => r.Stage).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity<NirStageDefaultLabor>(e =>
            {
                e.ToTable("NirStageDefaultLabors", Schema.Dictionary);
                e.Property(p => p.StageID).IsRequired();
                e.Property(p => p.LaborID).IsRequired();
                e.HasOne(r => r.Stage).WithMany().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Labor).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CorrectionRatesBundle>(e =>
            {
                e.ToTable("CorrectionRatesBundle", Schema.Dictionary);
                e.Property(p => p.Number).IsRequired();
                e.Property(p => p.SolutionInnovationRateValue).IsRequired();
                e.Property(p => p.InfrastructureComplexityRateValue).IsRequired();
                e.Property(p => p.StandardModulesUsingRateValue).IsRequired();
                e.Property(p => p.ArchitectureComplexityRateValue).IsRequired();
                e.Property(p => p.TestsDevelopmentRateValue).IsRequired();
                e.HasOne(r => r.SolutionInnovationRate).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.InfrastructureComplexityRate).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.StandardModulesUsingRate).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.ArchitectureComplexityRate).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.TestsDevelopmentRate).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            });
        }

        private class Schema
        {
            public static string Dictionary => "Dictionary";
            public static string Registers => "Registers";
            public static string Documents => "Documents";
        }
    }
}
