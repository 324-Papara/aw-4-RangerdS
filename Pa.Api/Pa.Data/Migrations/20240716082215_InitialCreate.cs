using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Factories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<long>(type: "bigint", nullable: false),
                    FactoryProfile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryHistory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryMission = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryVision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryValues = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryQualityPolicy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FactoryCertificates = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryDetails_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalSchema: "dbo",
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryLocations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<long>(type: "bigint", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    District = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalSchema: "dbo",
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryPhones",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: false),
                    UpdateUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryPhones_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalSchema: "dbo",
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factories_Email",
                schema: "dbo",
                table: "Factories",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factories_TaxNumber",
                schema: "dbo",
                table: "Factories",
                column: "TaxNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryDetails_FactoryId",
                schema: "dbo",
                table: "FactoryDetails",
                column: "FactoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_FactoryId",
                schema: "dbo",
                table: "FactoryLocations",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryPhones_CountryCode_PhoneNumber",
                schema: "dbo",
                table: "FactoryPhones",
                columns: new[] { "CountryCode", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryPhones_FactoryId",
                schema: "dbo",
                table: "FactoryPhones",
                column: "FactoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoryDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FactoryLocations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FactoryPhones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Factories",
                schema: "dbo");
        }
    }
}
