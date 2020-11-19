using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_DevelopmentLaborCategory_DeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "LaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "LaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
