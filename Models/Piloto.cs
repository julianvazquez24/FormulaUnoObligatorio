using System.ComponentModel.DataAnnotations;

namespace FormulaUnoObligatorio.Models
{
    public class Piloto
    {
        [Key]
        public int IdPiloto { get; set; }

        [Required(ErrorMessage = "El nombre del piloto no puede estar vacio")]
        public string NombrePiloto { get; set; }

        [Required(ErrorMessage = "El apellido del piloto no puede estar vacio")]
        public string ApellidoPiloto { get; set; }

        public string PaisPiloto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento no puede estar vacia")]
        public DateOnly FechaNacimiento { get; set; }

        // relacion N-1 con Escuderia 

        [Required(ErrorMessage = "Escudería no puede estár vacío")]
        public int IdEscuderia { get; set; }
        public Escuderia? EscuderiaPiloto { get; set; }

        public List<Resultado> Resultados { get; set; }

    }
}
