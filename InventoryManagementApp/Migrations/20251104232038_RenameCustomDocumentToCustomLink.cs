using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameCustomDocumentToCustomLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomDocument3Value",
                table: "InventoryItems",
                newName: "CustomLink3Value");

            migrationBuilder.RenameColumn(
                name: "CustomDocument2Value",
                table: "InventoryItems",
                newName: "CustomLink2Value");

            migrationBuilder.RenameColumn(
                name: "CustomDocument1Value",
                table: "InventoryItems",
                newName: "CustomLink1Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomLink3Value",
                table: "InventoryItems",
                newName: "CustomDocument3Value");

            migrationBuilder.RenameColumn(
                name: "CustomLink2Value",
                table: "InventoryItems",
                newName: "CustomDocument2Value");

            migrationBuilder.RenameColumn(
                name: "CustomLink1Value",
                table: "InventoryItems",
                newName: "CustomDocument1Value");
        }
    }
}
