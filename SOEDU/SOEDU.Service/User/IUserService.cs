using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Service.User
{
    public interface IUserService
    {
        List<SOEDU.Entities.Models.Sys_Users> ListAllUser();
        SOEDU.Entities.Models.Sys_Users ViewDetail(string id);
        string CreateUser(SOEDU.Entities.Models.Sys_Users user);
        bool UpdateUser(SOEDU.Entities.Models.Sys_Users user);
        bool DeleteUser(string id);
        int Login(string userName, string password);
        bool Register(SOEDU.Entities.Models.Sys_Users user);
        void Active(string id, bool status);
        bool CheckUserName(string userName);
        bool CheckEmail(string email);
        SOEDU.Entities.Models.Sys_Users GetById(string userName);
        string InsertForFacebook(SOEDU.Entities.Models.Sys_Users entity);
    }
}
