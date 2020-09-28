using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_NirInnovationRate_Usage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirInnovationProperty_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirScale_NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceComplexityRate_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceComposition_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceCountRange_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_OkrInnovationProperty_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_OkrInnovationRate_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumeReg_Niokr_NirID",
                schema: "Registers",
                table: "NirLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStage_Niokr_NirID",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrLaborVolumeReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStage_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Niokr",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NiokrCategory",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirInnovationRateValue",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.RenameTable(
                name: "Niokr",
                schema: "Dictionary",
                newName: "Niokrs");

            migrationBuilder.AddColumn<int>(
                name: "NirInnovationRateID",
                schema: "Registers",
                table: "NirStage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Niokrs",
                table: "Niokrs",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Nir",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nir", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Okr",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    OkrInnovationPropertyID = table.Column<int>(nullable: false),
                    DeviceCompositionID = table.Column<int>(nullable: false),
                    DeviceCountRangeID = table.Column<int>(nullable: false),
                    OkrInnovationRateID = table.Column<int>(nullable: false),
                    DeviceComplexityRateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okr", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Okr_DeviceComplexityRate_DeviceComplexityRateID",
                        column: x => x.DeviceComplexityRateID,
                        principalTable: "DeviceComplexityRate",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Okr_DeviceComposition_DeviceCompositionID",
                        column: x => x.DeviceCompositionID,
                        principalTable: "DeviceComposition",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Okr_DeviceCountRange_DeviceCountRangeID",
                        column: x => x.DeviceCountRangeID,
                        principalTable: "DeviceCountRange",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Okr_OkrInnovationProperty_OkrInnovationPropertyID",
                        column: x => x.OkrInnovationPropertyID,
                        principalTable: "OkrInnovationProperty",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Okr_OkrInnovationRate_OkrInnovationRateID",
                        column: x => x.OkrInnovationRateID,
                        principalTable: "OkrInnovationRate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStage_NirInnovationRateID",
                schema: "Registers",
                table: "NirStage",
                column: "NirInnovationRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Okr_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Okr",
                column: "DeviceComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Okr_DeviceCompositionID",
                schema: "Dictionary",
                table: "Okr",
                column: "DeviceCompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Okr_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Okr",
                column: "DeviceCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Okr_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Okr",
                column: "OkrInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Okr_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Okr",
                column: "OkrInnovationRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumeReg_Nir_NirID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStage_Nir_NirID",
                schema: "Registers",
                table: "NirStage",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStage_NirInnovationRate_NirInnovationRateID",
                schema: "Registers",
                table: "NirStage",
                column: "NirInnovationRateID",
                principalTable: "NirInnovationRate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrLaborVolumeReg_Okr_OkrID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Okr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Okr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Okr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStage_Okr_OkrID",
                schema: "Registers",
                table: "OkrStage",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Okr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumeReg_Nir_NirID",
                schema: "Registers",
                table: "NirLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStage_Nir_NirID",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStage_NirInnovationRate_NirInnovationRateID",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrLaborVolumeReg_Okr_OkrID",
                schema: "Registers",
                table: "OkrLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Okr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStage_Okr_OkrID",
                schema: "Registers",
                table: "OkrStage");

            migrationBuilder.DropTable(
                name: "Nir",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "Okr",
                schema: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_NirStage_NirInnovationRateID",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Niokrs",
                table: "Niokrs");

            migrationBuilder.DropColumn(
                name: "NirInnovationRateID",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.RenameTable(
                name: "Niokrs",
                newName: "Niokr",
                newSchema: "Dictionary");

            migrationBuilder.AddColumn<string>(
                name: "NiokrCategory",
                schema: "Dictionary",
                table: "Niokr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NirInnovationRateValue",
                schema: "Dictionary",
                table: "Niokr",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Niokr",
                schema: "Dictionary",
                table: "Niokr",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirScaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirInnovationProperty_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationPropertyID",
                principalTable: "NirInnovationProperty",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirScale_NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirScaleID",
                principalTable: "NirScale",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceComplexityRate_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceComplexityRateID",
                principalTable: "DeviceComplexityRate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceComposition_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCompositionID",
                principalTable: "DeviceComposition",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceCountRange_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCountRangeID",
                principalTable: "DeviceCountRange",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_OkrInnovationProperty_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationPropertyID",
                principalTable: "OkrInnovationProperty",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_OkrInnovationRate_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationRateID",
                principalTable: "OkrInnovationRate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumeReg_Niokr_NirID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStage_Niokr_NirID",
                schema: "Registers",
                table: "NirStage",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrLaborVolumeReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStage_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStage",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
