using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class drop_OkrMultiFunctionRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OkrComplexityRate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OkrComplexityRate",
                columns: table => new
                {
                    DeviceCompositionID = table.Column<int>(type: "int", nullable: false),
                    MinDeviceCount = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxDeviceCount = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(8, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrComplexityRate", x => new { x.DeviceCompositionID, x.MinDeviceCount, x.MaxDeviceCount });
                    table.ForeignKey(
                        name: "FK_OkrComplexityRate_DeviceComposition_DeviceCompositionID",
                        column: x => x.DeviceCompositionID,
                        principalTable: "DeviceComposition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
