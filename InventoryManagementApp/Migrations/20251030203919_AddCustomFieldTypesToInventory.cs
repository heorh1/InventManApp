using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomFieldTypesToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomDocument1Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomDocument2Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomDocument3Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline1Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline2Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline3Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool1Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool2Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool3Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt1Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt2Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt3Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink1Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomLink1State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink1Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink2Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomLink2State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink2Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink3Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomLink3State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomLink3Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline1Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomMultiline1State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline1Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline2Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomMultiline2State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline2Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline3Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomMultiline3State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultiline3Title",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString1Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString2Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString3Description",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomDocument1Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomDocument2Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomDocument3Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomMultiline1Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomMultiline2Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomMultiline3Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomBool1Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool2Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool3Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt1Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt2Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt3Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink1Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink1State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink1Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink2Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink2State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink2Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink3Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink3State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomLink3Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline1Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline1State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline1Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline2Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline2State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline2Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline3Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline3State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomMultiline3Title",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString1Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString2Description",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString3Description",
                table: "Inventories");
        }
    }
}
