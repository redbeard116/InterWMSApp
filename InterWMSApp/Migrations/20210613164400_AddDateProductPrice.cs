using Microsoft.EntityFrameworkCore.Migrations;

namespace InterWMSApp.Migrations
{
    public partial class AddDateProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "date",
                schema: "public",
                table: "prices",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                schema: "public",
                table: "prices");
        }
    }
}
