using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class ChangeNirSoftwareDevLaborVolume_deleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID",
                principalSchema: "Registers",
                principalTable: "NirStageSoftwareDevLaborGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID",
                principalSchema: "Registers",
                principalTable: "NirStageSoftwareDevLaborGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
