using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_Nir_Okr_StageRegs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirStageReg_NiokrStage_NirStageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStageReg_NiokrStage_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_OkrStageReg_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_OkrStageReg_OkrID_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_NirStageReg_NirStageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropIndex(
                name: "IX_NirStageReg_NirID_NirStageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropColumn(
                name: "OkrStageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropColumn(
                name: "NirStageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.AddColumn<int>(
                name: "StageID",
                schema: "Registers",
                table: "OkrStageReg",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StageID",
                schema: "Registers",
                table: "NirStageReg",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_StageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrID_StageID",
                schema: "Registers",
                table: "OkrStageReg",
                columns: new[] { "OkrID", "StageID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_StageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirID_StageID",
                schema: "Registers",
                table: "NirStageReg",
                columns: new[] { "NirID", "StageID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStageReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirStageReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrStageReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_OkrStageReg_StageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_OkrStageReg_OkrID_StageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropIndex(
                name: "IX_NirStageReg_StageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropIndex(
                name: "IX_NirStageReg_NirID_StageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.DropColumn(
                name: "StageID",
                schema: "Registers",
                table: "OkrStageReg");

            migrationBuilder.DropColumn(
                name: "StageID",
                schema: "Registers",
                table: "NirStageReg");

            migrationBuilder.AddColumn<int>(
                name: "OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "OkrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrID_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                columns: new[] { "OkrID", "OkrStageID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "NirStageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirID_NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                columns: new[] { "NirID", "NirStageID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageReg_NiokrStage_NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "NirStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrStageReg_NiokrStage_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
