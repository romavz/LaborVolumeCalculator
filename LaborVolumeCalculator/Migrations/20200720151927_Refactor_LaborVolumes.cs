using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_LaborVolumes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_LaborGroup_LaborGroupId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropTable(
                name: "LaborGroupRelation",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "LaborVolume",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "LaborGroup",
                schema: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_Labor_Code",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_LaborGroupId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "LaborGroupId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Dictionary",
                table: "NiokrStage",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "MaxVolume",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinVolume",
                schema: "Dictionary",
                table: "Labor",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "OkrStageID",
                schema: "Dictionary",
                table: "Labor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbEntityCountRanges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbEntityCountRanges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlatePointsCountRanges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatePointsCountRanges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareDevEnvs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevEnvs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labor_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                column: "DbEntityCountRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                column: "PlatePointsCountRangeID");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_OkrStageID",
                schema: "Dictionary",
                table: "Labor",
                column: "OkrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_DbEntityCountRanges_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor",
                column: "DbEntityCountRangeId",
                principalTable: "DbEntityCountRanges",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_PlatePointsCountRanges_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor",
                column: "PlatePointsCountRangeID",
                principalTable: "PlatePointsCountRanges",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "Labor",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor",
                column: "SoftwareDevEnvId",
                principalTable: "SoftwareDevEnvs",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_DbEntityCountRanges_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_PlatePointsCountRanges_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_Labor_SoftwareDevEnvs_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropTable(
                name: "DbEntityCountRanges");

            migrationBuilder.DropTable(
                name: "PlatePointsCountRanges");

            migrationBuilder.DropTable(
                name: "SoftwareDevEnvs");

            migrationBuilder.DropIndex(
                name: "IX_Labor_DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_OkrStageID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropIndex(
                name: "IX_Labor_SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Dictionary",
                table: "NiokrStage");

            migrationBuilder.DropColumn(
                name: "DbEntityCountRangeId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "PlatePointsCountRangeID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "MaxVolume",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "MinVolume",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "OkrStageID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropColumn(
                name: "SoftwareDevEnvId",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Dictionary",
                table: "Labor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "LaborGroupId",
                schema: "Dictionary",
                table: "Labor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LaborGroup",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborGroup_LaborGroup_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalSchema: "Dictionary",
                        principalTable: "LaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaborVolume",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    MaxValue = table.Column<float>(type: "real", nullable: false),
                    MinValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborVolume_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaborGroupRelation",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborGroupId = table.Column<int>(type: "int", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborGroupRelation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LaborGroupRelation_LaborGroup_LaborGroupId",
                        column: x => x.LaborGroupId,
                        principalSchema: "Dictionary",
                        principalTable: "LaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborGroupRelation_LaborGroup_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalSchema: "Dictionary",
                        principalTable: "LaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Labor_Code",
                schema: "Dictionary",
                table: "Labor",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Labor_LaborGroupId",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborGroup_Code",
                schema: "Dictionary",
                table: "LaborGroup",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaborGroup_ParentGroupId",
                schema: "Dictionary",
                table: "LaborGroup",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborGroupRelation_LaborGroupId",
                schema: "Dictionary",
                table: "LaborGroupRelation",
                column: "LaborGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborGroupRelation_ParentGroupId",
                schema: "Dictionary",
                table: "LaborGroupRelation",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborGroupRelation_LaborGroupId_ParentGroupId",
                schema: "Dictionary",
                table: "LaborGroupRelation",
                columns: new[] { "LaborGroupId", "ParentGroupId" },
                unique: true,
                filter: "LaborGroupId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LaborVolume_LaborID",
                schema: "Dictionary",
                table: "LaborVolume",
                column: "LaborID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_LaborGroup_LaborGroupId",
                schema: "Dictionary",
                table: "Labor",
                column: "LaborGroupId",
                principalSchema: "Dictionary",
                principalTable: "LaborGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
