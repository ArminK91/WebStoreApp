using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class FixingGodisteGreska : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Godiste",
                schema: "dbo",
                table: "Automobili",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Godiste",
                schema: "dbo",
                table: "Automobili",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
