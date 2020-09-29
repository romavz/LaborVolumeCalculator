using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_LivingDates_to_NirStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                schema: "Registers",
                table: "NirStage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                schema: "Registers",
                table: "NirStage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                schema: "Registers",
                table: "NirStage",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropColumn(
                name: "DateTo",
                schema: "Registers",
                table: "NirStage");

            migrationBuilder.DropColumn(
                name: "Volume",
                schema: "Registers",
                table: "NirStage");
        }
    }
}
