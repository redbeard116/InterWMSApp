using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InterWMSApp.Migrations
{
    public partial class AddProductPriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                schema: "public",
                table: "operations");

            migrationBuilder.AddColumn<int>(
                name: "OperationProductId",
                schema: "public",
                table: "operations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "sum",
                schema: "public",
                table: "contracts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "operationproducts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operationproducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_operationproducts_products_productid",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(nullable: false),
                    cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.id);
                    table.ForeignKey(
                        name: "FK_prices_products_productid",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_operations_OperationProductId",
                schema: "public",
                table: "operations",
                column: "OperationProductId");

            migrationBuilder.CreateIndex(
                name: "IX_operationproducts_productid",
                schema: "public",
                table: "operationproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_prices_productid",
                schema: "public",
                table: "prices",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_operations_operationproducts_OperationProductId",
                schema: "public",
                table: "operations",
                column: "OperationProductId",
                principalSchema: "public",
                principalTable: "operationproducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operations_operationproducts_OperationProductId",
                schema: "public",
                table: "operations");

            migrationBuilder.DropTable(
                name: "operationproducts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "prices",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_operations_OperationProductId",
                schema: "public",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "OperationProductId",
                schema: "public",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "sum",
                schema: "public",
                table: "contracts");

            migrationBuilder.AddColumn<long>(
                name: "date",
                schema: "public",
                table: "operations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
