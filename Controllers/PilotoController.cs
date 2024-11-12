using Microsoft.AspNetCore.Mvc;

namespace FormulaUnoObligatorio.Controllers
{
    public class PilotoController : Controller
    {
        public IActionResult Index()
        {
            return View("Piloto");
        }
    }
}
