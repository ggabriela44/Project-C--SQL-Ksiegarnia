using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ksiegarnia.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dostawa",
                columns: table => new
                {
                    Id_dostawa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Oplata = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostawa", x => x.Id_dostawa);
                });

            migrationBuilder.CreateTable(
                name: "Gatunek",
                columns: table => new
                {
                    Id_gatunek = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatunek_ksiazki = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunek", x => x.Id_gatunek);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    Id_klient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nr_telefon = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.Id_klient);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    Id_ksiazka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GatunekID = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Wydawnictwo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data_wydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazka", x => x.Id_ksiazka);
                    table.ForeignKey(
                        name: "FK_Ksiazka_Gatunek_GatunekID",
                        column: x => x.GatunekID,
                        principalTable: "Gatunek",
                        principalColumn: "Id_gatunek",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    Id_zamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlientID = table.Column<int>(type: "int", nullable: false),
                    DostawaID = table.Column<int>(type: "int", nullable: false),
                    Cena_ksiazek = table.Column<float>(type: "real", nullable: false),
                    Cena_dostawy = table.Column<float>(type: "real", nullable: false),
                    Typ_zaplaty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nr_domu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kod_pocztowy = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.Id_zamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Dostawa_DostawaID",
                        column: x => x.DostawaID,
                        principalTable: "Dostawa",
                        principalColumn: "Id_dostawa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klient",
                        principalColumn: "Id_klient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KsiazkaZamowienie",
                columns: table => new
                {
                    ZamowienieID = table.Column<int>(type: "int", nullable: false),
                    KsiazkaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazkaZamowienie", x => new { x.KsiazkaID, x.ZamowienieID });
                    table.ForeignKey(
                        name: "FK_KsiazkaZamowienie_Ksiazka_KsiazkaID",
                        column: x => x.KsiazkaID,
                        principalTable: "Ksiazka",
                        principalColumn: "Id_ksiazka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsiazkaZamowienie_Zamowienie_ZamowienieID",
                        column: x => x.ZamowienieID,
                        principalTable: "Zamowienie",
                        principalColumn: "Id_zamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_GatunekID",
                table: "Ksiazka",
                column: "GatunekID");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaZamowienie_ZamowienieID",
                table: "KsiazkaZamowienie",
                column: "ZamowienieID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_DostawaID",
                table: "Zamowienie",
                column: "DostawaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KlientID",
                table: "Zamowienie",
                column: "KlientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsiazkaZamowienie");

            migrationBuilder.DropTable(
                name: "Ksiazka");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Gatunek");

            migrationBuilder.DropTable(
                name: "Dostawa");

            migrationBuilder.DropTable(
                name: "Klient");
        }
    }
}
