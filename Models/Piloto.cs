using System.ComponentModel.DataAnnotations;

namespace FormulaUnoObligatorio.Models
{
    public class Piloto
    {
        [Key]
        public int IdPiloto { get; set; }

        [Required(ErrorMessage = "El nombre del piloto no puede estar vacio")]
        public string NombrePiloto { get; set; }
        public string ApellidoPiloto { get; set; }

        public string PaisPiloto { get; set; } 

        [Required(ErrorMessage = "La fecha de nacimiento no puede estar vacía")]
        public DateOnly FechaNacimiento { get; set; }
        public int IdEscuderia { get; set; }
        public Escuderia EscuderiaPiloto { get; set; }

        [Required(ErrorMessage = "El tipo de piloto debe ser seleccionado")]
        public List<Carrera> Carreras { get; set; } = new List<Carrera>();
    }
}

