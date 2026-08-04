using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaSpesa_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class RimuoviOffertaSiNoTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffertaSiNo",
                table: "Articoli");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OffertaSiNo",
                table: "Articoli",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
