using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class Carrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carreras",
                newName: "IdCarrera");

            migrationBuilder.AlterColumn<string>(
                name: "PaisPiloto",
                table: "Pilotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                column: "EscuderiaPilotoIdEscuderia",
                principalTable: "Escuderias",
                principalColumn: "IdEscuderia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos");

            migrationBuilder.RenameColumn(
                name: "IdCarrera",
                table: "Carreras",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PaisPiloto",
                table: "Pilotos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                column: "EscuderiaPilotoIdEscuderia",
                principalTable: "Escuderias",
                principalColumn: "IdEscuderia");
        }
    }
}
