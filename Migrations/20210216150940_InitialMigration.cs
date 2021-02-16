using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBroidery.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivilege",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(nullable: false),
                    Privilege = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePrivilege_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Guest" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 15, null, "Guest" });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 2, "account_list", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 21, "product_list", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 20, "product_read", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 19, "own_account_delete", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 18, "own_account_update", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 17, "account_create", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 16, "own_account_read", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 27, "category_list", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 26, "category_delete", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 25, "category_update", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 24, "category_create", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 23, "category_read", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 12, "product_read", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 11, "own_account_delete", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 10, "own_account_update", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 9, "account_create", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 8, "own_account_read", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 7, "account_delete", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 6, "product_delete", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 5, "product_update", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 4, "product_create", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 3, "product_list", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 22, "category_read", 13 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 14, 13, 15 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilege_RoleId",
                table: "RolePrivilege",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RolePrivilege");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
