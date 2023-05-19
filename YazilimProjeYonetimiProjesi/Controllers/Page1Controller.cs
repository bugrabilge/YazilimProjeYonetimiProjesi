using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static YazilimProjeYonetimiProjesi.Constants;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class Page1Controller : Controller
    {
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
