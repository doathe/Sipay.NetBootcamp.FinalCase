using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillingSystem.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Apartment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Block = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Number = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Resident = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TCKNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CarPlateNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Apartment",
                columns: new[] { "Id", "Block", "CreatedDate", "Floor", "Number", "Resident", "Status", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1, 1, "3+1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 2, 1, "2+1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "C", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, 1, 0, "3+1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "ApartmentId", "CarPlateNumber", "CreatedDate", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "TCKNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nisatur@gmail.com", "Nisa Doğa", "Turhan", "123456", "0567 456 43 43", "User", "11111111111", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nisa@gmail.com", "Nisa", "Turhan", "123456", "0567 456 43 43", "User", "22222222222", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doga@gmail.com", "Doğa", "Turhan", "123456", "0567 456 43 43", "User", "33333333333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Id",
                schema: "dbo",
                table: "Apartment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ApartmentId",
                schema: "dbo",
                table: "User",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "dbo",
                table: "User",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "dbo");
        }
    }
}
