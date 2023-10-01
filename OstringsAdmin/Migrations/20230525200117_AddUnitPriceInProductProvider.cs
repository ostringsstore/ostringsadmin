﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OstringsAdmin.Migrations
{
    public partial class AddUnitPriceInProductProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "ProductProviders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProductProviders");
        }
    }
}
