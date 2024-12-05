using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class PuntosCarrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PuntosCarrera",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntosCarrera",
                table: "Carreras");
        }
    }
}
