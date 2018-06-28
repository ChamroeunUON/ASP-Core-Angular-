using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPAngular.Migrations
{
    public partial class FixMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Vehicles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Vehicles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vehicles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Vehicles",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
