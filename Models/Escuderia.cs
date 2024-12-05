using System.ComponentModel.DataAnnotations;

using System.Collections.Generic; 
namespace FormulaUnoObligatorio.Models
{
    public class Escuderia
    {
        [Key]
        public int IdEscuderia { get; set; }

        [Required(ErrorMessage = "El nombre de la escudería no puede estar vacío")]
        public string NombreEscuderia { get; set; }

        public string SponsorOficial { get; set; }

        [Required(ErrorMessage = "El país no puede estar vacío")]
        public string PaisEscuderia { get; set; }
        public List<Piloto> Pilotos { get; set; } = new List<Piloto>();

        public int PuntosTotales { get; set; }
    }
}

