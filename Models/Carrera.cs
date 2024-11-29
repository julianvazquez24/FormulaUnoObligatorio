using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaUnoObligatorio.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string CiudadCarrera { get; set; }
        public DateOnly FechaCarrera { get; set; }

        public List<Resultado>? Resultados { get; set; }
    }
}

