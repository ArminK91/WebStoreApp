using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class FKProdukti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsImages_Products_ImageId",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsImages",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductsImages_ImageId",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "ProductsImages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                schema: "dbo",
                table: "ProductsImages",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsImages",
                schema: "dbo",
                table: "ProductsImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsImages_ProductId",
                schema: "dbo",
                table: "ProductsImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsImages_ProductId1",
                schema: "dbo",
                table: "ProductsImages",
                column: "ProductId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsImages_Products_ProductId1",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsImages",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductsImages_ProductId",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductsImages_ProductId1",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                schema: "dbo",
                table: "ProductsImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsImages",
                schema: "dbo",
                table: "ProductsImages",
                columns: new[] { "ProductId", "ImageId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsImages_ImageId",
                schema: "dbo",
                table: "ProductsImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsImages_Products_ImageId",
                schema: "dbo",
                table: "ProductsImages",
                column: "ImageId",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
