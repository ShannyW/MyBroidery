using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBroidery.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePrivilege",
                columns: new[] { "Id", "Privilege", "RoleId" },
                values: new object[] { 21, "product_list", 13 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivilege",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
