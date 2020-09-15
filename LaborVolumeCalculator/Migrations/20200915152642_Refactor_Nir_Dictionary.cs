using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_Nir_Dictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirInnovationRate_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.AddColumn<double>(
                name: "NirInnovationRateValue",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NirInnovationRateValue",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.AddColumn<int>(
                name: "NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirInnovationRate_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationRateID",
                principalTable: "NirInnovationRate",
                principalColumn: "ID");
        }
    }
}
