using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;
        IDataProtectionProvider _provider;

        public UsersManager(IUsersDal usersDal, IDataProtectionProvider provider)
        {
            _usersDal = usersDal;
            _provider = provider;
        }

        public List<Users> GetAllList()
        {
            return _usersDal.GetListAll();
        }

        public Users GetByID(int id)
        {
            return _usersDal.GetByID(id);
        }

        public void UserAdd(Users users)
        {
            _usersDal.Insert(users);
        }

        public void UserDelete(Users users)
        {
            _usersDal.Delete(users);
        }

        public void UserUpdate(Users users)
        {
            _usersDal.Update(users);
        }

        public string EncryptePassword(string passwordToEncrpte)
        {
            var protector = _provider.CreateProtector("12345");
            return protector.Protect(passwordToEncrpte);
        }

        public string UnencryptePassword(string encryptedPassword)
        {
            var protector = _provider.CreateProtector("12345");
            return protector.Unprotect(encryptedPassword);
        }
    }
}
