using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InterWMSApp.Migrations
{
    public partial class UnionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_operations_operationid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropTable(
                name: "operations",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_counterpartyes_userid",
                schema: "public",
                table: "counterpartyes");

            migrationBuilder.DropIndex(
                name: "IX_contracts_operationid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "IX_auths_userid",
                schema: "public",
                table: "auths");

            migrationBuilder.DropColumn(
                name: "operationid",
                schema: "public",
                table: "contracts");

            migrationBuilder.AddColumn<int>(
                name: "count",
                schema: "public",
                table: "contracts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productid",
                schema: "public",
                table: "contracts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "type",
                schema: "public",
                table: "contracts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_counterpartyes_userid",
                schema: "public",
                table: "counterpartyes",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contracts_productid",
                schema: "public",
                table: "contracts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_auths_userid",
                schema: "public",
                table: "auths",
                column: "userid",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contracts_products_productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "IX_counterpartyes_userid",
                schema: "public",
                table: "counterpartyes");

            migrationBuilder.DropIndex(
                name: "IX_contracts_productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "IX_auths_userid",
                schema: "public",
                table: "auths");

            migrationBuilder.DropColumn(
                name: "count",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "productid",
                schema: "public",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "type",
                schema: "public",
                table: "contracts");

            migrationBuilder.AddColumn<int>(
                name: "operationid",
                schema: "public",
                table: "contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "operations",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    count = table.Column<int>(type: "integer", nullable: false),
                    OperationProductId = table.Column<int>(type: "integer", nullable: true),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.id);
                    table.ForeignKey(
                        name: "FK_operations_operationproducts_OperationProductId",
                        column: x => x.OperationProductId,
                        principalSchema: "public",
                        principalTable: "operationproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_operations_products_productid",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_counterpartyes_userid",
                schema: "public",
                table: "counterpartyes",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_operationid",
                schema: "public",
                table: "contracts",
                column: "operationid");

            migrationBuilder.CreateIndex(
                name: "IX_auths_userid",
                schema: "public",
                table: "auths",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_operations_OperationProductId",
                schema: "public",
                table: "operations",
                column: "OperationProductId");

            migrationBuilder.CreateIndex(
                name: "IX_operations_productid",
                schema: "public",
                table: "operations",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_contracts_operations_operationid",
                schema: "public",
                table: "contracts",
                column: "operationid",
                principalSchema: "public",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
