using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_Niokr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Niokr",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    NiokrCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niokr", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Niokr_NiokrCategory_NiokrCategoryID",
                        column: x => x.NiokrCategoryID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Niokr_NiokrCategoryID",
                schema: "Dictionary",
                table: "Niokr",
                column: "NiokrCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Niokr",
                schema: "Dictionary");
        }
    }
}
