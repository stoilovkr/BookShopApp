using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Identity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "1234", "kstoilov" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 2, "1235", "gbajatovski" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Identity",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 3, "1236", "akulakov" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identity",
                schema: "dbo");
        }
    }
}
