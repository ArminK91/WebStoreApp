using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class Initialadednewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Age",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Co2Emisions",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kilometers",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageOfEquipment",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviousOwners",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                schema: "dbo",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ApplicationUsers_UserId",
                schema: "dbo",
                table: "Products",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ApplicationUsers_UserId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Adress",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Co2Emisions",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EngineType",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackageOfEquipment",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreviousOwners",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Products");
        }
    }
}
