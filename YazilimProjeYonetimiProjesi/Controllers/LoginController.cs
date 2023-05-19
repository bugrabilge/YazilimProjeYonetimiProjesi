using BusinessLayer.Absract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YazilimProjeYonetimiProjesi.Models;
using System.Security.Claims;
using System.Security.Principal;

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
                Users? loginUser = null;
                var UnEncryptedUser = _usersService.GetUserByUsername(user);

                if (UnEncryptedUser != null)
                {
                    UnEncryptedUser.Password = _usersService.UnencryptePassword(UnEncryptedUser.Password);
                    loginUser = context.Users.FirstOrDefault(x => x.UserName == user.UserName && UnEncryptedUser.Password == user.Password);
                }

                if (loginUser != null)
                {
                    ViewBag.Log = "Login Succeeded";
                    UserInfo.UserType = loginUser.UserType;
                    ClaimsIdentity identity = Constants.SetRolesAndAuthenticate(loginUser);
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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

        public IActionResult AccessDeniedPage()
        {
            return View();
        }
    }

    public static class UserInfo
    {
        public static int UserType;
    }
}