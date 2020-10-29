using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class NirDbDevLaborVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NirDbDevLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Volume = table.Column<double>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    LaborVolumeRangeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirDbDevLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirDbDevLaborVolume_DbDevLaborVolumeRange_LaborVolumeRangeID",
                        column: x => x.LaborVolumeRangeID,
                        principalSchema: "Dictionary",
                        principalTable: "DbDevLaborVolumeRange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirDbDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Registers",
                        principalTable: "NirStageSoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirDbDevLaborVolume_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirDbDevLaborVolume",
                column: "LaborVolumeRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_NirDbDevLaborVolume_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirDbDevLaborVolume",
                columns: new[] { "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirDbDevLaborVolume",
                schema: "Registers");
        }
    }
}
