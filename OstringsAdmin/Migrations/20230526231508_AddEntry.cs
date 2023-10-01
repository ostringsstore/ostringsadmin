using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstringsAdmin.Migrations
{
    public partial class AddEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryEntry_Providers_ProviderId",
                table: "InventoryEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_InventoryEntry_InventoryEntryId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Products_ProductId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderPayment_InventoryEntry_InventoryEntryId",
                table: "ProviderPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryEntry",
                table: "InventoryEntry");

            migrationBuilder.RenameTable(
                name: "ProductProviders",
                newName: "InventoryItems");

            migrationBuilder.RenameTable(
                name: "InventoryEntry",
                newName: "InventoryEntries");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProviders_ProductId",
                table: "InventoryItems",
                newName: "IX_InventoryItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProviders_InventoryEntryId",
                table: "InventoryItems",
                newName: "IX_InventoryItems_InventoryEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryEntry_ProviderId",
                table: "InventoryEntries",
                newName: "IX_InventoryEntries_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryEntries",
                table: "InventoryEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryEntries_Providers_ProviderId",
                table: "InventoryEntries",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_InventoryEntries_InventoryEntryId",
                table: "InventoryItems",
                column: "InventoryEntryId",
                principalTable: "InventoryEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Products_ProductId",
                table: "InventoryItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderPayment_InventoryEntries_InventoryEntryId",
                table: "ProviderPayment",
                column: "InventoryEntryId",
                principalTable: "InventoryEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryEntries_Providers_ProviderId",
                table: "InventoryEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_InventoryEntries_InventoryEntryId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Products_ProductId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderPayment_InventoryEntries_InventoryEntryId",
                table: "ProviderPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryEntries",
                table: "InventoryEntries");

            migrationBuilder.RenameTable(
                name: "InventoryItems",
                newName: "ProductProviders");

            migrationBuilder.RenameTable(
                name: "InventoryEntries",
                newName: "InventoryEntry");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_ProductId",
                table: "ProductProviders",
                newName: "IX_ProductProviders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_InventoryEntryId",
                table: "ProductProviders",
                newName: "IX_ProductProviders_InventoryEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryEntries_ProviderId",
                table: "InventoryEntry",
                newName: "IX_InventoryEntry_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryEntry",
                table: "InventoryEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryEntry_Providers_ProviderId",
                table: "InventoryEntry",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_InventoryEntry_InventoryEntryId",
                table: "ProductProviders",
                column: "InventoryEntryId",
                principalTable: "InventoryEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Products_ProductId",
                table: "ProductProviders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderPayment_InventoryEntry_InventoryEntryId",
                table: "ProviderPayment",
                column: "InventoryEntryId",
                principalTable: "InventoryEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
