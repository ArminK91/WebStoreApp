using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class ProductsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                schema: "dbo",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products",
                column: "AutomobilId",
                principalSchema: "dbo",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                schema: "dbo",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products",
                column: "AutomobilId",
                principalSchema: "dbo",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
