using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_Rates_Value_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "OkrInnovationRate",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(8, 4)");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "NirInnovationRate",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(8, 4)");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "DeviceComplexityRate",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(8, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Dictionary",
                table: "OkrInnovationRate",
                type: "DECIMAL(8, 4)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Dictionary",
                table: "NirInnovationRate",
                type: "DECIMAL(8, 4)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Dictionary",
                table: "DeviceComplexityRate",
                type: "DECIMAL(8, 4)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
