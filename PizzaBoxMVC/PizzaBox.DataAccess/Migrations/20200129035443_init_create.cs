using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.DataAccess.Migrations
{
    public partial class init_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PizzaBox");

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "PizzaBox",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(name: "Store Name", nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zipcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserOrder",
                schema: "PizzaBox",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreID = table.Column<int>(name: "Store ID", nullable: false),
                    UserID = table.Column<int>(name: "User ID", nullable: false),
                    OrderContent = table.Column<string>(name: "Order Content", nullable: false),
                    TotalCost = table.Column<decimal>(name: "Total Cost", nullable: false),
                    OrderDateTime = table.Column<DateTime>(name: "Order Date/Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrder", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Store",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "User",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "UserOrder",
                schema: "PizzaBox");
        }
    }
}
