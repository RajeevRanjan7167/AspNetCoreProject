using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ct_Name = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    com_Name = table.Column<string>(nullable: true),
                    com_Ext_Name = table.Column<string>(nullable: true),
                    groupId = table.Column<int>(nullable: false),
                    rolesId = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fi_Name = table.Column<string>(nullable: true),
                    fi_Amount = table.Column<decimal>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    group_Name = table.Column<string>(nullable: true),
                    rolesId = table.Column<int>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rm_First_Name = table.Column<string>(nullable: true),
                    rm_Middle_Name = table.Column<string>(nullable: true),
                    rm_Last_Name = table.Column<string>(nullable: true),
                    rm_Login_Id = table.Column<string>(nullable: true),
                    rm_Email = table.Column<string>(nullable: true),
                    rm_Role_Id = table.Column<int>(nullable: false),
                    rm_Gender = table.Column<string>(nullable: true),
                    rm_DateOfBirth = table.Column<DateTime>(nullable: false),
                    rm_address = table.Column<string>(nullable: true),
                    rm_Contactno = table.Column<string>(nullable: true),
                    rm_City = table.Column<string>(nullable: true),
                    rm_Country = table.Column<string>(nullable: true),
                    rm_Postalcode = table.Column<string>(nullable: true),
                    rm_Active = table.Column<byte>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    rm_KnownAS = table.Column<string>(nullable: true),
                    rm_LastActive = table.Column<DateTime>(nullable: false),
                    rm_Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_Name = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    modified_by = table.Column<string>(nullable: true),
                    modified_on = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    dateAdded = table.Column<DateTime>(nullable: false),
                    ismain = table.Column<bool>(nullable: false),
                    ResourcesMSTID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Photos_Resources_ResourcesMSTID",
                        column: x => x.ResourcesMSTID,
                        principalTable: "Resources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ResourcesMSTID",
                table: "Photos",
                column: "ResourcesMSTID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
