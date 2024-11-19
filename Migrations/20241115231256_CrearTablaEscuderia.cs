using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaEscuderia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carreras_Pilotos_PilotoIdPiloto",
                table: "Carreras");

            migrationBuilder.DropIndex(
                name: "IX_Carreras_PilotoIdPiloto",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "PilotoIdPiloto",
                table: "Carreras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
