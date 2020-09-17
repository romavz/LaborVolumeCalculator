using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Refactor_SoftwareDevLaborGroupReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "NirSoftwareDevLaborGroupReg",
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
                    ArchitectureComplexityRateValue = table.Column<double>(nullable: false),
                    NirID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NirSoftwareDevLaborGroupReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_Niokr_NirID",
                        column: x => x.NirID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NirSoftwareDevLaborGroupReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OkrSoftwareDevLaborGroupReg",
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
                    ArchitectureComplexityRateValue = table.Column<double>(nullable: false),
                    OkrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrSoftwareDevLaborGroupReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_Niokr_OkrID",
                        column: x => x.OkrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OkrSoftwareDevLaborGroupReg_NiokrStage_StageID",
                        column: x => x.StageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NirSoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.DropTable(
                name: "OkrSoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.CreateTable(
                name: "SoftwareDevLaborGroupReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchitectureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(type: "int", nullable: false),
                    NiokrID = table.Column<int>(type: "int", nullable: false),
                    NiokrStageID = table.Column<int>(type: "int", nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(type: "int", nullable: false),
                    SolutionInnovationRateID = table.Column<int>(type: "int", nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(type: "int", nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareDevLaborGroupReg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_ArchitectureComplexityRate_ArchitectureComplexityRateID",
                        column: x => x.ArchitectureComplexityRateID,
                        principalSchema: "Dictionary",
                        principalTable: "ArchitectureComplexityRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_InfrastructureComplexityRate_InfrastructureComplexityRateID",
                        column: x => x.InfrastructureComplexityRateID,
                        principalSchema: "Dictionary",
                        principalTable: "InfrastructureComplexityRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_Niokr_NiokrID",
                        column: x => x.NiokrID,
                        principalSchema: "Dictionary",
                        principalTable: "Niokr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_NiokrStage_NiokrStageID",
                        column: x => x.NiokrStageID,
                        principalSchema: "Dictionary",
                        principalTable: "NiokrStage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_SoftwareDevLaborGroup_SoftwareDevLaborGroupID",
                        column: x => x.SoftwareDevLaborGroupID,
                        principalSchema: "Dictionary",
                        principalTable: "SoftwareDevLaborGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_SolutionInnovationRate_SolutionInnovationRateID",
                        column: x => x.SolutionInnovationRateID,
                        principalSchema: "Dictionary",
                        principalTable: "SolutionInnovationRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_StandardModulesUsingRate_StandardModulesUsingRateID",
                        column: x => x.StandardModulesUsingRateID,
                        principalSchema: "Dictionary",
                        principalTable: "StandardModulesUsingRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareDevLaborGroupReg_TestsDevelopmentRate_TestsDevelopmentRateID",
                        column: x => x.TestsDevelopmentRateID,
                        principalSchema: "Dictionary",
                        principalTable: "TestsDevelopmentRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_ArchitectureComplexityRateID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "ArchitectureComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_InfrastructureComplexityRateID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "InfrastructureComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_NiokrStageID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "NiokrStageID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "SoftwareDevLaborGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_SolutionInnovationRateID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "SolutionInnovationRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_StandardModulesUsingRateID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "StandardModulesUsingRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_TestsDevelopmentRateID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                column: "TestsDevelopmentRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareDevLaborGroupReg_NiokrID_NiokrStageID_SoftwareDevLaborGroupID",
                schema: "Registers",
                table: "SoftwareDevLaborGroupReg",
                columns: new[] { "NiokrID", "NiokrStageID", "SoftwareDevLaborGroupID" },
                unique: true);
        }
    }
}
