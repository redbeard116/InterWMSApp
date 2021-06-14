using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InterWMSApp.Migrations
{
    public partial class SecondFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_products_productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operationproducts",
                schema: "public",
                table: "operationproducts");

            migrationBuilder.DropIndex(
                name: "IX_contracts_productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "public",
                table: "operationproducts");

            migrationBuilder.DropColumn(
                name: "productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                schema: "public",
                table: "contracts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operationproducts",
                schema: "public",
                table: "operationproducts",
                columns: new[] { "count", "productid" });

            migrationBuilder.AddForeignKey(
                name: "FK_operationproducts_contracts_count",
                schema: "public",
                table: "operationproducts",
                column: "count",
                principalSchema: "public",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operationproducts_contracts_count",
                schema: "public",
                table: "operationproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operationproducts",
                schema: "public",
                table: "operationproducts");

            migrationBuilder.AddColumn<int>(
                name: "id",
                schema: "public",
                table: "operationproducts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "type",
                schema: "public",
                table: "contracts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "productid",
                schema: "public",
                table: "contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_operationproducts",
                schema: "public",
                table: "operationproducts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_productid",
                schema: "public",
                table: "contracts",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_products_productid",
                schema: "public",
                table: "contracts",
                column: "productid",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
