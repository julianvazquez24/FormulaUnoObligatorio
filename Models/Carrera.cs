using System.ComponentModel.DataAnnotations.Schema;

namespace FormulaUnoObligatorio.Models
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string CiudadCarrera { get; set; }
        public DateOnly FechaCarrera { get; set; }
        public List<Piloto> PosicionSalida { get; set; } = new List<Piloto>();
        public List<Piloto> PosicionLlegada { get; set; } = new List<Piloto>();
    }
}

