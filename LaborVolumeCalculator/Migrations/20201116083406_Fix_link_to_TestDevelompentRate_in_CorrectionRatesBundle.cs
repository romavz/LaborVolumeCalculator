using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Fix_link_to_TestDevelompentRate_in_CorrectionRatesBundle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CorrectionRatesBundle_TestsDevelopmentRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "TestsDevelopmentRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectionRatesBundle_TestsDevelopmentRate_TestsDevelopmentRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "TestsDevelopmentRateID",
                principalSchema: "Dictionary",
                principalTable: "TestsDevelopmentRate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectionRatesBundle_TestsDevelopmentRate_TestsDevelopmentRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle");

            migrationBuilder.DropIndex(
                name: "IX_CorrectionRatesBundle_TestsDevelopmentRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle");
        }
    }
}
