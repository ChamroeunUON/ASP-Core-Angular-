using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPAngular.Migrations {
    public partial class VihicleFeatures : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "Vihicles",
                columns : table => new {
                    Id = table.Column<int> (type: "int", nullable : false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        ContactName = table.Column<string> (type: "nvarchar(255)", maxLength : 255, nullable : false),
                        Email = table.Column<string> (type: "nvarchar(255)", maxLength : 255, nullable : true),
                        IsRegistered = table.Column<bool> (type: "bit", nullable : false),
                        ModelId = table.Column<int> (type: "int", nullable : false),
                        Phone = table.Column<string> (type: "nvarchar(255)", maxLength : 255, nullable : false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Vihicles", x => x.Id);
                });

            migrationBuilder.CreateTable (
                name: "VihicleFeatures",
                columns : table => new {
                    VihicleId = table.Column<int> (type: "int", nullable : false),
                        FeatureID = table.Column<int> (type: "int", nullable : false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_VihicleFeatures", x => new { x.VihicleId, x.FeatureID });
                    table.ForeignKey (
                        name: "FK_VihicleFeatures_Features_FeatureID",
                        column : x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey (
                        name: "FK_VihicleFeatures_Vihicles_VihicleId",
                        column : x => x.VihicleId,
                        principalTable: "Vihicles",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex (
                name: "IX_VihicleFeatures_FeatureID",
                table: "VihicleFeatures",
                column: "FeatureID");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "VihicleFeatures");

            migrationBuilder.DropTable (
                name: "Vihicles");
        }
    }
}