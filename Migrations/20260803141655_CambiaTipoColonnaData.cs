using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaSpesa_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CambiaTipoColonnaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffertaSiNo",
                table: "Articoli");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenzaOfferta",
                table: "Articoli",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenzaOfferta",
                table: "Articoli",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OffertaSiNo",
                table: "Articoli",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
