using Microsoft.AspNetCore.Mvc;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class Page1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
