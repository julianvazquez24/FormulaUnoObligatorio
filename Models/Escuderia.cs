using System.ComponentModel.DataAnnotations;

namespace FormulaUnoObligatorio.Models
{
    public class Escuderia
    {
        [Key]
        public int IdEscuderia { get; set; }

        [Required(ErrorMessage = "El nombre de la escuderia no puede estar vacio")]
        public string NombreEscuderia {get; set;}
        public string SponsorOficial {get; set;}
        [Required(ErrorMessage = "Pais no pude estar vacio")]
        public string PaisEscuderia {get; set;}
        public List<Piloto> Pilotos { get; set; } = new List<Piloto>();

        
    }
}
