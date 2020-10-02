using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Rename_NirTableColumn_LaborsVolume_to_Volume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborsVolume",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                schema: "Dictionary",
                table: "Nir",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                schema: "Dictionary",
                table: "Nir");

            migrationBuilder.AddColumn<double>(
                name: "LaborsVolume",
                schema: "Dictionary",
                table: "Nir",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
