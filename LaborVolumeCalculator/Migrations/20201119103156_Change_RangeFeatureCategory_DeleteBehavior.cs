using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_RangeFeatureCategory_DeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RangeFeature_RangeFeatureCategory_RangeFeatureCategoryID",
                schema: "Dictionary",
                table: "RangeFeature");

            migrationBuilder.AddForeignKey(
                name: "FK_RangeFeature_RangeFeatureCategory_RangeFeatureCategoryID",
                schema: "Dictionary",
                table: "RangeFeature",
                column: "RangeFeatureCategoryID",
                principalSchema: "Dictionary",
                principalTable: "RangeFeatureCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RangeFeature_RangeFeatureCategory_RangeFeatureCategoryID",
                schema: "Dictionary",
                table: "RangeFeature");

            migrationBuilder.AddForeignKey(
                name: "FK_RangeFeature_RangeFeatureCategory_RangeFeatureCategoryID",
                schema: "Dictionary",
                table: "RangeFeature",
                column: "RangeFeatureCategoryID",
                principalSchema: "Dictionary",
                principalTable: "RangeFeatureCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
