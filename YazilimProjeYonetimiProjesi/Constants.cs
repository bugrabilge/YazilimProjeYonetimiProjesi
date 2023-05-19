using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel;
using System.Security.Claims;
using System.Security.Principal;
using YazilimProjeYonetimiProjesi.Controllers;

namespace YazilimProjeYonetimiProjesi
{
    public static class Constants
    {
        public enum Roles
        {
            ADMIN = 1,
            MODERATOR = 2,
            OFFICER = 3,
        }

        public static string SetLayout()
        {
            string returnValue = "";
            switch (UserInfo.UserType)
            {
                case 0:
                    returnValue = "~/Views/Shared/_Layout.cshtml";
                    break;
                case 1:
                    returnValue = "~/Views/Shared/_LayoutAdmin.cshtml";
                    break;
                case 2:
                    returnValue = "~/Views/Shared/_LayoutModerator.cshtml";
                    break;
                case 3:
                    returnValue = "~/Views/Shared/_LayoutOfficer.cshtml";
                    break;
            }

            return returnValue;
        }

        public static ClaimsIdentity SetRolesAndAuthenticate(Users user)
        {
            string userRole = "";

            switch (UserInfo.UserType)
            {
                case 1:
                    userRole = "Admin";
                    break;
                case 2:
                    userRole = "Moderator";
                    break;
                case 3:
                    userRole = "Officer";
                    break;
            }

            ClaimsIdentity identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, userRole)
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            return identity;
        }
    }
}
