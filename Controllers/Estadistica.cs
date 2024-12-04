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
            ViewBag.HistorialDeCarrerasDeUnaEscudería = ObtenerHistorialDeCarrerasDeUnaEscudería(idEscuderia);
            ViewBag.CarrerasGanadas = ObtenerCarrerasGanadas();
            return View();
        }

        private List<Piloto> ObtenerPosicionesPilotos()
        {
            return _context.Pilotos.OrderBy(p => p.PuntajePiloto).ToList();
        }

        private List<Carrera> ObtenerHistorialDeCarrerasDeUnPiloto(int idPiloto)
        {
            return _context.Carreras
                .Where(c => c.IdPiloto == idPiloto)
                .OrderBy(c => c.FechaCarrera)
                .ToList();
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

        private List<Carrera> ObtenerHistorialDeCarrerasDeUnaEscudería(int idEscuderia)
        {
            var historialCarreras = _context.Carreras
                .Where(c => c.Piloto.IdEscuderia == idEscuderia)  
                .Include(c => c.Piloto)  
                .OrderBy(c => c.FechaCarrera)
                .ToList();

            return historialCarreras;
        }

        private List<Piloto> ObtenerCarrerasGanadas()
        {
            // Obtener todos los pilotos que han participado en alguna carrera
            var pilotos = _context.Pilotos.ToList();

            var pilotosConPrimerosLugares = new List<Piloto>();

            // Contar las veces que cada piloto ha quedado en primer lugar
            foreach (var piloto in pilotos)
            {
                var carrerasGanadas = _context.Carreras
                    .Where(c => c.IdPiloto == piloto.IdPiloto && c.PosicionCarrera == 1) // Solo primeros lugares
                    .Count();

                if (carrerasGanadas > 0)
                {
                    pilotosConPrimerosLugares.Add(new Piloto
                    {
                        NombrePiloto = piloto.NombrePiloto,
                        CarrerasGanadas = carrerasGanadas
                    });
                }
            }

            // Ordenar por la cantidad de carreras ganadas (de mayor a menor)
            return pilotosConPrimerosLugares.OrderByDescending(p => p.CarrerasGanadas).ToList();
        }

    }

}
