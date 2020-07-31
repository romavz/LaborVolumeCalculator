using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_Nir_and_Okr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NiokrCategory",
                schema: "Dictionary",
                table: "Niokr",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirScaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCompositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirInnovationProperty_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationPropertyID",
                principalTable: "NirInnovationProperty",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirInnovationRate_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirInnovationRateID",
                principalTable: "NirInnovationRate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NirScale_NirScaleID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NirScaleID",
                principalTable: "NirScale",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceComplexityRate_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceComplexityRateID",
                principalTable: "DeviceComplexityRate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceComposition_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCompositionID",
                principalTable: "DeviceComposition",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_DeviceCountRange_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr",
                column: "DeviceCountRangeID",
                principalTable: "DeviceCountRange",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_OkrInnovationProperty_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationPropertyID",
                principalTable: "OkrInnovationProperty",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_OkrInnovationRate_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr",
                column: "OkrInnovationRateID",
                principalTable: "OkrInnovationRate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirInnovationProperty_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirInnovationRate_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NirScale_NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceComplexityRate_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceComposition_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_DeviceCountRange_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_OkrInnovationProperty_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_OkrInnovationRate_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NiokrCategory",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "NirScaleID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceComplexityRateID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceCompositionID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "DeviceCountRangeID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "OkrInnovationPropertyID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropColumn(
                name: "OkrInnovationRateID",
                schema: "Dictionary",
                table: "Niokr");
        }
    }
}
