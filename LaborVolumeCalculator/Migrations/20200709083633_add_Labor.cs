using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_Labor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labor",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LaborGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labor_LaborGroup_LaborGroupId",
                        column: x => x.LaborGroupId,
                        principalSchema: "Dictionary",
                        principalTable: "LaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labor_Code",
                schema: "Dictionary",
                table: "Labor",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labor_LaborGroupId",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labor",
                schema: "Dictionary");
        }
    }
}
