using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_Code_to_ComponentsInteractionArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsInteractionArchitecture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Dictionary",
                table: "ComponentsInteractionArchitecture");
        }
    }
}
