using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_SoftwareDevLaborGroupReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsDevelopmentRate_TestsScales_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestsScales",
                table: "TestsScales");

            migrationBuilder.RenameTable(
                name: "TestsScales",
                newName: "TestsScale",
                newSchema: "Dictionary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestsScale",
                schema: "Dictionary",
                table: "TestsScale",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "SoftwareDevLaborGroupReg",
                schema: "Registers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NiokrID = table.Column<int>(nullable: false),
                    NiokrStageID = table.Column<int>(nullable: false),
                    SoftwareDevLaborGroupID = table.Column<int>(nullable: false),
                    SolutionInnovationRateID = table.Column<int>(nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(nullable: false),
                    ArchitectureComplexityRateID = table.Column<int>(nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_TestsDevelopmentRate_TestsScale_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "TestsScaleID",
                principalSchema: "Dictionary",
                principalTable: "TestsScale",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsDevelopmentRate_TestsScale_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate");

            migrationBuilder.DropTable(
                name: "SoftwareDevLaborGroupReg",
                schema: "Registers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestsScale",
                schema: "Dictionary",
                table: "TestsScale");

            migrationBuilder.RenameTable(
                name: "TestsScale",
                schema: "Dictionary",
                newName: "TestsScales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestsScales",
                table: "TestsScales",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsDevelopmentRate_TestsScales_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "TestsScaleID",
                principalTable: "TestsScales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
