using Microsoft.AspNetCore.Mvc;

namespace FormulaUnoObligatorio.Controllers
{
    public class EscuderiaController : Controller
    {
        public ActionResult Index()
        {
            return View("Escuderia"); 
        }
    }
}
