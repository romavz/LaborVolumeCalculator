using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_CorrectionRatesBundle_Link_Into_NirSoftwareDevLaborGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageSoftwareDevLaborGroup_CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup",
                column: "CorrectionRatesBundleID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageSoftwareDevLaborGroup_CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup",
                column: "CorrectionRatesBundleID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageSoftwareDevLaborGroup_CorrectionRatesBundle_CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup",
                column: "CorrectionRatesBundleID",
                principalSchema: "Dictionary",
                principalTable: "CorrectionRatesBundle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStageSoftwareDevLaborGroup_CorrectionRatesBundle_CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup",
                column: "CorrectionRatesBundleID",
                principalSchema: "Dictionary",
                principalTable: "CorrectionRatesBundle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirStageSoftwareDevLaborGroup_CorrectionRatesBundle_CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStageSoftwareDevLaborGroup_CorrectionRatesBundle_CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup");

            migrationBuilder.DropIndex(
                name: "IX_OkrStageSoftwareDevLaborGroup_CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup");

            migrationBuilder.DropIndex(
                name: "IX_NirStageSoftwareDevLaborGroup_CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup");

            migrationBuilder.DropColumn(
                name: "CorrectionRatesBundleID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup");

            migrationBuilder.DropColumn(
                name: "CorrectionRatesBundleID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup");
        }
    }
}
