using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InterWMSApp.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "accesstypes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accesstypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producttypes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producttypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "storageareas",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storageareas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(nullable: false),
                    secondname = table.Column<string>(nullable: false),
                    role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rightsgrids",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    accetTypeid = table.Column<int>(nullable: false),
                    userRole = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rightsgrids", x => x.id);
                    table.ForeignKey(
                        name: "FK_rightsgrids_accesstypes_accetTypeid",
                        column: x => x.accetTypeid,
                        principalSchema: "public",
                        principalTable: "accesstypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    typeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_producttypes_typeid",
                        column: x => x.typeid,
                        principalSchema: "public",
                        principalTable: "producttypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auths",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(nullable: false),
                    login = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auths", x => x.id);
                    table.ForeignKey(
                        name: "FK_auths_users_userid",
                        column: x => x.userid,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "counterpartyes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(nullable: false),
                    account = table.Column<int>(nullable: false),
                    inn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counterpartyes", x => x.id);
                    table.ForeignKey(
                        name: "FK_counterpartyes_users_userid",
                        column: x => x.userid,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "productstorage",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(nullable: false),
                    storageareaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productstorage", x => x.id);
                    table.ForeignKey(
                        name: "FK_productstorage_products_productid",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productstorage_storageareas_storageareaid",
                        column: x => x.storageareaid,
                        principalSchema: "public",
                        principalTable: "storageareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    counterpartyid = table.Column<int>(nullable: false),
                    date = table.Column<long>(nullable: false),
                    sum = table.Column<double>(nullable: false),
                    productid = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contracts_counterpartyes_counterpartyid",
                        column: x => x.counterpartyid,
                        principalSchema: "public",
                        principalTable: "counterpartyes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contracts_products_productid",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auths_login",
                schema: "public",
                table: "auths",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_auths_userid",
                schema: "public",
                table: "auths",
                column: "userid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contracts_counterpartyid",
                schema: "public",
                table: "contracts",
                column: "counterpartyid");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_productid",
                schema: "public",
                table: "contracts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_counterpartyes_userid",
                schema: "public",
                table: "counterpartyes",
                column: "userid",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_products_typeid",
                schema: "public",
                table: "products",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_productstorage_productid",
                schema: "public",
                table: "productstorage",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_productstorage_storageareaid",
                schema: "public",
                table: "productstorage",
                column: "storageareaid");

            migrationBuilder.CreateIndex(
                name: "IX_rightsgrids_accetTypeid",
                schema: "public",
                table: "rightsgrids",
                column: "accetTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_rightsgrids_userRole",
                schema: "public",
                table: "rightsgrids",
                column: "userRole",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auths",
                schema: "public");

            migrationBuilder.DropTable(
                name: "contracts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "operationproducts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "prices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "productstorage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "rightsgrids",
                schema: "public");

            migrationBuilder.DropTable(
                name: "counterpartyes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "storageareas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "accesstypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "producttypes",
                schema: "public");
        }
    }
}
