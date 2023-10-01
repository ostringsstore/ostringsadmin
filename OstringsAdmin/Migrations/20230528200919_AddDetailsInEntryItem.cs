using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstringsAdmin.Migrations
{
    public partial class AddDetailsInEntryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "InventoryItems");
        }
    }
}
