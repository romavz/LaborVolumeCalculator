using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_NiokrStageRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NiokrStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NiokrID = table.Column<int>(nullable: false),
                    NiokrStageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiokrStageReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NiokrStageReg_Niokr_NiokrID",
                        column: x => x.NiokrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NiokrStageReg_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiokrStageReg_NiokrStageID",
                schema: "Registers",
                table: "NiokrStageReg",
                column: "NiokrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_NiokrStageReg_NiokrID_NiokrStageID",
                schema: "Registers",
                table: "NiokrStageReg",
                columns: new[] { "NiokrID", "NiokrStageID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiokrStageReg",
                schema: "Registers");
        }
    }
}
