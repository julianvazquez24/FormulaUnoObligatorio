namespace FormulaUnoObligatorio.Models
{
    public class Carrera
    {
        public string NombreCarrera { get; set; }
        public string CiudadCarrera { get; set; }
        public DateOnly FechaCarrera { get; set; }
        public List<Piloto> PosicionSalida { get; set; }
        public List<Piloto> PosicionLlegada { get; set; }

        public Carrera(string nombreCarrera, string ciudadCarrera, DateOnly fechaCarrera, List<Piloto> posicionSalida, List<Piloto> posicionLLegada )
        {
            this.NombreCarrera = nombreCarrera;
            this.CiudadCarrera = ciudadCarrera;
            this.FechaCarrera = fechaCarrera;
            this.PosicionSalida = posicionSalida;
            this.PosicionLlegada = posicionLLegada;
            
        }

        public static int PuntajePorPiloto(List<Piloto> Pilotos)
        {
            return 0;
        }
    }
}
