using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class IntegracijaSaCloudinarySlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Slike",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ProductId",
                table: "Slike",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slike_Products_ProductId",
                table: "Slike",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slike_Products_ProductId",
                table: "Slike");

            migrationBuilder.DropIndex(
                name: "IX_Slike_ProductId",
                table: "Slike");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Slike");
        }
    }
}
