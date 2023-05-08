using BusinessLayer.Absract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YazilimProjeYonetimiProjesi.Models;

namespace YazilimProjeYonetimiProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersService _usersService;

        public LoginController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            using (var context = new Context())
            {
                var UnEncryptedUser = context.Users.FirstOrDefault(x => x.UserName== user.UserName);
                UnEncryptedUser.Password = _usersService.UnencryptePassword(UnEncryptedUser.Password);
                var loginUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName && UnEncryptedUser.Password == user.Password);

                if (loginUser != null)
                {
                    ViewBag.Log = "Login Succeeded";
                    UserInfo.UserType = loginUser.UserType;
                    return RedirectToAction("Index", "Dashboard");
                }
                ViewBag.Log = "Access Denied";
                return View();

            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            UserInfo.UserType = 0;
            return RedirectToAction("Login", "Login");
        }
    }

    public static class UserInfo
    {
        public static int UserType;
    }
}