using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaSpesa_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class NomeArticoloUnivoco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Articoli_NomeArticolo",
                table: "Articoli",
                column: "NomeArticolo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Articoli_NomeArticolo",
                table: "Articoli");
        }
    }
}
