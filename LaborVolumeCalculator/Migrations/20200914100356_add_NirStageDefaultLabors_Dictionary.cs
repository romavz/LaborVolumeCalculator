using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_NirStageDefaultLabors_Dictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NirStageDefaultLabors",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageDefaultLabors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageDefaultLabors_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirStageDefaultLabors_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStageDefaultLabors_LaborID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageDefaultLabors_StageID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors",
                column: "StageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirStageDefaultLabors",
                schema: "Dictionary");
        }
    }
}
