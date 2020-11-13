using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class Add_CorrectionRatesBundle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrectionRatesBundle",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    SolutionInnovationRateID = table.Column<int>(nullable: false),
                    SolutionInnovationRateValue = table.Column<double>(nullable: false),
                    StandardModulesUsingRateID = table.Column<int>(nullable: false),
                    StandardModulesUsingRateValue = table.Column<double>(nullable: false),
                    InfrastructureComplexityRateID = table.Column<int>(nullable: false),
                    InfrastructureComplexityRateValue = table.Column<double>(nullable: false),
                    ArchitectureComplexityRateID = table.Column<int>(nullable: false),
                    ArchitectureComplexityRateValue = table.Column<double>(nullable: false),
                    TestsDevelopmentRateID = table.Column<int>(nullable: false),
                    TestsDevelopmentRateValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectionRatesBundle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CorrectionRatesBundle_ArchitectureComplexityRate_ArchitectureComplexityRateID",
                        column: x => x.ArchitectureComplexityRateID,
                        principalSchema: "Dictionary",
                        principalTable: "ArchitectureComplexityRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectionRatesBundle_InfrastructureComplexityRate_InfrastructureComplexityRateID",
                        column: x => x.InfrastructureComplexityRateID,
                        principalSchema: "Dictionary",
                        principalTable: "InfrastructureComplexityRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectionRatesBundle_SolutionInnovationRate_SolutionInnovationRateID",
                        column: x => x.SolutionInnovationRateID,
                        principalSchema: "Dictionary",
                        principalTable: "SolutionInnovationRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectionRatesBundle_StandardModulesUsingRate_StandardModulesUsingRateID",
                        column: x => x.StandardModulesUsingRateID,
                        principalSchema: "Dictionary",
                        principalTable: "StandardModulesUsingRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionRatesBundle_ArchitectureComplexityRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "ArchitectureComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionRatesBundle_InfrastructureComplexityRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "InfrastructureComplexityRateID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionRatesBundle_SolutionInnovationRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "SolutionInnovationRateID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectionRatesBundle_StandardModulesUsingRateID",
                schema: "Dictionary",
                table: "CorrectionRatesBundle",
                column: "StandardModulesUsingRateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectionRatesBundle",
                schema: "Dictionary");
        }
    }
}
