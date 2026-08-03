using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaSpesa_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCompleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    IdArticolo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    NomeArticolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezzoNormale = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DaComprareSiNo = table.Column<bool>(type: "bit", nullable: false),
                    Quantità = table.Column<int>(type: "int", nullable: false),
                    NomeNegozio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffertaSiNo = table.Column<bool>(type: "bit", nullable: false),
                    PrezzoOfferta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DataScadenzaOfferta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priorita = table.Column<int>(type: "int", nullable: false),
                    UnitaMisura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.IdArticolo);
                    table.ForeignKey(
                        name: "FK_Articoli_Categorie_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorie",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_IdCategoria",
                table: "Articoli",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articoli");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
