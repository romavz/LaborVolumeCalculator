using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_NirLaborVolumesDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Documents");

            migrationBuilder.CreateTable(
                name: "NirLaborVolumesDoc",
                schema: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsImplemented = table.Column<bool>(nullable: false, defaultValue: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NiokrID = table.Column<int>(nullable: false),
                    NiokrStageID = table.Column<int>(nullable: false),
                    NirInnovationPropertyID = table.Column<int>(nullable: false),
                    NirScaleID = table.Column<int>(nullable: false),
                    NirInnovationRate = table.Column<float>(nullable: false),
                    Total = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirLaborVolumesDoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_Niokr_NiokrID",
                        column: x => x.NiokrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_NirInnovationProperty_NirInnovationPropertyID",
                        column: x => x.NirInnovationPropertyID,
                        principalTable: "NirInnovationProperty",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_NirScale_NirScaleID",
                        column: x => x.NirScaleID,
                        principalTable: "NirScale",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NirLaborVolumesDocRecord",
                schema: "Documents",
                columns: table => new
                {
                    NirLaborVolumesDocID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false),
                    Volume = table.Column<float>(nullable: false),
                    Calculation = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirLaborVolumesDocRecord", x => new { x.NirLaborVolumesDocID, x.LaborID });
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDocRecord_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDocRecord_NirLaborVolumesDoc_NirLaborVolumesDocID",
                        column: x => x.NirLaborVolumesDocID,
                        principalSchema: "Documents",
                        principalTable: "NirLaborVolumesDoc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NiokrID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NiokrID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NiokrStageID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NiokrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NirInnovationPropertyID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NirInnovationPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NirScaleID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NirScaleID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDocRecord_LaborID",
                schema: "Documents",
                table: "NirLaborVolumesDocRecord",
                column: "LaborID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirLaborVolumesDocRecord",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "NirLaborVolumesDoc",
                schema: "Documents");
        }
    }
}
