using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiCSharp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableV111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dnc_personal_dtl",
                table: "dnc_personal_dtl");

            migrationBuilder.RenameTable(
                name: "dnc_personal_dtl",
                newName: "dnc_product_dtl");

            migrationBuilder.RenameIndex(
                name: "IX_dnc_personal_dtl_mat_code",
                table: "dnc_product_dtl",
                newName: "IX_dnc_product_dtl_mat_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dnc_product_dtl",
                table: "dnc_product_dtl",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dnc_product_dtl",
                table: "dnc_product_dtl");

            migrationBuilder.RenameTable(
                name: "dnc_product_dtl",
                newName: "dnc_personal_dtl");

            migrationBuilder.RenameIndex(
                name: "IX_dnc_product_dtl_mat_code",
                table: "dnc_personal_dtl",
                newName: "IX_dnc_personal_dtl_mat_code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dnc_personal_dtl",
                table: "dnc_personal_dtl",
                column: "id");
        }
    }
}
