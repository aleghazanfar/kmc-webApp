using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KMCAA.Migrations
{
    public partial class AddLookUpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "Members",
                newName: "ContactTypeId");

            migrationBuilder.CreateTable(
                name: "LookUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookUpTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUps");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                table: "Members",
                newName: "ContactType");
        }
    }
}
