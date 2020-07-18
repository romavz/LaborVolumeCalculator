using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class RefactorInnovationRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Niokr_NiokrCategory_NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropIndex(
                name: "IX_Niokr_NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OkrInnovationRate",
                table: "OkrInnovationRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate");

            migrationBuilder.DropColumn(
                name: "NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "OkrInnovationRate",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "NirInnovationRate",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OkrInnovationRate",
                table: "OkrInnovationRate",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrInnovationRate_OkrInnovationPropertyID_DeviceCompositionID",
                table: "OkrInnovationRate",
                columns: new[] { "OkrInnovationPropertyID", "DeviceCompositionID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NirInnovationRate_NirScaleID_NirInnovationPropertyID",
                table: "NirInnovationRate",
                columns: new[] { "NirScaleID", "NirInnovationPropertyID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OkrInnovationRate",
                table: "OkrInnovationRate");

            migrationBuilder.DropIndex(
                name: "IX_OkrInnovationRate_OkrInnovationPropertyID_DeviceCompositionID",
                table: "OkrInnovationRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate");

            migrationBuilder.DropIndex(
                name: "IX_NirInnovationRate_NirScaleID_NirInnovationPropertyID",
                table: "NirInnovationRate");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "OkrInnovationRate");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "NirInnovationRate");

            migrationBuilder.AddColumn<int>(
                name: "NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OkrInnovationRate",
                table: "OkrInnovationRate",
                columns: new[] { "OkrInnovationPropertyID", "DeviceCompositionID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate",
                columns: new[] { "NirScaleID", "NirInnovationPropertyID" });

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NiokrCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Niokr_NiokrCategory_NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NiokrCategoryID",
                principalSchema: "Dictionary",
                principalTable: "NiokrCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
