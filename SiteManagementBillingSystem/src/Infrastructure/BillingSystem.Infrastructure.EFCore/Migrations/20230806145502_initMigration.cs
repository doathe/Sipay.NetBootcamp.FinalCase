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
                name: "Dues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Month = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Amounth = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    DuesPaymentStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dues_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Month = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Amounth = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    InvoiceType = table.Column<int>(type: "integer", nullable: false),
                    InvoicePaymentStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(128), 1, 1, 1, 1, "2+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(131) },
                    { 2, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(134), 1, 2, 2, 1, "2+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(134) },
                    { 3, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(136), 2, 3, 1, 0, "3+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(137) },
                    { 4, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(138), 2, 4, 1, 0, "3+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(139) },
                    { 5, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(140), 3, 5, 1, 0, "3+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(141) },
                    { 6, "A", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(143), 3, 6, 1, 0, "3+1", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(143) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Dues",
                columns: new[] { "Id", "Amounth", "ApartmentId", "CreatedDate", "Month", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, 200m, 1, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(491), "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(491), 2023 },
                    { 2, 200m, 2, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(494), "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(494), 2023 },
                    { 3, 200m, 3, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(496), "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(496), 2023 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Invoice",
                columns: new[] { "Id", "Amounth", "ApartmentId", "CreatedDate", "InvoiceType", "Month", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, 200m, 1, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(515), 1, "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(516), 2023 },
                    { 2, 200m, 2, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(518), 2, "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(519), 2023 },
                    { 3, 200m, 3, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(520), 3, "July", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(521), 2023 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "ApartmentId", "CarPlateNumber", "CreatedDate", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "TCKNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(336), "admin@gmail.com", "Admin", "Admin", "admin", "0567 456 43 43", "Admin", "11111111111", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(337) },
                    { 2, 2, null, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(340), "nisa@gmail.com", "Nisa", "Turhan", "123456", "0567 456 43 43", "User", "22222222222", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(340) },
                    { 3, 1, null, new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(460), "doga@gmail.com", "Doğa", "Turhan", "123456", "0567 456 43 43", "User", "33333333333", new DateTime(2023, 8, 6, 14, 55, 2, 346, DateTimeKind.Utc).AddTicks(461) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Id",
                schema: "dbo",
                table: "Apartment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dues_ApartmentId",
                schema: "dbo",
                table: "Dues",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dues_Id",
                schema: "dbo",
                table: "Dues",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ApartmentId",
                schema: "dbo",
                table: "Invoice",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Id",
                schema: "dbo",
                table: "Invoice",
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
                name: "Dues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "dbo");
        }
    }
}
