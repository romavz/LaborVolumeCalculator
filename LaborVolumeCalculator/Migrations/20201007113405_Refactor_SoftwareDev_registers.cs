using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_SoftwareDev_registers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Stage_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrLaborVolumeReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrSoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropIndex(
                name: "IX_NirSoftwareDevLaborVolume_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropIndex(
                name: "IX_NirSoftwareDevLaborVolume_NirID_StageID_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropColumn(
                name: "NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropColumn(
                name: "StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.CreateTable(
                name: "NirStageSoftwareDevLaborGroup",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    SolutionInnovationRateID = table.Column<int>(nullable: false),
                    SolutionInnovationRateValue = table.Column<double>(nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(nullable: false),
                    StandardModulesUsingRateValue = table.Column<double>(nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(nullable: false),
                    InfrastructureComplexityRateValue = table.Column<double>(nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(nullable: false),
                    TestsDevelopmentRateValue = table.Column<double>(nullable: false),
                    ArchitectureComplexityRateID = table.Column<int>(nullable: false),
                    ArchitectureComplexityRateValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirStageSoftwareDevLaborGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirStageSoftwareDevLaborGroup_NirStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Registers",
                        principalTable: "NirStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OkrStageLaborVolume",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    LaborID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrStageLaborVolume", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrStageLaborVolume_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrStageLaborVolume_OkrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Registers",
                        principalTable: "OkrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OkrStageSoftwareDevLaborGroup",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageID = table.Column<int>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    SolutionInnovationRateID = table.Column<int>(nullable: false),
                    SolutionInnovationRateValue = table.Column<double>(nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(nullable: false),
                    StandardModulesUsingRateValue = table.Column<double>(nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(nullable: false),
                    InfrastructureComplexityRateValue = table.Column<double>(nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(nullable: false),
                    TestsDevelopmentRateValue = table.Column<double>(nullable: false),
                    ArchitectureComplexityRateID = table.Column<int>(nullable: false),
                    ArchitectureComplexityRateValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrStageSoftwareDevLaborGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrStageSoftwareDevLaborGroup_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrStageSoftwareDevLaborGroup_OkrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Registers",
                        principalTable: "OkrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                columns: new[] { "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirStageSoftwareDevLaborGroup_StageID_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirStageSoftwareDevLaborGroup",
                columns: new[] { "StageID", "SoftwareDevLaborGroupID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageLaborVolume_LaborID",
                schema: "Registers",
                table: "OkrStageLaborVolume",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageLaborVolume_StageID_LaborID",
                schema: "Registers",
                table: "OkrStageLaborVolume",
                columns: new[] { "StageID", "LaborID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrStageSoftwareDevLaborGroup_StageID_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "OkrStageSoftwareDevLaborGroup",
                columns: new[] { "StageID", "SoftwareDevLaborGroupID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID",
                principalSchema: "Registers",
                principalTable: "NirStageSoftwareDevLaborGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_NirStageSoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.DropTable(
                name: "NirStageSoftwareDevLaborGroup",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrStageLaborVolume",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrStageSoftwareDevLaborGroup",
                schema: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume");

            migrationBuilder.AddColumn<int>(
                name: "NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborGroupReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchitectureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    ArchitectureComplexityRateValue = table.Column<double>(type: "float", nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    InfrastructureComplexityRateValue = table.Column<double>(type: "float", nullable: false),
                    NirID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    SolutionInnovationRateID = table.Column<int>(type: "int", nullable: false),
                    SolutionInnovationRateValue = table.Column<double>(type: "float", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(type: "int", nullable: false),
                    StandardModulesUsingRateValue = table.Column<double>(type: "float", nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(type: "int", nullable: false),
                    TestsDevelopmentRateValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborGroupReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_Nir_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Nir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_Stage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OkrLaborVolumeReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborID = table.Column<int>(type: "int", nullable: false),
                    OkrID = table.Column<int>(type: "int", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrLaborVolumeReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_Labor_LaborID",
                        column: x => x.LaborID,
                        principalSchema: "Dictionary",
                        principalTable: "Labor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_Okr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Okr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrLaborVolumeReg_Stage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OkrSoftwareDevLaborGroupReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchitectureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    ArchitectureComplexityRateValue = table.Column<double>(type: "float", nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    InfrastructureComplexityRateValue = table.Column<double>(type: "float", nullable: false),
                    OkrID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    SolutionInnovationRateID = table.Column<int>(type: "int", nullable: false),
                    SolutionInnovationRateValue = table.Column<double>(type: "float", nullable: false),
                    StageID = table.Column<int>(type: "int", nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(type: "int", nullable: false),
                    StandardModulesUsingRateValue = table.Column<double>(type: "float", nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(type: "int", nullable: false),
                    TestsDevelopmentRateValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrSoftwareDevLaborGroupReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_Okr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Okr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_Stage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "Stage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborVolume_NirID_StageID_SoftwareDevLaborGroupID_LaborVolumeRangeID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                columns: new[] { "NirID", "StageID", "SoftwareDevLaborGroupID", "LaborVolumeRangeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborGroupReg_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborGroupReg_StageID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_NirSoftwareDevLaborGroupReg_NirID_StageID_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborGroupReg",
                columns: new[] { "NirID", "StageID", "SoftwareDevLaborGroupID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_LaborID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "LaborID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_StageID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrLaborVolumeReg_OkrID_StageID_LaborID",
                schema: "Registers",
                table: "OkrLaborVolumeReg",
                columns: new[] { "OkrID", "StageID", "LaborID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OkrSoftwareDevLaborGroupReg_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrSoftwareDevLaborGroupReg_StageID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                column: "StageID");

            migrationBuilder.CreateIndex(
                name: "IX_OkrSoftwareDevLaborGroupReg_OkrID_StageID_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "OkrSoftwareDevLaborGroupReg",
                columns: new[] { "OkrID", "StageID", "SoftwareDevLaborGroupID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_Nir_NirID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "NirID",
                principalSchema: "Dictionary",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NirSoftwareDevLaborVolume_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "NirSoftwareDevLaborVolume",
                column: "SoftwareDevLaborGroupID",
                principalSchema: "Dictionary",
                principalTable: "SoftwareDevLaborGroup",
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
        }
    }
}
