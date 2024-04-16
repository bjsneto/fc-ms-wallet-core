using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Balance.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountFromId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountToId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "ClientId", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("1232b62f-5b34-4b8a-9f7a-1a349390a353"), 10, new Guid("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"), new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(6166) },
                    { new Guid("d95f9fc4-3cf4-49e9-afd9-007da4653f4a"), 100000, new Guid("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"), new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(6158) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedAt", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"), new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(5830), "belarmino@mail.com", "Belarmino" },
                    { new Guid("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"), new DateTime(2024, 4, 10, 22, 19, 38, 146, DateTimeKind.Utc).AddTicks(5851), "neto@mail.com", "Neto" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
