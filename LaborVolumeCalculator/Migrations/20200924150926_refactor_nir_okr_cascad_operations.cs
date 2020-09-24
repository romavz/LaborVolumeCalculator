using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class refactor_nir_okr_cascad_operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStageReg_Niokr_NirID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStageReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageReg_Niokr_NirID",
                schema: "Registers",
                table: "NirStageReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStageReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStageReg_Niokr_NirID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStageReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageReg_Niokr_NirID",
                schema: "Registers",
                table: "NirStageReg",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStageReg_Niokr_OkrID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "OkrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
