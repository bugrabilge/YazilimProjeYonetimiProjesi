using System.ComponentModel;
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
    }
}
