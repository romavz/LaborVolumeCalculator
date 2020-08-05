using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_LaborCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LaborCategory",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labor_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropTable(
                name: "LaborCategory",
                schema: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_Labor_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");
        }
    }
}
