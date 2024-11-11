namespace FormulaUnoObligatorio.Models
{
    public class Piloto
    {
        public string NombrePiloto {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public string PaisPiloto {get; set;}
        public Escuderia EscuderiaPiloto {get; set;}
        public int PuntosTotales {get; set;}

        public Piloto(string nombrePiloto, DateOnly fechaNacimiento, string paisPiloto, Escuderia escuderiaPiloto, int puntosTotales )
        {
            this.NombrePiloto = nombrePiloto;
            this.FechaNacimiento = fechaNacimiento;
            this.PaisPiloto = paisPiloto;
            this.EscuderiaPiloto = escuderiaPiloto;
            this.PuntosTotales = puntosTotales;
        }
    }
}
