using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GE.Data.Migrations
{
    public partial class FluentAPi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Trohpees",
                columns: table => new
                {
                    TropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recompense = table.Column<double>(type: "float", nullable: false),
                    TypeTrophee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipeFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trohpees", x => x.TropheeId);
                    table.ForeignKey(
                        name: "FK_Trohpees_Equipes_EquipeFk",
                        column: x => x.EquipeFk,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    DateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreFk = table.Column<int>(type: "int", nullable: false),
                    EquipeFk = table.Column<int>(type: "int", nullable: false),
                    DureeMois = table.Column<int>(type: "int", nullable: false),
                    Salaire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => new { x.DateContrat, x.MembreFk, x.EquipeFk });
                    table.ForeignKey(
                        name: "FK_Contrats_Equipes_EquipeFk",
                        column: x => x.EquipeFk,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrats_Membres_MembreFk",
                        column: x => x.MembreFk,
                        principalTable: "Membres",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_EquipeFk",
                table: "Contrats",
                column: "EquipeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_MembreFk",
                table: "Contrats",
                column: "MembreFk");

            migrationBuilder.CreateIndex(
                name: "IX_Trohpees_EquipeFk",
                table: "Trohpees",
                column: "EquipeFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Trohpees");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
