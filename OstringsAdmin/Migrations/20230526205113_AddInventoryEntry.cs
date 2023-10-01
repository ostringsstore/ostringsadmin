using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstringsAdmin.Migrations
{
    public partial class AddInventoryEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_Providers_ProviderId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderPayment_ProductProviders_ProductProviderId",
                table: "ProviderPayment");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProviderPayment");

            migrationBuilder.RenameColumn(
                name: "ProductProviderId",
                table: "ProviderPayment",
                newName: "InventoryEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderPayment_ProductProviderId",
                table: "ProviderPayment",
                newName: "IX_ProviderPayment_InventoryEntryId");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ProductProviders",
                newName: "InventoryEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProviders_ProviderId",
                table: "ProductProviders",
                newName: "IX_ProductProviders_InventoryEntryId");

            migrationBuilder.CreateTable(
                name: "InventoryEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryEntry_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryEntry_ProviderId",
                table: "InventoryEntry",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_InventoryEntry_InventoryEntryId",
                table: "ProductProviders",
                column: "InventoryEntryId",
                principalTable: "InventoryEntry",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProviders_InventoryEntry_InventoryEntryId",
                table: "ProductProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProviderPayment_InventoryEntry_InventoryEntryId",
                table: "ProviderPayment");

            migrationBuilder.DropTable(
                name: "InventoryEntry");

            migrationBuilder.RenameColumn(
                name: "InventoryEntryId",
                table: "ProviderPayment",
                newName: "ProductProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProviderPayment_InventoryEntryId",
                table: "ProviderPayment",
                newName: "IX_ProviderPayment_ProductProviderId");

            migrationBuilder.RenameColumn(
                name: "InventoryEntryId",
                table: "ProductProviders",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProviders_InventoryEntryId",
                table: "ProductProviders",
                newName: "IX_ProductProviders_ProviderId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProviderPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProviders_Providers_ProviderId",
                table: "ProductProviders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderPayment_ProductProviders_ProductProviderId",
                table: "ProviderPayment",
                column: "ProductProviderId",
                principalTable: "ProductProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
