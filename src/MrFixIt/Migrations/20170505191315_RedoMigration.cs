using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrFixIt.Migrations
{
    public partial class RedoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Workers");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Workers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Workers");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Workers",
                nullable: false,
                defaultValue: false);
        }
    }
}
