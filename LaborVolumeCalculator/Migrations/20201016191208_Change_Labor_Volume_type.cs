using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_Labor_Volume_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinVolume",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "MaxVolume",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "MinVolume",
                schema: "Dictionary",
                table: "Labor",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "MaxVolume",
                schema: "Dictionary",
                table: "Labor",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
