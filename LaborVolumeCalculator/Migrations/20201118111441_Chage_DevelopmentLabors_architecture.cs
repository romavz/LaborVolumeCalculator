using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Chage_DevelopmentLabors_architecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropTable(
                name: "PlatePointsCountRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "NirDbDevLaborVolume",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborVolume",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "DbDevLaborVolumeRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "SoftwareDevLaborVolumeRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "DbEntityCountRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "SoftwareDevEnv",
                schema: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_DevelopmentLabor_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropColumn(
                name: "DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Dictionary",
                table: "DevelopmentLabor");

            migrationBuilder.CreateTable(
                name: "RangeFeatureCategory",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeFeatureCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RangeFeature",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RangeFeatureCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeFeature", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RangeFeature_RangeFeatureCategory_RangeFeatureCategoryID",
                        column: x => x.RangeFeatureCategoryID,
                        principalSchema: "Dictionary",
                        principalTable: "RangeFeatureCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaborVolumeRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(nullable: false),
                    RangeFeatureID = table.Column<int>(nullable: false),
                    MinVolume = table.Column<double>(nullable: false),
                    MaxVolume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborVolumeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborVolumeRange_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaborVolumeRange_RangeFeature_RangeFeatureID",
                        column: x => x.RangeFeatureID,
                        principalSchema: "Dictionary",
                        principalTable: "RangeFeature",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NirDevelopmentLaborVolume",
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
                    table.PrimaryKey("PK_NirDevelopmentLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirDevelopmentLaborVolume_LaborVolumeRange_LaborVolumeRangeID",
                        column: x => x.LaborVolumeRangeID,
                        principalSchema: "Dictionary",
                        principalTable: "LaborVolumeRange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirDevelopmentLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Registers",
                        principalTable: "NirStageSoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeRange_RangeFeatureID",
                schema: "Dictionary",
                table: "LaborVolumeRange",
                column: "RangeFeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolumeRange_LaborID_RangeFeatureID",
                schema: "Dictionary",
                table: "LaborVolumeRange",
                columns: new[] { "LaborID", "RangeFeatureID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RangeFeature_RangeFeatureCategoryID",
                schema: "Dictionary",
                table: "RangeFeature",
                column: "RangeFeatureCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NirDevelopmentLaborVolume_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirDevelopmentLaborVolume",
                column: "LaborVolumeRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_NirDevelopmentLaborVolume_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirDevelopmentLaborVolume",
                columns: new[] { "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirDevelopmentLaborVolume",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "LaborVolumeRange",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "RangeFeature",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "RangeFeatureCategory",
                schema: "Dictionary");

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DbEntityCountRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEntityCountRange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatePointsCountRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatePointsCountRange", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareDevEnv",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevEnv", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DbDevLaborVolumeRange",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbEntityCountRangeID = table.Column<int>(type: "int", nullable: false),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    MaxVolume = table.Column<double>(type: "float", nullable: false),
                    MinVolume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDevLaborVolumeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DbDevLaborVolumeRange_DbEntityCountRange_DbEntityCountRangeID",
                        column: x => x.DbEntityCountRangeID,
                        principalSchema: "Dictionary",
                        principalTable: "DbEntityCountRange",
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevEnvID = table.Column<int>(type: "int", nullable: false),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    MaxVolume = table.Column<double>(type: "float", nullable: false),
                    MinVolume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevLaborVolumeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborVolumeRange_SoftwareDevEnv_DevEnvID",
                        column: x => x.DevEnvID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevEnv",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborVolumeRange_DevelopmentLabor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "DevelopmentLabor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NirDbDevLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborVolumeRangeID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborVolumeRangeID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_SoftwareDevLaborVolumeRange_LaborVolumeRangeID",
                        column: x => x.LaborVolumeRangeID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborVolumeRange",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Registers",
                        principalTable: "NirStageSoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentLabor_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "DevelopmentLaborCategoryID");

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
                name: "IX_SoftwareDevLaborVolumeRange_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                column: "DevEnvID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborVolumeRange_LaborID_DevEnvID",
                schema: "Dictionary",
                table: "SoftwareDevLaborVolumeRange",
                columns: new[] { "LaborID", "DevEnvID" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "LaborVolumeRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                columns: new[] { "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DevelopmentLabor_LaborCategory_DevelopmentLaborCategoryID",
                schema: "Dictionary",
                table: "DevelopmentLabor",
                column: "DevelopmentLaborCategoryID",
                principalSchema: "Dictionary",
                principalTable: "LaborCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
