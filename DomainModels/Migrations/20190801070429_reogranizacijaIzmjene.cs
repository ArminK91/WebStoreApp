using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class reogranizacijaIzmjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slike_Products_ProductId",
                table: "Slike");

            migrationBuilder.DropForeignKey(
                name: "FK_Slike_Proizvod_ProizvodId",
                table: "Slike");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsImages_Products_ProductId1",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Slike_ProductId",
                table: "Slike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvod",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Slike");

            migrationBuilder.RenameTable(
                name: "Proizvod",
                newName: "Proizvodi",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "ProizvodId",
                schema: "dbo",
                table: "Automobili",
                newName: "ProizvId");

            migrationBuilder.RenameColumn(
                name: "Opis",
                schema: "dbo",
                table: "Proizvodi",
                newName: "Naziv");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                schema: "dbo",
                table: "Proizvodi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                schema: "dbo",
                table: "Proizvodi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Proizvodi",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvodi",
                schema: "dbo",
                table: "Proizvodi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_AutoId",
                schema: "dbo",
                table: "Proizvodi",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_CategoryId",
                schema: "dbo",
                table: "Proizvodi",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slike_Proizvodi_ProizvodId",
                table: "Slike",
                column: "ProizvodId",
                principalSchema: "dbo",
                principalTable: "Proizvodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsImages_Proizvodi_ProductId1",
                schema: "dbo",
                table: "ProductsImages",
                column: "ProductId1",
                principalSchema: "dbo",
                principalTable: "Proizvodi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Automobili_AutoId",
                schema: "dbo",
                table: "Proizvodi",
                column: "AutoId",
                principalSchema: "dbo",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Categories_CategoryId",
                schema: "dbo",
                table: "Proizvodi",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slike_Proizvodi_ProizvodId",
                table: "Slike");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsImages_Proizvodi_ProductId1",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Automobili_AutoId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Categories_CategoryId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvodi",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_AutoId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_CategoryId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Adress",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "AutoId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.RenameTable(
                name: "Proizvodi",
                schema: "dbo",
                newName: "Proizvod");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Proizvod",
                newName: "Opis");

            migrationBuilder.RenameColumn(
                name: "ProizvId",
                schema: "dbo",
                table: "Automobili",
                newName: "ProizvodId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Slike",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvod",
                table: "Proizvod",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(nullable: true),
                    AutoId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Automobili_AutoId",
                        column: x => x.AutoId,
                        principalSchema: "dbo",
                        principalTable: "Automobili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ProductId",
                table: "Slike",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AutoId",
                schema: "dbo",
                table: "Products",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slike_Products_ProductId",
                table: "Slike",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Slike_Proizvod_ProizvodId",
                table: "Slike",
                column: "ProizvodId",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsImages_Products_ProductId1",
                schema: "dbo",
                table: "ProductsImages",
                column: "ProductId1",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
