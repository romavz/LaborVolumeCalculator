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
    [Migration("20200715143155_add_Niokr")]
    partial class add_Niokr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
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

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Labor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LaborGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("LaborGroupId");

                    b.ToTable("Labor","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ParentGroupId");

                    b.ToTable("LaborGroup","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborGroupRelation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LaborGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LaborGroupId");

                    b.HasIndex("ParentGroupId");

                    b.HasIndex("LaborGroupId", "ParentGroupId")
                        .IsUnique()
                        .HasFilter("LaborGroupId IS NOT NULL");

                    b.ToTable("LaborGroupRelation","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborVolume", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LaborID")
                        .HasColumnType("int");

                    b.Property<float>("MaxValue")
                        .HasColumnType("real");

                    b.Property<float>("MinValue")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("LaborID")
                        .IsUnique();

                    b.ToTable("LaborVolume","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Niokr", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NiokrCategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("NiokrCategoryID");

                    b.ToTable("Niokr","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.NiokrCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("NiokrCategory","Dictionary");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.NiokrStage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NiokrCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NiokrCategoryID");

                    b.ToTable("NiokrStage","Dictionary");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("NirInnovationProperty");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirInnovationRate", b =>
                {
                    b.Property<int>("NirScaleID")
                        .HasColumnType("int");

                    b.Property<int>("NirInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("NirScaleID", "NirInnovationPropertyID");

                    b.HasIndex("NirInnovationPropertyID");

                    b.ToTable("NirInnovationRate");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirScale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("NirScale");
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

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Labor", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.LaborGroup", "LaborGroup")
                        .WithMany("Labors")
                        .HasForeignKey("LaborGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborGroup", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.LaborGroup", "ParentGroup")
                        .WithMany()
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborGroupRelation", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.LaborGroup", "LaborGroup")
                        .WithMany("ParentGroups")
                        .HasForeignKey("LaborGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.LaborGroup", "ParentGroup")
                        .WithMany()
                        .HasForeignKey("ParentGroupId");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.LaborVolume", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.Labor", "Labor")
                        .WithOne()
                        .HasForeignKey("LaborVolumeCalculator.Models.Dictionary.LaborVolume", "LaborID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Niokr", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.NiokrCategory", "NiokrCategory")
                        .WithMany()
                        .HasForeignKey("NiokrCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.NiokrStage", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.NiokrCategory", "NiokrCategory")
                        .WithMany()
                        .HasForeignKey("NiokrCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.NirInnovationRate", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.NirInnovationProperty", "NirInnovationProperty")
                        .WithMany()
                        .HasForeignKey("NirInnovationPropertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.NirScale", "NirScale")
                        .WithMany()
                        .HasForeignKey("NirScaleID")
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
