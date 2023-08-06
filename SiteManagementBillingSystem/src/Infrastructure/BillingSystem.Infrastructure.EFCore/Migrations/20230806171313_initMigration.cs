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

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2023, 8, 6, 17, 13, 13, 241, DateTimeKind.Utc).AddTicks(8098)),
                    PaymentType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    InvoiceId = table.Column<int>(type: "integer", nullable: true),
                    DuesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Amount = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    DuesPaymentStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Dues_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "dbo",
                        principalTable: "Payment",
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
                    Amount = table.Column<decimal>(type: "numeric", maxLength: 50, nullable: false),
                    InvoiceType = table.Column<int>(type: "integer", nullable: false),
                    InvoicePaymentStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Invoice_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "dbo",
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Apartment",
                columns: new[] { "Id", "Block", "CreatedDate", "Floor", "Number", "Resident", "Status", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6786), 1, 1, 1, 1, "2+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6788) },
                    { 2, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6790), 1, 2, 2, 1, "2+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6791) },
                    { 3, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6792), 2, 3, 1, 0, "3+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6793) },
                    { 4, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6794), 2, 4, 1, 0, "3+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6795) },
                    { 5, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6796), 3, 5, 1, 0, "3+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6796) },
                    { 6, "A", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6798), 3, 6, 1, 0, "3+1", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6798) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Dues",
                columns: new[] { "Id", "Amount", "ApartmentId", "CreatedDate", "Month", "PaymentId", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, 200m, 1, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6992), "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6992), 2023 },
                    { 2, 200m, 2, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6994), "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6995), 2023 },
                    { 3, 200m, 3, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6996), "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6996), 2023 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Invoice",
                columns: new[] { "Id", "Amount", "ApartmentId", "CreatedDate", "InvoiceType", "Month", "PaymentId", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, 200m, 1, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7015), 1, "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7015), 2023 },
                    { 2, 200m, 2, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7017), 2, "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7018), 2023 },
                    { 3, 200m, 3, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7019), 3, "July", null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(7020), 2023 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "ApartmentId", "CarPlateNumber", "CreatedDate", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "TCKNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6966), "admin@gmail.com", "Admin", "Admin", "admin", "0567 456 43 43", "Admin", "11111111111", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6966) },
                    { 2, 2, null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6969), "nisa@gmail.com", "Nisa", "Turhan", "123456", "0567 456 43 43", "User", "22222222222", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6969) },
                    { 3, 1, null, new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6971), "doga@gmail.com", "Doğa", "Turhan", "123456", "0567 456 43 43", "User", "33333333333", new DateTime(2023, 8, 6, 17, 13, 13, 242, DateTimeKind.Utc).AddTicks(6972) }
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
                name: "IX_Dues_PaymentId",
                schema: "dbo",
                table: "Dues",
                column: "PaymentId",
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
                name: "IX_Invoice_PaymentId",
                schema: "dbo",
                table: "Invoice",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Id",
                schema: "dbo",
                table: "Payment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserId",
                schema: "dbo",
                table: "Payment",
                column: "UserId");

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
                name: "Payment",
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
