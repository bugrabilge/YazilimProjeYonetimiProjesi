using BusinessLayer;
using BusinessLayer.Absract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUsersService _usersService;

        public SignUpController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public IActionResult Sign()
        {
            return View(new Users());
        }

        [HttpPost]
        public IActionResult Sign(Users user)
        {
            user.UserType = Convert.ToInt32(user.UserType);
            user.Password = _usersService.EncryptePassword(user.Password);
            _usersService.UserAdd(user);
            return RedirectToAction("Login", "Login");
        }
    }
}
