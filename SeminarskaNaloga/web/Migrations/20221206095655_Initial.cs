using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarskaNaloga.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cena = table.Column<double>(type: "float", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zaloga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelId);
                });

            migrationBuilder.CreateTable(
                name: "Uporabnik",
                columns: table => new
                {
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priimek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stPoste = table.Column<int>(type: "int", nullable: false),
                    telefon = table.Column<int>(type: "int", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabnik", x => x.UporabnikId);
                });

            migrationBuilder.CreateTable(
                name: "Narocilo",
                columns: table => new
                {
                    NarociloId = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    vrednost = table.Column<float>(type: "real", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narocilo", x => x.NarociloId);
                    table.ForeignKey(
                        name: "FK_Narocilo_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunId = table.Column<int>(type: "int", nullable: false),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false),
                    cena = table.Column<float>(type: "real", nullable: false),
                    postnina = table.Column<float>(type: "real", nullable: false),
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    NarociloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunId);
                    table.ForeignKey(
                        name: "FK_Racun_Narocilo_NarociloId",
                        column: x => x.NarociloId,
                        principalTable: "Narocilo",
                        principalColumn: "NarociloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_Uporabnik_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabnik",
                        principalColumn: "UporabnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZgodovinaNarocanja",
                columns: table => new
                {
                    ZgodovinaNarocanjaId = table.Column<int>(type: "int", nullable: false),
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    NarociloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZgodovinaNarocanja", x => x.ZgodovinaNarocanjaId);
                    table.ForeignKey(
                        name: "FK_ZgodovinaNarocanja_Narocilo_NarociloId",
                        column: x => x.NarociloId,
                        principalTable: "Narocilo",
                        principalColumn: "NarociloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZgodovinaNarocanja_Uporabnik_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabnik",
                        principalColumn: "UporabnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narocilo_ArtikelId",
                table: "Narocilo",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_NarociloId",
                table: "Racun",
                column: "NarociloId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_UporabnikId",
                table: "Racun",
                column: "UporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ZgodovinaNarocanja_NarociloId",
                table: "ZgodovinaNarocanja",
                column: "NarociloId");

            migrationBuilder.CreateIndex(
                name: "IX_ZgodovinaNarocanja_UporabnikId",
                table: "ZgodovinaNarocanja",
                column: "UporabnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "ZgodovinaNarocanja");

            migrationBuilder.DropTable(
                name: "Narocilo");

            migrationBuilder.DropTable(
                name: "Uporabnik");

            migrationBuilder.DropTable(
                name: "Artikel");
        }
    }
}
