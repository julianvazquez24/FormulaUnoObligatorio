using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FormulaUnoObligatorio.Controllers
{
    public class Estadistica : Controller
    {
        private readonly AppDbContext _context;
        public Estadistica(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int idPiloto, int idEscuderia)
        {
            ViewBag.TablaPosicionesPilotos = ObtenerPosicionesPilotos();
            ViewBag.HistorialDeCarrerasDeUnPiloto = ObtenerHistorialDeCarrerasDeUnPiloto(idPiloto);
            // ViewBag.TablaPosicionesEscuderias = ObtenerTablaPosicionesEscuderias();
            ViewBag.TablaPosicionesEscuderias = ObtenerPosicionesEscuderias();
           // ViewBag.HistorialDeCarrerasDeUnaEscudería = ObtenerHistorialDeCarrerasDeUnaEscudería(idEscuderia);
           // ViewBag.CarrerasGanadas = ObtenerCarrerasGanadas();
            return View();
        }

        private List<Piloto> ObtenerPosicionesPilotos()
        {
            return _context.Pilotos.OrderByDescending(p => p.PuntajePiloto).ToList();
        }

        

        private List<Escuderia> ObtenerPosicionesEscuderias()
        {
            var escuderias = _context.Escuderias.ToList();
            
            var escuderiasConPuntos = new List<Escuderia>();

            foreach (var escuderia in escuderias)
            {
                var pilotos = _context.Pilotos.Where(p => p.IdEscuderia == escuderia.IdEscuderia).ToList();

                escuderia.PuntosTotales = pilotos.Sum(p => p.PuntajePiloto);

                escuderiasConPuntos.Add(escuderia);
            }
            
            var escuderiasAgrupadas = escuderiasConPuntos
                .GroupBy(e => e.NombreEscuderia)
                .Select(g => new Escuderia
                {
                    NombreEscuderia = g.Key,
                    PuntosTotales = g.Sum(e => e.PuntosTotales)
                })
                .OrderByDescending(e => e.PuntosTotales) 
                .ToList();

            return escuderiasAgrupadas;
        }

        


    }

}
