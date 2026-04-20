using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WpfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class Citizen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Photo" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", new byte[0] },
                    { 2, new DateTime(1985, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", new byte[0] },
                    { 3, new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Brown", new byte[0] }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizens");
        }
    }
}
