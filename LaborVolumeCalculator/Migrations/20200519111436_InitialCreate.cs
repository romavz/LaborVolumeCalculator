using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nir",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nir", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NirInnovationProperty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirInnovationProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NirInnovationRate",
                columns: table => new
                {
                    NirID = table.Column<int>(nullable: false),
                    NirInnovationPropertyID = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(8, 4)", nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirInnovationRate", x => new { x.NirID, x.NirInnovationPropertyID });
                    table.ForeignKey(
                        name: "FK_NirInnovationRate_Nir_NirID",
                        column: x => x.NirID,
                        principalTable: "Nir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirInnovationRate_NirInnovationProperty_NirInnovationPropertyID",
                        column: x => x.NirInnovationPropertyID,
                        principalTable: "NirInnovationProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirInnovationRate_NirInnovationPropertyID",
                table: "NirInnovationRate",
                column: "NirInnovationPropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirInnovationRate");

            migrationBuilder.DropTable(
                name: "Nir");

            migrationBuilder.DropTable(
                name: "NirInnovationProperty");
        }
    }
}
