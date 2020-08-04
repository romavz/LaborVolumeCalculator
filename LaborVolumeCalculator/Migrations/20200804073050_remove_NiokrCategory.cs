using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class remove_NiokrCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NiokrStage_NiokrCategory_NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage");

            migrationBuilder.DropTable(
                name: "NiokrCategory",
                schema: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_NiokrStage_NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage");

            migrationBuilder.DropColumn(
                name: "NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NiokrCategory",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiokrCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiokrStage_NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage",
                column: "NiokrCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_NiokrStage_NiokrCategory_NiokrCategoryID",
                schema: "Dictionary",
                table: "NiokrStage",
                column: "NiokrCategoryID",
                principalSchema: "Dictionary",
                principalTable: "NiokrCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
