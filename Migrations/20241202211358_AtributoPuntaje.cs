using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class AtributoPuntaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Puntaje",
                table: "Pilotos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntaje",
                table: "Pilotos");
        }
    }
}
