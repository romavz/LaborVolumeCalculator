using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Relocate_tables_in_to_correct_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDevLaborVolumeRange_DbEntityCountRanges_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange");

            migrationBuilder.DropTable(
                name: "Niokrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatePointsCountRanges",
                table: "PlatePointsCountRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbEntityCountRanges",
                table: "DbEntityCountRanges");

            migrationBuilder.RenameTable(
                name: "OkrInnovationRate",
                newName: "OkrInnovationRate",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "OkrInnovationProperty",
                newName: "OkrInnovationProperty",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "NirScale",
                newName: "NirScale",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "NirInnovationRate",
                newName: "NirInnovationRate",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "NirInnovationProperty",
                newName: "NirInnovationProperty",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "DeviceCountRange",
                newName: "DeviceCountRange",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "DeviceComposition",
                newName: "DeviceComposition",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "DeviceComplexityRate",
                newName: "DeviceComplexityRate",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "PlatePointsCountRanges",
                newName: "PlatePointsCountRange",
                newSchema: "Dictionary");

            migrationBuilder.RenameTable(
                name: "DbEntityCountRanges",
                newName: "DbEntityCountRange",
                newSchema: "Dictionary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatePointsCountRange",
                schema: "Dictionary",
                table: "PlatePointsCountRange",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbEntityCountRange",
                schema: "Dictionary",
                table: "DbEntityCountRange",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DbDevLaborVolumeRange_DbEntityCountRange_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange",
                column: "DbEntityCountRangeID",
                principalSchema: "Dictionary",
                principalTable: "DbEntityCountRange",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDevLaborVolumeRange_DbEntityCountRange_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatePointsCountRange",
                schema: "Dictionary",
                table: "PlatePointsCountRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbEntityCountRange",
                schema: "Dictionary",
                table: "DbEntityCountRange");

            migrationBuilder.RenameTable(
                name: "OkrInnovationRate",
                schema: "Dictionary",
                newName: "OkrInnovationRate");

            migrationBuilder.RenameTable(
                name: "OkrInnovationProperty",
                schema: "Dictionary",
                newName: "OkrInnovationProperty");

            migrationBuilder.RenameTable(
                name: "NirScale",
                schema: "Dictionary",
                newName: "NirScale");

            migrationBuilder.RenameTable(
                name: "NirInnovationRate",
                schema: "Dictionary",
                newName: "NirInnovationRate");

            migrationBuilder.RenameTable(
                name: "NirInnovationProperty",
                schema: "Dictionary",
                newName: "NirInnovationProperty");

            migrationBuilder.RenameTable(
                name: "DeviceCountRange",
                schema: "Dictionary",
                newName: "DeviceCountRange");

            migrationBuilder.RenameTable(
                name: "DeviceComposition",
                schema: "Dictionary",
                newName: "DeviceComposition");

            migrationBuilder.RenameTable(
                name: "DeviceComplexityRate",
                schema: "Dictionary",
                newName: "DeviceComplexityRate");

            migrationBuilder.RenameTable(
                name: "PlatePointsCountRange",
                schema: "Dictionary",
                newName: "PlatePointsCountRanges");

            migrationBuilder.RenameTable(
                name: "DbEntityCountRange",
                schema: "Dictionary",
                newName: "DbEntityCountRanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatePointsCountRanges",
                table: "PlatePointsCountRanges",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbEntityCountRanges",
                table: "DbEntityCountRanges",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Niokrs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niokrs", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DbDevLaborVolumeRange_DbEntityCountRanges_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange",
                column: "DbEntityCountRangeID",
                principalTable: "DbEntityCountRanges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
