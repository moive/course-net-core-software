using Microsoft.EntityFrameworkCore.Migrations;

namespace course_net_core_software.Migrations
{
    public partial class SeeFriendsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "City", "Email", "Name" },
                values: new object[] { 1, 10, "pmail@test.com", "Pepe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
