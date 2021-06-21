using Microsoft.EntityFrameworkCore.Migrations;

namespace InterWMSApp.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "middlename",
                schema: "public",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "number",
                schema: "public",
                table: "users",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "middlename",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "number",
                schema: "public",
                table: "users");
        }
    }
}
