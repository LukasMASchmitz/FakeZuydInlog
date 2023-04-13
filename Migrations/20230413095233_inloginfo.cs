using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeZuydInlog.Migrations
{
    /// <inheritdoc />
    public partial class inloginfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inlog",
                columns: table => new
                {
                    Gebruikersnaam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inlog", x => x.Gebruikersnaam);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inlog");
        }
    }
}
