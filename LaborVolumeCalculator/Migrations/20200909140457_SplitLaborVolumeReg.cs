using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class SplitLaborVolumeReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaborVolumeReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volume = table.Column<float>(nullable: false),
                    TotalVolume = table.Column<float>(nullable: false),
                    NirID = table.Column<int>(nullable: false),
                    StageID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
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
                        name: "FK_NirLaborVolumeReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumeReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OkrLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volume = table.Column<float>(nullable: false),
                    TotalVolume = table.Column<float>(nullable: false),
                    OkrID = table.Column<int>(nullable: false),
                    StageID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrLaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_Niokr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
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

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_LaborID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_OkrID_StageID_LaborID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                columns: new[] { "OkrID", "StageID", "LaborID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "LaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    NiokrID = table.Column<int>(type: "int", nullable: false),
                    NiokrStageID = table.Column<int>(type: "int", nullable: false),
                    TotalVolume = table.Column<float>(type: "real", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborVolumeReg_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaborVolumeReg_Niokr_NiokrID",
                        column: x => x.NiokrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborVolumeReg_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeReg_LaborID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeReg_NiokrID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "NiokrID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeReg_NiokrStageID",
                schema: "Registers",
                table: "LaborVolumeReg",
                column: "NiokrStageID");
        }
    }
}
