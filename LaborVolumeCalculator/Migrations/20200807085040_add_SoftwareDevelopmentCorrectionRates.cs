using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_SoftwareDevelopmentCorrectionRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestsScales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsScales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComponentsInteractionArchitecture",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentsInteractionArchitecture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComponentsMakroArchitecture",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentsMakroArchitecture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComponentsMicroArchitecture",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentsMicroArchitecture", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureComplexityRate",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureComplexityRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SolutionInnovationRate",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionInnovationRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StandardModulesUsingRate",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardModulesUsingRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TestsCoverageLevel",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsCoverageLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArchitectureComplexityRate",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentsMakroArchitectureID = table.Column<int>(nullable: false),
                    ComponentsInteractionArchitectureID = table.Column<int>(nullable: false),
                    Value = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchitectureComplexityRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArchitectureComplexityRate_ComponentsInteractionArchitecture_ComponentsInteractionArchitectureID",
                        column: x => x.ComponentsInteractionArchitectureID,
                        principalSchema: "Dictionary",
                        principalTable: "ComponentsInteractionArchitecture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchitectureComplexityRate_ComponentsMakroArchitecture_ComponentsMakroArchitectureID",
                        column: x => x.ComponentsMakroArchitectureID,
                        principalSchema: "Dictionary",
                        principalTable: "ComponentsMakroArchitecture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestsDevelopmentRate",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(nullable: false),
                    ComponentsMicroArchitectureID = table.Column<int>(nullable: false),
                    TestsScaleID = table.Column<int>(nullable: false),
                    TestsCoverageLevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsDevelopmentRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TestsDevelopmentRate_ComponentsMicroArchitecture_ComponentsMicroArchitectureID",
                        column: x => x.ComponentsMicroArchitectureID,
                        principalSchema: "Dictionary",
                        principalTable: "ComponentsMicroArchitecture",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestsDevelopmentRate_TestsCoverageLevel_TestsCoverageLevelID",
                        column: x => x.TestsCoverageLevelID,
                        principalSchema: "Dictionary",
                        principalTable: "TestsCoverageLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestsDevelopmentRate_TestsScales_TestsScaleID",
                        column: x => x.TestsScaleID,
                        principalTable: "TestsScales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsInteractionArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                column: "ComponentsInteractionArchitectureID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchitectureComplexityRate_ComponentsMakroArchitectureID",
                schema: "Dictionary",
                table: "ArchitectureComplexityRate",
                column: "ComponentsMakroArchitectureID");

            migrationBuilder.CreateIndex(
                name: "IX_TestsDevelopmentRate_ComponentsMicroArchitectureID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "ComponentsMicroArchitectureID");

            migrationBuilder.CreateIndex(
                name: "IX_TestsDevelopmentRate_TestsCoverageLevelID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "TestsCoverageLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_TestsDevelopmentRate_TestsScaleID",
                schema: "Dictionary",
                table: "TestsDevelopmentRate",
                column: "TestsScaleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchitectureComplexityRate",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "InfrastructureComplexityRate",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "SolutionInnovationRate",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "StandardModulesUsingRate",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "TestsDevelopmentRate",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "ComponentsInteractionArchitecture",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "ComponentsMakroArchitecture",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "ComponentsMicroArchitecture",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "TestsCoverageLevel",
                schema: "Dictionary");

            migrationBuilder.DropTable(
                name: "TestsScales");
        }
    }
}
