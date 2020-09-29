using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_IntensiveRateFields_in_to_Nir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnalogDurationMonthes",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "IntensiveRateValue",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: 1.0);

            migrationBuilder.AddColumn<double>(
                name: "LaborsVolume",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalogDurationMonthes",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.DropColumn(
                name: "DateTo",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.DropColumn(
                name: "IntensiveRateValue",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.DropColumn(
                name: "LaborsVolume",
                schema: "Dictionary",
                table: "Nir");
        }
    }
}
