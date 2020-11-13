using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_unique_index_to_DevelopmentLabor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentLabor_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentLabor_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "DevelopmentLaborCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentLabor_LaborCategoryID_Code",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                columns: new[] { "LaborCategoryID", "Code" },
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "DevelopmentLaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentLabor_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentLabor_LaborCategoryID_Code",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropColumn(
                name: "DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentLabor_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "LaborCategoryID");

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
    }
}
