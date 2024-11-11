namespace FormulaUnoObligatorio.Models
{
    public class Piloto
    {
        public string NombrePiloto {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public string PaisPiloto {get; set;}
        public Escuderia EscuderiaPiloto {get; set;}
        public int PuntosTotales {get; set;}
    }
}
