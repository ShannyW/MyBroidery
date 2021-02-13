using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBroidery.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { 12, "product_read", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 11, "own_account_delete", 1 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 20, "product_read", 13 });

            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 10, "own_account_update", 1 });

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
                values: new object[] { 9, "account_create", 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 14, 13, 15 });

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilege_RoleId",
                table: "RolePrivilege",
                column: "RoleId");

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
                name: "RolePrivilege");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
