using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    PostalCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.PostalCode);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_PostalCode",
                        column: x => x.PostalCode,
                        principalTable: "Cities",
                        principalColumn: "PostalCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mandators",
                columns: table => new
                {
                    MandatorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandators", x => x.MandatorId);
                    table.ForeignKey(
                        name: "FK_Mandators_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessItems",
                columns: table => new
                {
                    BusinessItemId = table.Column<Guid>(nullable: false),
                    MandatorId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessItems", x => x.BusinessItemId);
                    table.ForeignKey(
                        name: "FK_BusinessItems_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessItems_Mandators_MandatorId",
                        column: x => x.MandatorId,
                        principalTable: "Mandators",
                        principalColumn: "MandatorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    BusinessItemId = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_BusinessItems_BusinessItemId",
                        column: x => x.BusinessItemId,
                        principalTable: "BusinessItems",
                        principalColumn: "BusinessItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PostalCode",
                table: "Addresses",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessItems_AddressId",
                table: "BusinessItems",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessItems_MandatorId",
                table: "BusinessItems",
                column: "MandatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mandators_AddressId",
                table: "Mandators",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BusinessItemId",
                table: "Persons",
                column: "BusinessItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "BusinessItems");

            migrationBuilder.DropTable(
                name: "Mandators");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
