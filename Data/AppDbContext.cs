using FormulaUnoObligatorio.Models;
using Microsoft.EntityFrameworkCore;


namespace FormulaUnoObligatorio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define el DbSet para tu modelo
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Escuderia> Escuderias { get; set; }
        public DbSet<Carrera> Carreras { get; set; }

    }
}
