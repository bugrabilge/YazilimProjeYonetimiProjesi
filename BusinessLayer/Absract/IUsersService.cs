using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
    public interface IUsersService
    {
        void UserAdd(Users users);
        void UserDelete(Users users);
        void UserUpdate(Users users);
        List<Users> GetAllList();
        Users GetByID(int id);
        Users GetUserByUsername(Users users);
        string EncryptePassword(string passwordToEncrpte);
        string UnencryptePassword(string encryptedPassword);
    }
}
