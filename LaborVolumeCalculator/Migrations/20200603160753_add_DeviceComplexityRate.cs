using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_DeviceComplexityRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCountRange",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCountRange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceComplexityRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceCompositionID = table.Column<int>(nullable: false),
                    DeviceCountRangeID = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(8, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceComplexityRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeviceComplexityRate_DeviceComposition_DeviceCompositionID",
                        column: x => x.DeviceCompositionID,
                        principalTable: "DeviceComposition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceComplexityRate_DeviceCountRange_DeviceCountRangeID",
                        column: x => x.DeviceCountRangeID,
                        principalTable: "DeviceCountRange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceComplexityRate_DeviceCountRangeID",
                table: "DeviceComplexityRate",
                column: "DeviceCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceComplexityRate_DeviceCompositionID_DeviceCountRangeID",
                table: "DeviceComplexityRate",
                columns: new[] { "DeviceCompositionID", "DeviceCountRangeID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceComplexityRate");

            migrationBuilder.DropTable(
                name: "DeviceCountRange");
        }
    }
}
