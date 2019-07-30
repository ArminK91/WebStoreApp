using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class novaMigr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "AutomobilId",
                schema: "dbo",
                table: "Products",
                newName: "AutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AutomobilId",
                schema: "dbo",
                table: "Products",
                newName: "IX_Products_AutoId");

            migrationBuilder.AddColumn<int>(
                name: "ProizvodId",
                schema: "dbo",
                table: "Automobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Automobili_AutoId",
                schema: "dbo",
                table: "Products",
                column: "AutoId",
                principalSchema: "dbo",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Automobili_AutoId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProizvodId",
                schema: "dbo",
                table: "Automobili");

            migrationBuilder.RenameColumn(
                name: "AutoId",
                schema: "dbo",
                table: "Products",
                newName: "AutomobilId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AutoId",
                schema: "dbo",
                table: "Products",
                newName: "IX_Products_AutomobilId");

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
    }
}
