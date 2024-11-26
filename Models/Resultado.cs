using System.ComponentModel.DataAnnotations;

namespace FormulaUnoObligatorio.Models
{
    public class Resultado
    {
        [Key]
        public int IdResultado { get; set; }

        // relacion N-1 con Carrera 

        [Required(ErrorMessage = "Carrera no puede estár vacía")]
        public int IdCarrera { get; set; }
        public Carrera? CarreraResultado { get; set; }
        // relacion N-1 con Piloto 

        [Required(ErrorMessage = "Piloto no puede estár vacío")]
        public int IdPiloto { get; set; }
        public Piloto? PilotoResultado { get; set; }

        public int PosicionSalida { get; set; }
        public int PosicionLlegada { get; set; }
    }
}
