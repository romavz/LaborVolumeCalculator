using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_SoftwareDevLaborGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.RenameColumn(
                name: "SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                newName: "SoftwareDevEnvID");

            migrationBuilder.RenameIndex(
                name: "IX_Labor_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                newName: "IX_Labor_SoftwareDevEnvID");

            migrationBuilder.CreateTable(
                name: "SoftwareDevLaborGroup",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    OkrStageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevLaborGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroup_NiokrStage_OkrStageID",
                        column: x => x.OkrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroup_OkrStageID",
                schema: "Dictionary",
                table: "SoftwareDevLaborGroup",
                column: "OkrStageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvID",
                principalTable: "SoftwareDevEnvs",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropTable(
                name: "SoftwareDevLaborGroup",
                schema: "Dictionary");

            migrationBuilder.RenameColumn(
                name: "SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                newName: "SoftwareDevEnvId");

            migrationBuilder.RenameIndex(
                name: "IX_Labor_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                newName: "IX_Labor_SoftwareDevEnvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvId",
                principalTable: "SoftwareDevEnvs",
                principalColumn: "ID");
        }
    }
}
