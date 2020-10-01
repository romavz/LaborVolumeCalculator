using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_LaborVolumes_to_NirStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirStageLaborVolume_NirStage_StageID",
                schema: "Registers",
                table: "NirStageLaborVolume");

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageLaborVolume_NirStage_StageID",
                schema: "Registers",
                table: "NirStageLaborVolume",
                column: "StageID",
                principalSchema: "Registers",
                principalTable: "NirStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirStageLaborVolume_NirStage_StageID",
                schema: "Registers",
                table: "NirStageLaborVolume");

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageLaborVolume_NirStage_StageID",
                schema: "Registers",
                table: "NirStageLaborVolume",
                column: "StageID",
                principalSchema: "Registers",
                principalTable: "NirStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
