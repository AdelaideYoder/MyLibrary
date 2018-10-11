using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Migrations
{
    public partial class addpatron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatronId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patron",
                columns: table => new
                {
                    PatronId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patron", x => x.PatronId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PatronId",
                table: "Book",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Patron_PatronId",
                table: "Book",
                column: "PatronId",
                principalTable: "Patron",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Patron_PatronId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Patron");

            migrationBuilder.DropIndex(
                name: "IX_Book_PatronId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Book");
        }
    }
}
