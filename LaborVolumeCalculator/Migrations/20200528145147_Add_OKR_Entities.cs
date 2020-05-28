using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_OKR_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceComposition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceComposition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OkrInnovationProperty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrInnovationProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OkrComplexityRate",
                columns: table => new
                {
                    DeviceCompositionID = table.Column<int>(nullable: false),
                    MinDeviceCount = table.Column<byte>(nullable: false),
                    MaxDeviceCount = table.Column<byte>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "OkrInnovationRate",
                columns: table => new
                {
                    OkrInnovationPropertyID = table.Column<int>(nullable: false),
                    DeviceCompositionID = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL(8, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrInnovationRate", x => new { x.OkrInnovationPropertyID, x.DeviceCompositionID });
                    table.ForeignKey(
                        name: "FK_OkrInnovationRate_DeviceComposition_DeviceCompositionID",
                        column: x => x.DeviceCompositionID,
                        principalTable: "DeviceComposition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrInnovationRate_OkrInnovationProperty_OkrInnovationPropertyID",
                        column: x => x.OkrInnovationPropertyID,
                        principalTable: "OkrInnovationProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OkrInnovationRate_DeviceCompositionID",
                table: "OkrInnovationRate",
                column: "DeviceCompositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OkrComplexityRate");

            migrationBuilder.DropTable(
                name: "OkrInnovationRate");

            migrationBuilder.DropTable(
                name: "DeviceComposition");

            migrationBuilder.DropTable(
                name: "OkrInnovationProperty");
        }
    }
}
