using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListaSpesa_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatePostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCategoria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    IdArticolo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    NomeArticolo = table.Column<string>(type: "text", nullable: false),
                    PrezzoNormale = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DaComprareSiNo = table.Column<bool>(type: "boolean", nullable: false),
                    Quantità = table.Column<int>(type: "integer", nullable: false),
                    NomeNegozio = table.Column<string>(type: "text", nullable: true),
                    PrezzoOfferta = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    DataScadenzaOfferta = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priorita = table.Column<int>(type: "integer", nullable: false),
                    UnitaMisura = table.Column<string>(type: "text", nullable: true)
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
