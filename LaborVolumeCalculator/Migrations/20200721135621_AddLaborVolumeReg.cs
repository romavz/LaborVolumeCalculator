using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class AddLaborVolumeReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaborVolumeRegs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    NiokrID = table.Column<int>(nullable: false),
                    NiokrStageID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false),
                    Volume = table.Column<float>(nullable: false),
                    TotalVolume = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborVolumeRegs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborVolumeRegs_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaborVolumeRegs_Niokr_NiokrID",
                        column: x => x.NiokrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborVolumeRegs_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeRegs_LaborID",
                table: "LaborVolumeRegs",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeRegs_NiokrID",
                table: "LaborVolumeRegs",
                column: "NiokrID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeRegs_NiokrStageID",
                table: "LaborVolumeRegs",
                column: "NiokrStageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaborVolumeRegs");
        }
    }
}
