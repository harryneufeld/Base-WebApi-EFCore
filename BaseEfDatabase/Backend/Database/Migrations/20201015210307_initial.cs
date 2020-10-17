using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    IsMainAddress = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserGroupId = table.Column<Guid>(nullable: false),
                    UserGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.UserGroupId);
                });

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    UserRightId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    Allow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.UserRightId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    MailAddress = table.Column<string>(nullable: true),
                    PhoneNumberPrefix = table.Column<int>(nullable: false),
                    PhoneNumberSuffix = table.Column<int>(nullable: false),
                    MobilePhonePrefix = table.Column<int>(nullable: false),
                    MobilePhoneSuffix = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Mandators",
                columns: table => new
                {
                    MandatorId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    EditDate = table.Column<DateTime>(nullable: true),
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
                name: "GroupRights",
                columns: table => new
                {
                    GroupRightId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FieldId = table.Column<int>(nullable: false),
                    Allow = table.Column<bool>(nullable: false),
                    UserGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRights", x => x.GroupRightId);
                    table.ForeignKey(
                        name: "FK_GroupRights_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "UserGroupId",
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
                name: "IX_BusinessItems_AddressId",
                table: "BusinessItems",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessItems_MandatorId",
                table: "BusinessItems",
                column: "MandatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRights_UserGroupId",
                table: "GroupRights",
                column: "UserGroupId");

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
                name: "GroupRights");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "UserRights");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "BusinessItems");

            migrationBuilder.DropTable(
                name: "Mandators");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
