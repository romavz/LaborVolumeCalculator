using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Change_SoftwareDevEnv_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareDevLaborVolumeRange_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareDevEnvs",
                table: "SoftwareDevEnvs");

            migrationBuilder.DropColumn(
                name: "SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.RenameTable(
                name: "SoftwareDevEnvs",
                newName: "SoftwareDevEnv",
                newSchema: "Dictionary");

            migrationBuilder.AddColumn<int>(
                name: "DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareDevEnv",
                schema: "Dictionary",
                table: "SoftwareDevEnv",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "DevEnvID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                columns: new[] { "LaborID", "DevEnvID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnv_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "DevEnvID",
                principalSchema: "Dictionary",
                principalTable: "SoftwareDevEnv",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnv_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareDevLaborVolumeRange_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareDevEnv",
                schema: "Dictionary",
                table: "SoftwareDevEnv");

            migrationBuilder.DropColumn(
                name: "DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange");

            migrationBuilder.RenameTable(
                name: "SoftwareDevEnv",
                schema: "Dictionary",
                newName: "SoftwareDevEnvs");

            migrationBuilder.AddColumn<int>(
                name: "SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareDevEnvs",
                table: "SoftwareDevEnvs",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "SoftwareDevEnvID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                columns: new[] { "LaborID", "SoftwareDevEnvID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "SoftwareDevEnvID",
                principalTable: "SoftwareDevEnvs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
