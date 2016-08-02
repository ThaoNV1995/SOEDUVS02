using SOEDU.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOEDU.Entities.Models;
using SOEDU.Repository.User;

namespace SOEDU.Service
{
    public class UserService : IUserService
    {
        UserRepository userRepository = new UserRepository();
        public void Active(string id, bool status)
        {
            userRepository.Active(id, status);
        }

        public bool CheckEmail(string email)
        {
            return userRepository.CheckEmail(email);
        }

        public bool CheckUserName(string userName)
        {
            return userRepository.CheckUserName(userName);
        }

        public string CreateUser(Sys_Users user)
        {
            return userRepository.CreateUser(user);
        }

        public bool DeleteUser(string id)
        {
            return userRepository.DeleteUser(id);
        }

        public Sys_Users GetById(string userName)
        {
            return userRepository.GetById(userName);
        }

        public string InsertForFacebook(Sys_Users entity)
        {
            return userRepository.InsertForFacebook(entity);
        }

        public int Login(string userName, string password)
        {
            return userRepository.Login(userName, password);
        }

        public bool Register(Sys_Users user)
        {
            return userRepository.Register(user);
        }

        public bool UpdateUser(Sys_Users user)
        {
            return userRepository.UpdateUser(user);
        }

        public Sys_Users ViewDetail(string id)
        {
            return userRepository.ViewDetail(id);
        }

        public List<SOEDU.Entities.Models.Sys_Users> ListAllUser()
        {
            return userRepository.ListAllUser();
        }
    }
}
