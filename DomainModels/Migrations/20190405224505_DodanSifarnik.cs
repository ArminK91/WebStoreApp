using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class DodanSifarnik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Co2Emisions",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
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

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PreviousOwners",
                schema: "dbo",
                table: "Products",
                newName: "AutomobilId");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Products",
                newName: "Naziv");

            migrationBuilder.RenameColumn(
                name: "Age",
                schema: "dbo",
                table: "Products",
                newName: "DatumObjave");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "dbo",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Automobili",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Boja = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    Godiste = table.Column<DateTime>(nullable: false),
                    GrijaciSjedista = table.Column<bool>(nullable: false),
                    Kilometri = table.Column<decimal>(nullable: false),
                    Klima = table.Column<bool>(nullable: false),
                    Marka = table.Column<string>(nullable: true),
                    Motor = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    PodizaciStakala = table.Column<bool>(nullable: false),
                    Registrovan = table.Column<bool>(nullable: false),
                    ServoVolan = table.Column<bool>(nullable: false),
                    Siber = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Xenoni = table.Column<bool>(nullable: false),
                    Zastita = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sifarnik",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Extra1 = table.Column<string>(nullable: true),
                    Extra2 = table.Column<string>(nullable: true),
                    Extra3 = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    RoditeljId = table.Column<int>(nullable: true),
                    TipSif = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sifarnik", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AutomobilId",
                schema: "dbo",
                table: "Products",
                column: "AutomobilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products",
                column: "AutomobilId",
                principalSchema: "dbo",
                principalTable: "Automobili",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Automobili_AutomobilId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Automobili",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sifarnik",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Products_AutomobilId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "dbo",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                schema: "dbo",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DatumObjave",
                schema: "dbo",
                table: "Products",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "AutomobilId",
                schema: "dbo",
                table: "Products",
                newName: "PreviousOwners");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
