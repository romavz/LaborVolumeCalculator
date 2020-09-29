using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_NirStageLaborVolume_registration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirStageLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageLaborVolume_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirStageLaborVolume_NirStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Registers",
                        principalTable: "NirStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStageLaborVolume_LaborID",
                schema: "Registers",
                table: "NirStageLaborVolume",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageLaborVolume_StageID_LaborID",
                schema: "Registers",
                table: "NirStageLaborVolume",
                columns: new[] { "StageID", "LaborID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirStageLaborVolume",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    NirID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirLaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumeReg_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumeReg_Nir_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Nir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumeReg_Stage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumeReg_LaborID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumeReg_StageID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumeReg_NirID_StageID_LaborID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                columns: new[] { "NirID", "StageID", "LaborID" },
                unique: true);
        }
    }
}
