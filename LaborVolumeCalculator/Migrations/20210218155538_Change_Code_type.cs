using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_Code_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsMakroArchitecture",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsInteractionArchitecture",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsMakroArchitecture",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsInteractionArchitecture",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
