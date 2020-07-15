using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_NiokrStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NiokrStage",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NiokrCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiokrStage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NiokrStage_NiokrCategory_NiokrCategoryID",
                        column: x => x.NiokrCategoryID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiokrStage_NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage",
                column: "NiokrCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiokrStage",
                schema: "Dictionary");
        }
    }
}
