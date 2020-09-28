using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Remove_Stages_Dictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStageDefaultLabors_NiokrStage_StageID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareDevLaborGroup_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "SoftwareDevLaborGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumeReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrLaborVolumeReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropTable(
                name: "NirStageReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrStageReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "NiokrStage",
                schema: "Dictionary");

            migrationBuilder.CreateTable(
                name: "Stage",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NirStage",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NirID = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStage_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OkrStage",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkrID = table.Column<int>(nullable: false),
                    StageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrStage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrStage_Niokr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrStage_Stage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStage_NirID",
                schema: "Registers",
                table: "NirStage",
                column: "NirID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStage_StageID",
                schema: "Registers",
                table: "OkrStage",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStage_OkrID_StageID",
                schema: "Registers",
                table: "OkrStage",
                columns: new[] { "OkrID", "StageID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_Stage_OkrStageID",
                schema: "Dictionary",
                table: "Labor",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageDefaultLabors_Stage_StageID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareDevLaborGroup_Stage_OkrStageID",
                schema: "Dictionary",
                table: "SoftwareDevLaborGroup",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumeReg_Stage_StageID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Stage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Stage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrLaborVolumeReg_Stage_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Stage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "Stage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labor_Stage_OkrStageID",
                schema: "Dictionary",
                table: "Labor");

            migrationBuilder.DropForeignKey(
                name: "FK_NirStageDefaultLabors_Stage_StageID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareDevLaborGroup_Stage_OkrStageID",
                schema: "Dictionary",
                table: "SoftwareDevLaborGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_NirLaborVolumeReg_Stage_StageID",
                schema: "Registers",
                table: "NirLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_Stage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Stage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrLaborVolumeReg_Stage_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg");

            migrationBuilder.DropForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_Stage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg");

            migrationBuilder.DropTable(
                name: "NirStage",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrStage",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "Stage",
                schema: "Dictionary");

            migrationBuilder.CreateTable(
                name: "NiokrStage",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiokrStage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NirStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NirID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirStageReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OkrStageReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkrID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrStageReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrStageReg_Niokr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrStageReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_StageID",
                schema: "Registers",
                table: "NirStageReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageReg_NirID_StageID",
                schema: "Registers",
                table: "NirStageReg",
                columns: new[] { "NirID", "StageID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_StageID",
                schema: "Registers",
                table: "OkrStageReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageReg_OkrID_StageID",
                schema: "Registers",
                table: "OkrStageReg",
                columns: new[] { "OkrID", "StageID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Labor_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "Labor",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NirStageDefaultLabors_NiokrStage_StageID",
                schema: "Dictionary",
                table: "NirStageDefaultLabors",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareDevLaborGroup_NiokrStage_OkrStageID",
                schema: "Dictionary",
                table: "SoftwareDevLaborGroup",
                column: "OkrStageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirLaborVolumeReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirLaborVolumeReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NiokrStage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrLaborVolumeReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "StageID",
                principalSchema: "Dictionary",
                principalTable: "NiokrStage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
