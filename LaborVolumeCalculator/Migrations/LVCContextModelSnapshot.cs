﻿// <auto-generated />
using System;
using LaborVolumeCalculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaborVolumeCalculator.Migrations
{
    [DbContext(typeof(LVCContext))]
    partial class LVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NiokrCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Niokr","Dictionary");

                    b.HasDiscriminator<string>("NiokrCategory").HasValue("Niokr");
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

            modelBuilder.Entity("LaborVolumeCalculator.Models.Documents.NirLaborVolumesDoc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsImplemented")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NiokrID")
                        .HasColumnType("int");

                    b.Property<int>("NiokrStageID")
                        .HasColumnType("int");

                    b.Property<float>("NirInnovationRate")
                        .HasColumnType("real");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("NiokrID");

                    b.HasIndex("NiokrStageID");

                    b.ToTable("NirLaborVolumesDoc","Documents");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Documents.NirLaborVolumesDocRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Calculation")
                        .HasColumnType("real");

                    b.Property<int>("LaborID")
                        .HasColumnType("int");

                    b.Property<int>("NirLaborVolumesDocID")
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("LaborID");

                    b.HasIndex("NirLaborVolumesDocID");

                    b.ToTable("NirLaborVolumesDocRecord","Documents");
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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NirInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<int>("NirScaleID")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("ID");

                    b.HasIndex("NirInnovationPropertyID");

                    b.HasIndex("NirScaleID", "NirInnovationPropertyID")
                        .IsUnique();

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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceCompositionID")
                        .HasColumnType("int");

                    b.Property<int>("OkrInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(8, 4)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceCompositionID");

                    b.HasIndex("OkrInnovationPropertyID", "DeviceCompositionID")
                        .IsUnique();

                    b.ToTable("OkrInnovationRate");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Nir", b =>
                {
                    b.HasBaseType("LaborVolumeCalculator.Models.Dictionary.Niokr");

                    b.Property<int>("NirInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<int>("NirInnovationRateID")
                        .HasColumnType("int");

                    b.Property<int>("NirScaleID")
                        .HasColumnType("int");

                    b.HasIndex("NirInnovationPropertyID");

                    b.HasIndex("NirInnovationRateID");

                    b.HasIndex("NirScaleID");

                    b.HasDiscriminator().HasValue("НИР");
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Okr", b =>
                {
                    b.HasBaseType("LaborVolumeCalculator.Models.Dictionary.Niokr");

                    b.Property<int>("DeviceComplexityRateID")
                        .HasColumnType("int");

                    b.Property<int>("DeviceCompositionID")
                        .HasColumnType("int");

                    b.Property<int>("DeviceCountRangeID")
                        .HasColumnType("int");

                    b.Property<int>("OkrInnovationPropertyID")
                        .HasColumnType("int");

                    b.Property<int>("OkrInnovationRateID")
                        .HasColumnType("int");

                    b.HasIndex("DeviceComplexityRateID");

                    b.HasIndex("DeviceCompositionID");

                    b.HasIndex("DeviceCountRangeID");

                    b.HasIndex("OkrInnovationPropertyID");

                    b.HasIndex("OkrInnovationRateID");

                    b.HasDiscriminator().HasValue("ОКР");
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

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.NiokrStage", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.NiokrCategory", "NiokrCategory")
                        .WithMany()
                        .HasForeignKey("NiokrCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Documents.NirLaborVolumesDoc", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.Niokr", "Niokr")
                        .WithMany()
                        .HasForeignKey("NiokrID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.NiokrStage", "NiokrStage")
                        .WithMany()
                        .HasForeignKey("NiokrStageID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Documents.NirLaborVolumesDocRecord", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.Dictionary.Labor", "Labor")
                        .WithMany()
                        .HasForeignKey("LaborID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.Documents.NirLaborVolumesDoc", "NirLaborVolumesDoc")
                        .WithMany("NirLaborVolumesDocRecords")
                        .HasForeignKey("NirLaborVolumesDocID")
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

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Nir", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.NirInnovationProperty", "NirInnovationProperty")
                        .WithMany()
                        .HasForeignKey("NirInnovationPropertyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.NirInnovationRate", "NirInnovationRate")
                        .WithMany()
                        .HasForeignKey("NirInnovationRateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.NirScale", "NirScale")
                        .WithMany()
                        .HasForeignKey("NirScaleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("LaborVolumeCalculator.Models.Dictionary.Okr", b =>
                {
                    b.HasOne("LaborVolumeCalculator.Models.DeviceComplexityRate", "DeviceComplexityRate")
                        .WithMany()
                        .HasForeignKey("DeviceComplexityRateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.DeviceComposition", "DeviceComposition")
                        .WithMany()
                        .HasForeignKey("DeviceCompositionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.DeviceCountRange", "DeviceCountRange")
                        .WithMany()
                        .HasForeignKey("DeviceCountRangeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.OkrInnovationProperty", "OkrInnovationProperty")
                        .WithMany()
                        .HasForeignKey("OkrInnovationPropertyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LaborVolumeCalculator.Models.OkrInnovationRate", "OkrInnovationRate")
                        .WithMany()
                        .HasForeignKey("OkrInnovationRateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
