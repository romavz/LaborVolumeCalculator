using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_NirScale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirInnovationRate_Nir_NirID",
                table: "NirInnovationRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate");

            migrationBuilder.DropColumn(
                name: "NirID",
                table: "NirInnovationRate");

            migrationBuilder.AddColumn<int>(
                name: "NirScaleID",
                table: "NirInnovationRate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate",
                columns: new[] { "NirScaleID", "NirInnovationPropertyID" });

            migrationBuilder.CreateTable(
                name: "NirScale",
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
                    table.PrimaryKey("PK_NirScale", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NirInnovationRate_NirScale_NirScaleID",
                table: "NirInnovationRate",
                column: "NirScaleID",
                principalTable: "NirScale",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NirInnovationRate_NirScale_NirScaleID",
                table: "NirInnovationRate");

            migrationBuilder.DropTable(
                name: "NirScale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate");

            migrationBuilder.DropColumn(
                name: "NirScaleID",
                table: "NirInnovationRate");

            migrationBuilder.AddColumn<int>(
                name: "NirID",
                table: "NirInnovationRate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NirInnovationRate",
                table: "NirInnovationRate",
                columns: new[] { "NirID", "NirInnovationPropertyID" });

            migrationBuilder.AddForeignKey(
                name: "FK_NirInnovationRate_Nir_NirID",
                table: "NirInnovationRate",
                column: "NirID",
                principalTable: "Nir",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
