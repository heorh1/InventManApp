using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomMultiline3Title",
                table: "Inventories",
                newName: "CustomMultiline3Name");

            migrationBuilder.RenameColumn(
                name: "CustomMultiline2Title",
                table: "Inventories",
                newName: "CustomMultiline2Name");

            migrationBuilder.RenameColumn(
                name: "CustomMultiline1Title",
                table: "Inventories",
                newName: "CustomMultiline1Name");

            migrationBuilder.RenameColumn(
                name: "CustomLink3Title",
                table: "Inventories",
                newName: "CustomLink3Name");

            migrationBuilder.RenameColumn(
                name: "CustomLink2Title",
                table: "Inventories",
                newName: "CustomLink2Name");

            migrationBuilder.RenameColumn(
                name: "CustomLink1Title",
                table: "Inventories",
                newName: "CustomLink1Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomMultiline3Name",
                table: "Inventories",
                newName: "CustomMultiline3Title");

            migrationBuilder.RenameColumn(
                name: "CustomMultiline2Name",
                table: "Inventories",
                newName: "CustomMultiline2Title");

            migrationBuilder.RenameColumn(
                name: "CustomMultiline1Name",
                table: "Inventories",
                newName: "CustomMultiline1Title");

            migrationBuilder.RenameColumn(
                name: "CustomLink3Name",
                table: "Inventories",
                newName: "CustomLink3Title");

            migrationBuilder.RenameColumn(
                name: "CustomLink2Name",
                table: "Inventories",
                newName: "CustomLink2Title");

            migrationBuilder.RenameColumn(
                name: "CustomLink1Name",
                table: "Inventories",
                newName: "CustomLink1Title");
        }
    }
}
