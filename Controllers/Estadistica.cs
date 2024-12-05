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
            ViewBag.TablaPosicionesEscuderias = ObtenerPuntosPorEscudería();
           // ViewBag.HistorialDeCarrerasDeUnaEscudería = ObtenerHistorialDeCarrerasDeUnaEscudería(idEscuderia);
           // ViewBag.CarrerasGanadas = ObtenerCarrerasGanadas();
            return View();
        }

        private List<Piloto> ObtenerPosicionesPilotos()
        {
            return _context.Pilotos.OrderByDescending(p => p.PuntajePiloto).ToList();
        }

        private List<Carrera> ObtenerHistorialDeCarrerasDeUnPiloto(int idPiloto)
        {
            
            return _context.Carreras
                .Where(c => c.IdPiloto == idPiloto)
                .Select(c => new Carrera
                {
                    IdCarrera = c.IdCarrera,
                    NombreCarrera = c.NombreCarrera,
                    FechaCarrera = c.FechaCarrera,
                    PosicionCarrera = c.PosicionCarrera,
                    PuntosCarrera = c.PuntosCarrera, 
                })
                .OrderBy(c => c.FechaCarrera)
                .ToList();
        }

        public IActionResult HistorialCarrerasPiloto(int idPiloto)
        {
            var historial = ObtenerHistorialDeCarrerasDeUnPiloto(idPiloto);

            ViewBag.NombrePiloto = _context.Pilotos
                .Where(p => p.IdPiloto == idPiloto)
                .Select(p => p.NombrePiloto)
                .FirstOrDefault();

            return View(historial);
        }




        private List<Escuderia> ObtenerPuntosPorEscudería()
        {
            var escuderias = _context.Escuderias.ToList();
            
            var escuderiasConPuntos = new List<Escuderia>(); //lista para almacenar las escuderias con sus puntos
            
            foreach (var escuderia in escuderias)
            {
                var pilotos = _context.Pilotos.Where(p => p.IdEscuderia == escuderia.IdEscuderia).ToList();

                // aca sumo los puntos de todos los pilotos de la escuderia
                escuderia.PuntosTotales = pilotos.Sum(p => p.PuntajePiloto);

                escuderiasConPuntos.Add(escuderia);
            }

            return escuderiasConPuntos.OrderByDescending(e => e.PuntosTotales).ToList();
        }
    }

}
