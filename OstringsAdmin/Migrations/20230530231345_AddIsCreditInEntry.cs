using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstringsAdmin.Migrations
{
    public partial class AddIsCreditInEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCredit",
                table: "InventoryEntries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCredit",
                table: "InventoryEntries");
        }
    }
}
