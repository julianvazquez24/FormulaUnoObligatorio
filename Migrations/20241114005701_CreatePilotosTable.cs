using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class CreatePilotosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.CreateTable(
                name: "Escuderias",
                columns: table => new
                {
                    IdEscuderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEscuderia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorOficial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisEscuderia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuderias", x => x.IdEscuderia);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    IdPiloto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePiloto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisPiloto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEscuderia = table.Column<int>(type: "int", nullable: false),
                    EscuderiaPilotoIdEscuderia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.IdPiloto);
                    table.ForeignKey(
                        name: "FK_Pilotos_Escuderias_EscuderiaPilotoIdEscuderia",
                        column: x => x.EscuderiaPilotoIdEscuderia,
                        principalTable: "Escuderias",
                        principalColumn: "IdEscuderia");
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCarrera = table.Column<DateOnly>(type: "date", nullable: false),
                    PilotoIdPiloto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carreras_Pilotos_PilotoIdPiloto",
                        column: x => x.PilotoIdPiloto,
                        principalTable: "Pilotos",
                        principalColumn: "IdPiloto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_PilotoIdPiloto",
                table: "Carreras",
                column: "PilotoIdPiloto");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_EscuderiaPilotoIdEscuderia",
                table: "Pilotos",
                column: "EscuderiaPilotoIdEscuderia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Escuderias");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });
        }
    }
}
