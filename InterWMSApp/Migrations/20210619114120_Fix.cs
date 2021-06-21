using Microsoft.EntityFrameworkCore.Migrations;

namespace InterWMSApp.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_products_storageid",
                schema: "public",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_storageid",
                schema: "public",
                table: "products",
                column: "storageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_products_storageid",
                schema: "public",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_storageid",
                schema: "public",
                table: "products",
                column: "storageid",
                unique: true);
        }
    }
}
