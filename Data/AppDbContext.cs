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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llamada al método base para asegurarse de que la configuración predeterminada de EF se aplique
            base.OnModelCreating(modelBuilder);

            // relacion entre piloto y escuderia, piloto tiene 1 escuderia y escuderia tiene N pilotos, despues con una funcin hay que limitarlo a dos
            modelBuilder.Entity<Piloto>()
                .HasOne(piloto => piloto.EscuderiaPiloto)
                .WithMany(escuderia => escuderia.Pilotos)
                .HasForeignKey(piloto => piloto.IdEscuderia);  // IdEscuderia es clave foranea
        }
    }
}
