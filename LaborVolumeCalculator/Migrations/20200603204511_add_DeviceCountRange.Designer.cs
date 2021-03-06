﻿// <auto-generated />
using System;
using LaborVolumeCalculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaborVolumeCalculator.Migrations
{
    [DbContext(typeof(LVCContext))]
    [Migration("20200603204511_add_DeviceCountRange")]
    partial class add_DeviceCountRange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaborVolumeCalculator.Models.DeviceComplexityRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceCompositionID")
                        .HasColumnType("int");

                    b.Property<int>("DeviceCountRangeID")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceCountRangeID");

                    b.HasIndex("DeviceCompositionID", "DeviceCountRangeID")
                        .IsUnique();

                    b.ToTable("DeviceComplexityRate");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.DeviceComposition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DeviceComposition");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.DeviceCountRange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DeviceCountRange");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Nir", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Nir");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirInnovationProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("NirInnovationProperty");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirInnovationRate", b =>
                {
                    b.Property<int>("NirID")
                        .HasColumnType("int");

                    b.Property<int>("NirInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("NirID", "NirInnovationPropertyID");

                    b.HasIndex("NirInnovationPropertyID");

                    b.ToTable("NirInnovationRate");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.OkrInnovationProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("OkrInnovationProperty");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.OkrInnovationRate", b =>
                {
                    b.Property<int>("OkrInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<int>("DeviceCompositionID")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("OkrInnovationPropertyID", "DeviceCompositionID");

                    b.HasIndex("DeviceCompositionID");

                    b.ToTable("OkrInnovationRate");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.DeviceComplexityRate", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.DeviceComposition", "DeviceComposition")
                        .WithMany()
                        .HasForeignKey("DeviceCompositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.DeviceCountRange", "DeviceCountRange")
                        .WithMany()
                        .HasForeignKey("DeviceCountRangeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirInnovationRate", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Nir", "Nir")
                        .WithMany()
                        .HasForeignKey("NirID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.NirInnovationProperty", "NirInnovationProperty")
                        .WithMany()
                        .HasForeignKey("NirInnovationPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.OkrInnovationRate", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.DeviceComposition", "DeviceComposition")
                        .WithMany()
                        .HasForeignKey("DeviceCompositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.OkrInnovationProperty", "OkrInnovationProperty")
                        .WithMany()
                        .HasForeignKey("OkrInnovationPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
