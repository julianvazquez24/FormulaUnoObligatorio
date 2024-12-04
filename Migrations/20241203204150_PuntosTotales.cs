using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class PuntosTotales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PuntosTotales",
                table: "Escuderias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPiloto",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PilotoIdPiloto",
                table: "Carreras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_PilotoIdPiloto",
                table: "Carreras",
                column: "PilotoIdPiloto");

            migrationBuilder.AddForeignKey(
                name: "FK_Carreras_Pilotos_PilotoIdPiloto",
                table: "Carreras",
                column: "PilotoIdPiloto",
                principalTable: "Pilotos",
                principalColumn: "IdPiloto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carreras_Pilotos_PilotoIdPiloto",
                table: "Carreras");

            migrationBuilder.DropIndex(
                name: "IX_Carreras_PilotoIdPiloto",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "PuntosTotales",
                table: "Escuderias");

            migrationBuilder.DropColumn(
                name: "IdPiloto",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "PilotoIdPiloto",
                table: "Carreras");
        }
    }
}
