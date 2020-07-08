using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_LaborGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dictionary");

            migrationBuilder.CreateTable(
                name: "LaborGroup",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentGroupId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaborGroup",
                schema: "Dictionary");
        }
    }
}
