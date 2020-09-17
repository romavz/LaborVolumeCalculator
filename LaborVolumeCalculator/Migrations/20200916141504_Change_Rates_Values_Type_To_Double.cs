using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_Rates_Values_Type_To_Double : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "StandardModulesUsingRate",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "SolutionInnovationRate",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "InfrastructureComplexityRate",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "Dictionary",
                table: "StandardModulesUsingRate",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "Dictionary",
                table: "SolutionInnovationRate",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "Dictionary",
                table: "InfrastructureComplexityRate",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
