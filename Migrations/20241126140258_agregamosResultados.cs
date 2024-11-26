using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    /// <inheritdoc />
    public partial class agregamosResultados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCarrera = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.IdCarrera);
                });

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
                    ApellidoPiloto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisPiloto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEscuderia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.IdPiloto);
                    table.ForeignKey(
                        name: "FK_Pilotos_Escuderias_IdEscuderia",
                        column: x => x.IdEscuderia,
                        principalTable: "Escuderias",
                        principalColumn: "IdEscuderia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdPiloto = table.Column<int>(type: "int", nullable: false),
                    PosicionSalida = table.Column<int>(type: "int", nullable: false),
                    PosicionLlegada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_Resultados_Carreras_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carreras",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultados_Pilotos_IdPiloto",
                        column: x => x.IdPiloto,
                        principalTable: "Pilotos",
                        principalColumn: "IdPiloto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_IdEscuderia",
                table: "Pilotos",
                column: "IdEscuderia");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_IdCarrera",
                table: "Resultados",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_IdPiloto",
                table: "Resultados",
                column: "IdPiloto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Escuderias");
        }
    }
}
