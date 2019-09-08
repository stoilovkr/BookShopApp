using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 1, "Leo Tolstoy" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 2, "William Shakespeare" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Author",
                columns: new[] { "Id", "FullName" },
                values: new object[] { 3, "Mark Twain" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Genre", "Price", "Synopsis", "Title" },
                values: new object[,]
                {
                    { 1, 1, 0, 200.0, "The novel chronicles the French invasion of Russia and the impact of the Napoleonic era...", "War and peace" },
                    { 4, 1, 0, 200.0, "It deals with themes of betrayal, faith, family, marriage, Imperial Russian society, desire, and rural vs. city life....", "Ana Karenina" },
                    { 2, 2, 4, 300.0, "In Romeo and Juliet, Shakespeare creates a violent world, in which two young people fall in love...", "Romeo and Juliet" },
                    { 5, 2, 1, 300.0, "Set in Denmark, the play depicts Prince Hamlet and his revenge against his uncle, Claudius, who has murdered Hamlet's father in order to seize his throne and marry Hamlet's mother....", "Hamlet" },
                    { 3, 3, 6, 400.0, "A nineteenth-century boy from a Mississippi River town recounts his adventures...", "The Adventures of Huckleberry Finn" },
                    { 6, 3, 0, 400.0, " It is set in the 1840s in the fictional town of St. Petersburg, inspired by Hannibal, Missouri, where Twain lived as a boy....", "The Adventures of Tom Sawyer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "dbo",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "dbo");
        }
    }
}
