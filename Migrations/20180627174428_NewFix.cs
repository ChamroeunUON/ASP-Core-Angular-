using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPAngular.Migrations
{
    public partial class NewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureId",
                table: "VihicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Vehicles_VihicleId",
                table: "VihicleFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VihicleFeatures",
                table: "VihicleFeatures");

            migrationBuilder.DropColumn(
                name: "VihicleId",
                table: "VihicleFeatures");

            migrationBuilder.RenameTable(
                name: "VihicleFeatures",
                newName: "VehicleFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_VihicleFeatures_FeatureId",
                table: "VehicleFeatures",
                newName: "IX_VehicleFeatures_FeatureId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures",
                columns: new[] { "VehicleId", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.RenameTable(
                name: "VehicleFeatures",
                newName: "VihicleFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VihicleFeatures",
                newName: "IX_VihicleFeatures_FeatureId");

            migrationBuilder.AddColumn<int>(
                name: "VihicleId",
                table: "VihicleFeatures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VihicleFeatures",
                table: "VihicleFeatures",
                columns: new[] { "VihicleId", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureId",
                table: "VihicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VihicleFeatures_Vehicles_VihicleId",
                table: "VihicleFeatures",
                column: "VihicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
