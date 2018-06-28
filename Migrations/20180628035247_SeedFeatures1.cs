using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPAngular.Migrations
{
    public partial class SeedFeatures1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                  migrationBuilder.Sql("INSERT INTO Features (Name) VALUES('Featur1')");
                  migrationBuilder.Sql("INSERT INTO Features (Name) VALUES('Featur2')");
                  migrationBuilder.Sql("INSERT INTO Features (Name) VALUES('Featur3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
