using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class StatusSlogova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
