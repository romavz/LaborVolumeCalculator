using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_NirStageOntdLaborVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NirStageOntdLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageOntdLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageOntdLaborVolume_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirStageOntdLaborVolume_NirStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Registers",
                        principalTable: "NirStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStageOntdLaborVolume_LaborID",
                schema: "Registers",
                table: "NirStageOntdLaborVolume",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageOntdLaborVolume_StageID_LaborID",
                schema: "Registers",
                table: "NirStageOntdLaborVolume",
                columns: new[] { "StageID", "LaborID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirStageOntdLaborVolume",
                schema: "Registers");
        }
    }
}
