using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPAngular.Migrations
{
    public partial class EditVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureID",
                table: "VihicleFeatures");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vihicles");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Vihicles");

            migrationBuilder.RenameColumn(
                name: "FeatureID",
                table: "VihicleFeatures",
                newName: "FeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_VihicleFeatures_FeatureID",
                table: "VihicleFeatures",
                newName: "IX_VihicleFeatures_FeatureId");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Vihicles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Vihicles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vihicles_ModelId",
                table: "Vihicles",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureId",
                table: "VihicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureId",
                table: "VihicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Vihicles_Models_ModelId",
                table: "Vihicles");

            migrationBuilder.DropIndex(
                name: "IX_Vihicles_ModelId",
                table: "Vihicles");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Vihicles");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Vihicles");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "VihicleFeatures",
                newName: "FeatureID");

            migrationBuilder.RenameIndex(
                name: "IX_VihicleFeatures_FeatureId",
                table: "VihicleFeatures",
                newName: "IX_VihicleFeatures_FeatureID");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vihicles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Vihicles",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_VihicleFeatures_Features_FeatureID",
                table: "VihicleFeatures",
                column: "FeatureID",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
