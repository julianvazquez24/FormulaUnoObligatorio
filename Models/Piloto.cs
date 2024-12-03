using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormulaUnoObligatorio.Models
{
    public class Piloto
    {
        [Key]
        public int IdPiloto { get; set; }

        [Required(ErrorMessage = "El nombre del piloto no puede estar vacio")]
        public string NombrePiloto { get; set; }

        [Required(ErrorMessage = "El apellido del piloto no puede estar vacio")]
        public string ApellidoPiloto { get; set; }

        public string PaisPiloto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento no puede estar vacia")]
        public DateOnly FechaNacimiento { get; set; }

        // relacion N-1 con Escuderia 

        [Required(ErrorMessage = "Escudería no puede estár vacío")]
        public int IdEscuderia { get; set; }
        public Escuderia? EscuderiaPiloto { get; set; }
        public int Puntaje { get; set; }
        public List<Resultado>? Resultados { get; }

        public Piloto() { }

        public Piloto(string nombrePiloto) {
            NombrePiloto = nombrePiloto;
        }
        public string AsOption(int? idSeleccionado)
        {
            return $"<option value='{IdPiloto}' {(IdPiloto == idSeleccionado ? " selected" : "")}>{NombrePiloto}</option>";
        }

        public int CalcularPuntaje(int posicion)
        {
            switch (posicion)
            {
                case 1: return 25;
                case 2: return 18;
                case 3: return 15;
                case 4: return 12;
                case 5: return 10;
                case 6: return 8;
                case 7: return 6;
                case 8: return 4;
                case 9: return 2;
                case 10: return 1;
                default: return 0; 
            }
        }

        public void ActualizarElPuntaje(int posicion)
        {
            Puntaje += CalcularPuntaje(posicion);
        }

    }
}
