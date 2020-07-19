using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_NirLaborVolumesDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumesDoc_Niokr_NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.DropIndex(
                name: "IX_NirLaborVolumesDoc_NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.DropColumn(
                name: "NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.AddColumn<int>(
                name: "NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NirID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumesDoc_Niokr_NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumesDoc_Niokr_NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.DropIndex(
                name: "IX_NirLaborVolumesDoc_NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.DropColumn(
                name: "NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc");

            migrationBuilder.AddColumn<int>(
                name: "NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NiokrID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumesDoc_Niokr_NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NiokrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID");
        }
    }
}
