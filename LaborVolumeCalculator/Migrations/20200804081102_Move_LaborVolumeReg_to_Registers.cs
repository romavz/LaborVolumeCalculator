using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Move_LaborVolumeReg_to_Registers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeRegs_Labor_LaborID",
                table: "LaborVolumeRegs");

            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeRegs_Niokr_NiokrID",
                table: "LaborVolumeRegs");

            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeRegs_NiokrStage_NiokrStageID",
                table: "LaborVolumeRegs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LaborVolumeRegs",
                table: "LaborVolumeRegs");

            migrationBuilder.EnsureSchema(
                name: "Registers");

            migrationBuilder.RenameTable(
                name: "LaborVolumeRegs",
                newName: "LaborVolumeReg",
                newSchema: "Registers");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeRegs_NiokrStageID",
                schema: "Registers",
                table: "LaborVolumeReg",
                newName: "IX_LaborVolumeReg_NiokrStageID");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeRegs_NiokrID",
                schema: "Registers",
                table: "LaborVolumeReg",
                newName: "IX_LaborVolumeReg_NiokrID");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeRegs_LaborID",
                schema: "Registers",
                table: "LaborVolumeReg",
                newName: "IX_LaborVolumeReg_LaborID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaborVolumeReg",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeReg_Labor_LaborID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "LaborID",
                principalSchema: "Dictionary",
                principalTable: "Labor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeReg_Niokr_NiokrID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "NiokrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeReg_NiokrStage_NiokrStageID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "NiokrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeReg_Labor_LaborID",
                schema: "Registers",
                table: "LaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeReg_Niokr_NiokrID",
                schema: "Registers",
                table: "LaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_LaborVolumeReg_NiokrStage_NiokrStageID",
                schema: "Registers",
                table: "LaborVolumeReg");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LaborVolumeReg",
                schema: "Registers",
                table: "LaborVolumeReg");

            migrationBuilder.RenameTable(
                name: "LaborVolumeReg",
                schema: "Registers",
                newName: "LaborVolumeRegs");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeReg_NiokrStageID",
                table: "LaborVolumeRegs",
                newName: "IX_LaborVolumeRegs_NiokrStageID");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeReg_NiokrID",
                table: "LaborVolumeRegs",
                newName: "IX_LaborVolumeRegs_NiokrID");

            migrationBuilder.RenameIndex(
                name: "IX_LaborVolumeReg_LaborID",
                table: "LaborVolumeRegs",
                newName: "IX_LaborVolumeRegs_LaborID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaborVolumeRegs",
                table: "LaborVolumeRegs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeRegs_Labor_LaborID",
                table: "LaborVolumeRegs",
                column: "LaborID",
                principalSchema: "Dictionary",
                principalTable: "Labor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeRegs_Niokr_NiokrID",
                table: "LaborVolumeRegs",
                column: "NiokrID",
                principalSchema: "Dictionary",
                principalTable: "Niokr",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaborVolumeRegs_NiokrStage_NiokrStageID",
                table: "LaborVolumeRegs",
                column: "NiokrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
