using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FormulaUnoObligatorio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PrecargaDatos()
        {
            if (_context.Escuderias.Count() == 0)
            {
                var escuderias = new List<Escuderia> {

                    new Escuderia { NombreEscuderia = "Ferrari", SponsorOficial = "HP", PaisEscuderia = "Italia" },
                    new Escuderia { NombreEscuderia = "Mercedes", SponsorOficial = "Petronas", PaisEscuderia = "Alemania" },
                    new Escuderia { NombreEscuderia = "Red Bull", SponsorOficial = "Oracle", PaisEscuderia = "Austria" },
                    new Escuderia { NombreEscuderia = "McLaren", SponsorOficial = "Google", PaisEscuderia = "Reino Unido" },
                    new Escuderia { NombreEscuderia = "Sauber", SponsorOficial = "KICK", PaisEscuderia = "Suiza" },
                    new Escuderia { NombreEscuderia = "Williams", SponsorOficial = "Duracell", PaisEscuderia = "Reino Unido" },
                    new Escuderia { NombreEscuderia = "Aston Martin", SponsorOficial = "Aramco", PaisEscuderia = "Reino Unido" },
                    new Escuderia { NombreEscuderia = "Alpine", SponsorOficial = "BWT", PaisEscuderia = "Francia" },
                    new Escuderia { NombreEscuderia = "Haas", SponsorOficial = "MoneyGram", PaisEscuderia = "Estados Unidos" },
                    new Escuderia { NombreEscuderia = "VCA Red Bull", SponsorOficial = "Visa", PaisEscuderia = "Italia" },

                };
                _context.Escuderias.AddRange(escuderias);
                _context.SaveChanges();
            }

            if (_context.Pilotos.Count() == 0)
            {
                
                int ferrariId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Ferrari")?.IdEscuderia ?? 0;
                int mercedesId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Mercedes")?.IdEscuderia ?? 0;
                int redBullId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Red Bull")?.IdEscuderia ?? 0;
                int mcLarenId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "McLaren")?.IdEscuderia ?? 0;
                int sauberId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Sauber")?.IdEscuderia ?? 0;
                int williamsId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Williams")?.IdEscuderia ?? 0;
                int astonMartinId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Aston Martin")?.IdEscuderia ?? 0;
                int alpineId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Alpine")?.IdEscuderia ?? 0;
                int haasId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "Haas")?.IdEscuderia ?? 0;
                int vcaRedBullId = _context.Escuderias.FirstOrDefault(escuderia => escuderia.NombreEscuderia == "VCA Red Bull")?.IdEscuderia ?? 0;
               
                
                var pilotos = new List<Piloto>
                {
                    new Piloto { NombrePiloto = "Charles", ApellidoPiloto = "Leclerc", PaisPiloto = "Mónaco", FechaNacimiento = new DateOnly(1997, 10, 16), IdEscuderia = ferrariId },
                    new Piloto { NombrePiloto = "Carlos", ApellidoPiloto = "Sainz Jr", PaisPiloto = "España", FechaNacimiento = new DateOnly(1994, 9, 1), IdEscuderia = ferrariId },
                    new Piloto { NombrePiloto = "Lewis", ApellidoPiloto = "Hamilton", PaisPiloto = "Reino Unido", FechaNacimiento = new DateOnly(1985, 1, 7), IdEscuderia = mercedesId },
                    new Piloto { NombrePiloto = "George", ApellidoPiloto = "Russell", PaisPiloto = "Reino Unido", FechaNacimiento = new DateOnly(1998, 2, 15), IdEscuderia = mercedesId },
                    new Piloto { NombrePiloto = "Max", ApellidoPiloto = "Verstappen", PaisPiloto = "Holanda", FechaNacimiento = new DateOnly(1997, 9, 30), IdEscuderia = redBullId },
                    new Piloto { NombrePiloto = "Checo", ApellidoPiloto = "Perez", PaisPiloto = "Mexico", FechaNacimiento = new DateOnly(1990, 1, 26), IdEscuderia = redBullId },
                    new Piloto { NombrePiloto = "Oscar", ApellidoPiloto = "Piastri", PaisPiloto = "Australia", FechaNacimiento = new DateOnly(2001, 5, 6), IdEscuderia = mcLarenId },
                    new Piloto { NombrePiloto = "Lando", ApellidoPiloto = "Norris", PaisPiloto = "Reino Unido", FechaNacimiento = new DateOnly(1999, 11, 13), IdEscuderia = mcLarenId },
                    new Piloto { NombrePiloto = "Valtteri", ApellidoPiloto = "Bottas", PaisPiloto = "Finlandia", FechaNacimiento = new DateOnly(1989, 8, 28), IdEscuderia = sauberId },
                    new Piloto { NombrePiloto = "Zhou", ApellidoPiloto = "Guanyu", PaisPiloto = "China", FechaNacimiento = new DateOnly(1999, 5, 30), IdEscuderia = sauberId },
                    new Piloto { NombrePiloto = "Alexander", ApellidoPiloto = "Albon", PaisPiloto = "Tailandia", FechaNacimiento = new DateOnly(1996, 3, 23), IdEscuderia = williamsId },
                    new Piloto { NombrePiloto = "Franco", ApellidoPiloto = "Colapinto", PaisPiloto = "Argentina", FechaNacimiento = new DateOnly(2003, 5, 27), IdEscuderia = williamsId },
                    new Piloto { NombrePiloto = "Fernando", ApellidoPiloto = "Alonso", PaisPiloto = "España", FechaNacimiento = new DateOnly(1981, 7, 29), IdEscuderia = astonMartinId },
                    new Piloto { NombrePiloto = "Lance", ApellidoPiloto = "Stroll", PaisPiloto = "Canadá", FechaNacimiento = new DateOnly(1998, 10, 29), IdEscuderia = astonMartinId },
                    new Piloto { NombrePiloto = "Esteban", ApellidoPiloto = "Ocon", PaisPiloto = "Francia", FechaNacimiento = new DateOnly(1996, 9, 17), IdEscuderia = alpineId },
                    new Piloto { NombrePiloto = "Pierre", ApellidoPiloto = "Gasly", PaisPiloto = "Francia", FechaNacimiento = new DateOnly(1996, 2, 7), IdEscuderia = alpineId },
                    new Piloto { NombrePiloto = "Kevin", ApellidoPiloto = "Magnussen", PaisPiloto = "Dinamarca", FechaNacimiento = new DateOnly(1992, 10, 5), IdEscuderia = haasId },
                    new Piloto { NombrePiloto = "Nico", ApellidoPiloto = "Hülkenberg", PaisPiloto = "Alemania", FechaNacimiento = new DateOnly(1987, 8, 19), IdEscuderia = haasId },
                    new Piloto { NombrePiloto = "Yuki", ApellidoPiloto = "Tsunoda", PaisPiloto = "Corea del Norte", FechaNacimiento = new DateOnly(2000,5,11), IdEscuderia = vcaRedBullId },
                    new Piloto { NombrePiloto = "Liam", ApellidoPiloto = "Lawson", PaisPiloto = "Nueva Zelanda  ", FechaNacimiento = new DateOnly(2002, 2, 11), IdEscuderia = vcaRedBullId },

                };

                _context.Pilotos.AddRange(pilotos);
                _context.SaveChanges();
            }

            if (_context.Carreras.Count() == 0)
            {
                var carreras = new List<Carrera>
                {
                    new Carrera { NombreCarrera = " Bahrain GP" , CiudadCarrera = "Sakhir" , FechaCarrera = new DateOnly(2024,3,02)},
                    new Carrera { NombreCarrera = " Saudi Arabia GP" , CiudadCarrera = "Jeddah" , FechaCarrera = new DateOnly(2024,3,09)},
                    new Carrera { NombreCarrera = " Australian GP" , CiudadCarrera = "Melbourne" , FechaCarrera = new DateOnly(2024,3,24)},
                    new Carrera { NombreCarrera = " Japanese GP" , CiudadCarrera = "Suzuka" , FechaCarrera = new DateOnly(2024,4,7)},
                    new Carrera { NombreCarrera = " Chinese GP" , CiudadCarrera = "Shanghai" , FechaCarrera = new DateOnly(2024,4,21)},
                    new Carrera { NombreCarrera = " Miami GP" , CiudadCarrera = "Miami" , FechaCarrera = new DateOnly(2024,5,05)},
                    new Carrera { NombreCarrera = " Emilia Romagna GP" , CiudadCarrera = "Imola" , FechaCarrera = new DateOnly(2024,5,19)},
                    new Carrera { NombreCarrera = " Monaco GP" , CiudadCarrera = "Monte Carlo" , FechaCarrera = new DateOnly(2024,5,26)},
                    new Carrera { NombreCarrera = " Canadian GP" , CiudadCarrera = "Montreal" , FechaCarrera = new DateOnly(2024,6,09)},
                    new Carrera { NombreCarrera = " Spanish GP" , CiudadCarrera = "Montemelo" , FechaCarrera = new DateOnly(2024,6,23)},
                    new Carrera { NombreCarrera = " Austrian GP" , CiudadCarrera = "Spielberg" , FechaCarrera = new DateOnly(2024,6,30)},
                    new Carrera { NombreCarrera = " British GP" , CiudadCarrera = "Silverstone" , FechaCarrera = new DateOnly(2024,7,07)},
                    new Carrera { NombreCarrera = " Hungarian GP" , CiudadCarrera = "Budapest" , FechaCarrera = new DateOnly(2024,7,21)},
                    new Carrera { NombreCarrera = " Belgian GP" , CiudadCarrera = "Spa" , FechaCarrera = new DateOnly(2024,7,28)},
                    new Carrera { NombreCarrera = " Dutch GP" , CiudadCarrera = "Zandvoort" , FechaCarrera = new DateOnly(2024,8,25)},
                    new Carrera { NombreCarrera = " Italian GP" , CiudadCarrera = "Monza" , FechaCarrera = new DateOnly(2024,9,01)},
                    new Carrera { NombreCarrera = " Azerbaijan GP" , CiudadCarrera = "Baku" , FechaCarrera = new DateOnly(2024,9,15)},
                    new Carrera { NombreCarrera = " Singapore GP" , CiudadCarrera = "Marina Bay" , FechaCarrera = new DateOnly(2024,9,22)},
                    new Carrera { NombreCarrera = " United States GP" , CiudadCarrera = "Austin" , FechaCarrera = new DateOnly(2024,10,20)},
                    new Carrera { NombreCarrera = " Mexico City GP" , CiudadCarrera = "Mexico City" , FechaCarrera = new DateOnly(2024,10,27)},
                    new Carrera { NombreCarrera = " Sao Paulo GP" , CiudadCarrera = "Sao Paulo" , FechaCarrera = new DateOnly(2024,11,03)},
                    new Carrera { NombreCarrera = " Las Vegas GP" , CiudadCarrera = "Las Vegas" , FechaCarrera = new DateOnly(2024,11,24)},
                    new Carrera { NombreCarrera = " Qatar GP" , CiudadCarrera = "Al Daayen" , FechaCarrera = new DateOnly(2024,12,01)},
                    new Carrera { NombreCarrera = " Abu Dhabi GP" , CiudadCarrera = "Abu Dhabi" , FechaCarrera = new DateOnly(2024,12,08)},
                };

                _context.Carreras.AddRange(carreras);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
