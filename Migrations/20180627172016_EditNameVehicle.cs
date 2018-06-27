using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPAngular.Migrations
{
    public partial class EditNameVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Vihicles_VihicleId",
                table: "VihicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Vihicles_Models_ModelId",
                table: "Vihicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vihicles",
                table: "Vihicles");

            migrationBuilder.RenameTable(
                name: "Vihicles",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vihicles_ModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Vehicles_VihicleId",
                table: "VihicleFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vihicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vihicles",
                newName: "IX_Vihicles_ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vihicles",
                table: "Vihicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VihicleFeatures_Vihicles_VihicleId",
                table: "VihicleFeatures",
                column: "VihicleId",
                principalTable: "Vihicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vihicles_Models_ModelId",
                table: "Vihicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
