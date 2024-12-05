﻿// <auto-generated />
using System;
using FormulaUnoObligatorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormulaUnoObligatorio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241205040433_PuntosTotalesEscuderia")]
    partial class PuntosTotalesEscuderia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Carrera", b =>
                {
                    b.Property<int>("IdCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrera"));

                    b.Property<string>("CiudadCarrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("FechaCarrera")
                        .HasColumnType("date");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCarrera");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Escuderia", b =>
                {
                    b.Property<int>("IdEscuderia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEscuderia"));

                    b.Property<string>("NombreEscuderia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisEscuderia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuntosTotales")
                        .HasColumnType("int");

                    b.Property<string>("SponsorOficial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEscuderia");

                    b.ToTable("Escuderias");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Piloto", b =>
                {
                    b.Property<int>("IdPiloto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPiloto"));

                    b.Property<string>("ApellidoPiloto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int>("IdEscuderia")
                        .HasColumnType("int");

                    b.Property<int>("IdResultado")
                        .HasColumnType("int");

                    b.Property<string>("NombrePiloto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisPiloto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuntajePiloto")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoPilotoIdResultado")
                        .HasColumnType("int");

                    b.HasKey("IdPiloto");

                    b.HasIndex("IdEscuderia");

                    b.HasIndex("ResultadoPilotoIdResultado");

                    b.ToTable("Pilotos");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Resultado", b =>
                {
                    b.Property<int>("IdResultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResultado"));

                    b.Property<int>("IdCarrera")
                        .HasColumnType("int");

                    b.Property<int>("IdPiloto")
                        .HasColumnType("int");

                    b.Property<int>("PosicionLlegada")
                        .HasColumnType("int");

                    b.Property<int>("PosicionSalida")
                        .HasColumnType("int");

                    b.HasKey("IdResultado");

                    b.HasIndex("IdCarrera");

                    b.HasIndex("IdPiloto");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Piloto", b =>
                {
                    b.HasOne("FormulaUnoObligatorio.Models.Escuderia", "EscuderiaPiloto")
                        .WithMany("Pilotos")
                        .HasForeignKey("IdEscuderia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaUnoObligatorio.Models.Resultado", "ResultadoPiloto")
                        .WithMany()
                        .HasForeignKey("ResultadoPilotoIdResultado");

                    b.Navigation("EscuderiaPiloto");

                    b.Navigation("ResultadoPiloto");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Resultado", b =>
                {
                    b.HasOne("FormulaUnoObligatorio.Models.Carrera", "CarreraResultado")
                        .WithMany("Resultados")
                        .HasForeignKey("IdCarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaUnoObligatorio.Models.Piloto", "PilotoResultado")
                        .WithMany("Resultados")
                        .HasForeignKey("IdPiloto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarreraResultado");

                    b.Navigation("PilotoResultado");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Carrera", b =>
                {
                    b.Navigation("Resultados");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Escuderia", b =>
                {
                    b.Navigation("Pilotos");
                });

            modelBuilder.Entity("FormulaUnoObligatorio.Models.Piloto", b =>
                {
                    b.Navigation("Resultados");
                });
#pragma warning restore 612, 618
        }
    }
}
