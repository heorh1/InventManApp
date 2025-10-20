using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class MainApplicationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Inventories",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InventoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool1Value",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool2Value",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool3Value",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt1Value",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt2Value",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt3Value",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString1Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString2Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString3Value",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool1Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool1State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool2Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool2State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool3Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool3State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt1Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomInt1State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt2Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomInt2State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt3Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomInt3State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomString1Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomString1State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomString2Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomString2State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomString3Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomString3State",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Inventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CreatedById",
                table: "InventoryItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryId",
                table: "InventoryItems",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_AspNetUsers_CreatedById",
                table: "InventoryItems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Inventories_InventoryId",
                table: "InventoryItems",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_AspNetUsers_CreatedById",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Inventories_InventoryId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CreatedById",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_InventoryId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomBool1Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomBool2Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomBool3Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomInt1Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomInt2Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomInt3Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomString1Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomString2Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomString3Value",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CustomBool1Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool1State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool2Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool2State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool3Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomBool3State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt1Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt1State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt2Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt2State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt3Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomInt3State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString1Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString1State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString2Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString2State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString3Name",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustomString3State",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Inventories",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "InventoryItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
