using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DomainModels.Migrations
{
    public partial class DodavanjePorukaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Proizvodi",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UsrId",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Poruke",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserID = table.Column<int>(nullable: false),
                    DatumObjave = table.Column<DateTime>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    proizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruke_Users_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poruke_Proizvodi_proizvodId",
                        column: x => x.proizvodId,
                        principalSchema: "dbo",
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_UserId",
                schema: "dbo",
                table: "Proizvodi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_ApplicationUserID",
                schema: "dbo",
                table: "Poruke",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_proizvodId",
                schema: "dbo",
                table: "Poruke",
                column: "proizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodi_Users_UserId",
                schema: "dbo",
                table: "Proizvodi",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodi_Users_UserId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Poruke",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Proizvodi_UserId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.DropColumn(
                name: "UsrId",
                schema: "dbo",
                table: "Proizvodi");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Proizvodi",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
