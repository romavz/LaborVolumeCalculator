using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborVolumeCalculator.Migrations
{
    public partial class add_LaborGroupRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaborGroupRelation",
                schema: "Dictionary",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaborGroupId = table.Column<int>(nullable: false),
                    ParentGroupId = table.Column<int>(nullable: true)
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

            migrationBuilder.Sql(@"
                CREATE TRIGGER Dictionary.LaborGroup_INSERT
                   ON  Dictionary.LaborGroup
                   AFTER INSERT
                AS 
                BEGIN
	                SET NOCOUNT ON;

                    INSERT INTO Dictionary.LaborGroupRelation(LaborGroupId, ParentGroupId)
		                SELECT LaborGroup.ID, parents.ParentGroupId
		                FROM INSERTED as LaborGroup
		                INNER JOIN Dictionary.LaborGroupRelation AS parents
		                ON parents.LaborGroupId = LaborGroup.ParentGroupId
		
		                UNION
		
		                SELECT LaborGroup.ID, LaborGroup.ParentGroupId
		                FROM INSERTED as LaborGroup
                END
                GO
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaborGroupRelation",
                schema: "Dictionary");
        }
    }
}
