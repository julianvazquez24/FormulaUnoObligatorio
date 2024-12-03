using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPuntajePiloto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Puntaje",
                table: "Pilotos",
                newName: "PuntajePiloto");

            migrationBuilder.AddColumn<int>(
                name: "IdResultado",
                table: "Pilotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultadoPilotoIdResultado",
                table: "Pilotos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_ResultadoPilotoIdResultado",
                table: "Pilotos",
                column: "ResultadoPilotoIdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Resultados_ResultadoPilotoIdResultado",
                table: "Pilotos",
                column: "ResultadoPilotoIdResultado",
                principalTable: "Resultados",
                principalColumn: "IdResultado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Resultados_ResultadoPilotoIdResultado",
                table: "Pilotos");

            migrationBuilder.DropIndex(
                name: "IX_Pilotos_ResultadoPilotoIdResultado",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "IdResultado",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "ResultadoPilotoIdResultado",
                table: "Pilotos");

            migrationBuilder.RenameColumn(
                name: "PuntajePiloto",
                table: "Pilotos",
                newName: "Puntaje");
        }
    }
}
