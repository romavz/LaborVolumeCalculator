using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class remove_NirLaborVolumesDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirLaborVolumesDocRecord",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "NirLaborVolumesDoc",
                schema: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Documents");

            migrationBuilder.CreateTable(
                name: "NirLaborVolumesDoc",
                schema: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsImplemented = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NiokrStageID = table.Column<int>(type: "int", nullable: false),
                    NirID = table.Column<int>(type: "int", nullable: false),
                    NirInnovationRate = table.Column<float>(type: "real", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirLaborVolumesDoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NirLaborVolumesDoc_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NirLaborVolumesDocRecord",
                schema: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calculation = table.Column<float>(type: "real", nullable: false),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    NirLaborVolumesDocID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirLaborVolumesDocRecord", x => x.ID);
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
                name: "IX_NirLaborVolumesDoc_NiokrStageID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NiokrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDoc_NirID",
                schema: "Documents",
                table: "NirLaborVolumesDoc",
                column: "NirID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDocRecord_LaborID",
                schema: "Documents",
                table: "NirLaborVolumesDocRecord",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirLaborVolumesDocRecord_NirLaborVolumesDocID",
                schema: "Documents",
                table: "NirLaborVolumesDocRecord",
                column: "NirLaborVolumesDocID");
        }
    }
}
