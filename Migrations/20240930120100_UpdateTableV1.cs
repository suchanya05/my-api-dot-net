using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyApiCSharp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dnc_personal",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    mobile_no = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    address_desc = table.Column<string>(type: "text", nullable: true),
                    point = table.Column<int>(type: "integer", nullable: false),
                    coin = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    exp = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dnc_personal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dnc_personal_dtl",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    serial_number = table.Column<string>(type: "text", nullable: false),
                    mat_code = table.Column<string>(type: "text", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dnc_personal_dtl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dnc_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    matirial_code = table.Column<string>(type: "text", nullable: true),
                    qty = table.Column<int>(type: "integer", nullable: false),
                    product_type = table.Column<string>(type: "text", nullable: true),
                    Product_sub_type = table.Column<string>(type: "text", nullable: true),
                    product_color = table.Column<string>(type: "text", nullable: true),
                    serial_type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dnc_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dnc_role_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dnc_role_list", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dnc_personal_username",
                table: "dnc_personal",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dnc_personal_dtl_mat_code",
                table: "dnc_personal_dtl",
                column: "mat_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dnc_product_matirial_code",
                table: "dnc_product",
                column: "matirial_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dnc_role_list_role_name",
                table: "dnc_role_list",
                column: "role_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dnc_personal");

            migrationBuilder.DropTable(
                name: "dnc_personal_dtl");

            migrationBuilder.DropTable(
                name: "dnc_product");

            migrationBuilder.DropTable(
                name: "dnc_role_list");
        }
    }
}
