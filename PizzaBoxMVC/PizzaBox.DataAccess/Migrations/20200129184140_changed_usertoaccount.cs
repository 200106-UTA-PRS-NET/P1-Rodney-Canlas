using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.DataAccess.Migrations
{
    public partial class changed_usertoaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "PizzaBox");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "PizzaBox",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Passphrase = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(name: "First Name", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "PizzaBox");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "PizzaBox",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(max)", nullable: false),
                    Passphrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }
    }
}
