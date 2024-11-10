using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace swc_lab3.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Books",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Books",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
