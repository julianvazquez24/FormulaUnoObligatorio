namespace FormulaUnoObligatorio.Models
{
    public class Escuderia
    {
        public string NombreEscuderia {get; set;}
        public string SponsorOficial {get; set;}
        public string PaisEscuderia {get; set;}
        public List<Piloto> Pilotos { get; set; }

        public Escuderia(string nombreEscuderia, string sponsorOficial, string paisEscuderia, List<Piloto> Pilotos)
        {
            this.NombreEscuderia = nombreEscuderia;
            this.SponsorOficial = sponsorOficial;
            this.PaisEscuderia = paisEscuderia;
            this.Pilotos = new List<Piloto>();
        }
    }
}
