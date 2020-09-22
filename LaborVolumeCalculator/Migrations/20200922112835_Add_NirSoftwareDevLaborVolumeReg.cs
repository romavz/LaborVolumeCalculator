using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_NirSoftwareDevLaborVolumeReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalVolume",
                schema: "Registers",
                table: "OkrLaborVolumeReg");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                schema: "Registers",
                table: "NirLaborVolumeReg");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    LaborID = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    NirID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolumeReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_LaborID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolumeReg_NirID_StageID_SoftwareDevLaborGroupID_LaborID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolumeReg",
                columns: new[] { "NirID", "StageID", "SoftwareDevLaborGroupID", "LaborID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<float>(
                name: "TotalVolume",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<float>(
                name: "TotalVolume",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
