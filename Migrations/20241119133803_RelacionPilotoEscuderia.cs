using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPilotoEscuderia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos");

            migrationBuilder.DropIndex(
                name: "IX_Pilotos_EscuderiaPilotoIdEscuderia",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "EscuderiaPilotoIdEscuderia",
                table: "Pilotos");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_IdEscuderia",
                table: "Pilotos",
                column: "IdEscuderia");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Escuderias_IdEscuderia",
                table: "Pilotos",
                column: "IdEscuderia",
                principalTable: "Escuderias",
                principalColumn: "IdEscuderia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Escuderias_IdEscuderia",
                table: "Pilotos");

            migrationBuilder.DropIndex(
                name: "IX_Pilotos_IdEscuderia",
                table: "Pilotos");

            migrationBuilder.AddColumn<int>(
                name: "EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                column: "EscuderiaPilotoIdEscuderia");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                column: "EscuderiaPilotoIdEscuderia",
                principalTable: "Escuderias",
                principalColumn: "IdEscuderia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
