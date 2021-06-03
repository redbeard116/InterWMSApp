using Microsoft.EntityFrameworkCore.Migrations;

namespace InterWMSApp.Migrations
{
    public partial class AddStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "operations",
                newName: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productid",
                schema: "public",
                table: "operations",
                newName: "name");
        }
    }
}
