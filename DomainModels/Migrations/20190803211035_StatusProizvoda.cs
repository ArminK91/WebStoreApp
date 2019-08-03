using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class StatusProizvoda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusProizvoda",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusProizvoda",
                schema: "dbo",
                table: "Proizvodi");
        }
    }
}
