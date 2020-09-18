using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_SoftwareDevLaborVolumeRanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_DbEntityCountRanges_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_PlatePointsCountRanges_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "LaborCategoryID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.CreateTable(
                name: "DevelopmentLabor",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LaborCategoryID = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentLabor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DevelopmentLabor_LaborCategory_LaborCategoryID",
                        column: x => x.LaborCategoryID,
                        principalSchema: "Dictionary",
                        principalTable: "LaborCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbDevLaborVolumeRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(nullable: false),
                    MinVolume = table.Column<double>(nullable: false),
                    MaxVolume = table.Column<double>(nullable: false),
                    DbEntityCountRangeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDevLaborVolumeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DbDevLaborVolumeRange_DbEntityCountRanges_DbEntityCountRangeID",
                        column: x => x.DbEntityCountRangeID,
                        principalTable: "DbEntityCountRanges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbDevLaborVolumeRange_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareDevLaborVolumeRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(nullable: false),
                    MinVolume = table.Column<double>(nullable: false),
                    MaxVolume = table.Column<double>(nullable: false),
                    SoftwareDevEnvID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevLaborVolumeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborVolumeRange_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnvs_SoftwareDevEnvID",
                        column: x => x.SoftwareDevEnvID,
                        principalTable: "SoftwareDevEnvs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbDevLaborVolumeRange_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange",
                column: "DbEntityCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_DbDevLaborVolumeRange_LaborID_DbEntityCountRangeID",
                schema: "Dictionary",
                table: "DbDevLaborVolumeRange",
                columns: new[] { "LaborID", "DbEntityCountRangeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentLabor_LaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "LaborCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "SoftwareDevEnvID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                columns: new[] { "LaborID", "SoftwareDevEnvID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbDevLaborVolumeRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "SoftwareDevLaborVolumeRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "DevelopmentLabor",
                schema: "Dictionary");

            migrationBuilder.AddColumn<int>(
                name: "DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labor_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                column: "DbEntityCountRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                column: "PlatePointsCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_DbEntityCountRanges_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                column: "DbEntityCountRangeId",
                principalTable: "DbEntityCountRanges",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_LaborCategory_LaborCategoryID",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_PlatePointsCountRanges_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                column: "PlatePointsCountRangeID",
                principalTable: "PlatePointsCountRanges",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvID",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvID",
                principalTable: "SoftwareDevEnvs",
                principalColumn: "ID");
        }
    }
}
