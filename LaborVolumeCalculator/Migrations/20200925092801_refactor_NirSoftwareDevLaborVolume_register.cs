using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class refactor_NirSoftwareDevLaborVolume_register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    LaborVolumeRangeID = table.Column<int>(nullable: false),
                    NirID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_SoftwareDevLaborVolumeRange_LaborVolumeRangeID",
                        column: x => x.LaborVolumeRangeID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborVolumeRange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "LaborVolumeRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_NirID_StageID_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                columns: new[] { "NirID", "StageID", "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborVolume",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    NirID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_LaborID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_NirID_StageID_SoftwareDevLaborGroupID_LaborID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                columns: new[] { "NirID", "StageID", "SoftwareDevLaborGroupID", "LaborID" },
                unique: true);
        }
    }
}
