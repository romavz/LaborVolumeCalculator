using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class SplitNiokrStageReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiokrStageReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NirID = table.Column<int>(nullable: false),
                    NirStageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirStageReg_NiokrStage_NirStageID",
                        column: x => x.NirStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OkrStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkrID = table.Column<int>(nullable: false),
                    OkrStageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrStageReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrStageReg_Niokr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrStageReg_NiokrStage_OkrStageID",
                        column: x => x.OkrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "NirStageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirID_NirStageID",
                schema: "Registers",
                table: "NirStageReg",
                columns: new[] { "NirID", "NirStageID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "OkrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrID_OkrStageID",
                schema: "Registers",
                table: "OkrStageReg",
                columns: new[] { "OkrID", "OkrStageID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirStageReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrStageReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NiokrStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NiokrID = table.Column<int>(type: "int", nullable: false),
                    NiokrStageID = table.Column<int>(type: "int", nullable: false)
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
    }
}
