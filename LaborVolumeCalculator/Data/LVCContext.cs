﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public DbSet<NirInnovationRate> NirInnovationRates { get; set; }
        public DbSet<NirInnovationProperty> NirInnovationProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nir>().ToTable("Nir");
            modelBuilder.Entity<NirInnovationProperty>().ToTable("NirInnovationProperty");
            modelBuilder
                .Entity<NirInnovationRate>()
                .ToTable("NirInnovationRate")
                .HasKey(key => new { key.NirID, key.NirInnovationPropertyID });
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
