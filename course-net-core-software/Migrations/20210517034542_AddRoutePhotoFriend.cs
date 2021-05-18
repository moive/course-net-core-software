using Microsoft.EntityFrameworkCore.Migrations;

namespace course_net_core_software.Migrations
{
    public partial class AddRoutePhotoFriend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoutePhoto",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Email", "Name" },
                values: new object[] { 11, "mvelasquez@test.com", "Moises" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutePhoto",
                table: "Friends");

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Email", "Name" },
                values: new object[] { 10, "pmail@test.com", "Pepe" });
        }
    }
}
