using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class PuntosTotalesEscuderia : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntosTotales",
                table: "Escuderias");
        }
    }
}
