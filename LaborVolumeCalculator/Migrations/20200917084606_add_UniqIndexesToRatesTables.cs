using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_UniqIndexesToRatesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestsDevelopmentRate_ComponentsMicroArchitectureID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate");

            migrationBuilder.DropIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsInteractionArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate");

            migrationBuilder.CreateIndex(
                name: "IX_TestsDevelopmentRate_ComponentsMicroArchitectureID_TestsCoverageLevelID_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                columns: new[] { "ComponentsMicroArchitectureID", "TestsCoverageLevelID", "TestsScaleID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsInteractionArchitectureID_ComponentsMakroArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                columns: new[] { "ComponentsInteractionArchitectureID", "ComponentsMakroArchitectureID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestsDevelopmentRate_ComponentsMicroArchitectureID_TestsCoverageLevelID_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate");

            migrationBuilder.DropIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsInteractionArchitectureID_ComponentsMakroArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate");

            migrationBuilder.CreateIndex(
                name: "IX_TestsDevelopmentRate_ComponentsMicroArchitectureID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "ComponentsMicroArchitectureID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsInteractionArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                column: "ComponentsInteractionArchitectureID");
        }
    }
}
