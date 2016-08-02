using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.User
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Danh sách tất cả người dùng người dùng
        /// </summary>
        /// <returns>List</returns>
        public List<SOEDU.Entities.Models.Sys_Users> ListAllUser()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.ToList();
            }
        }
        /// <summary>
        /// Xem chi tiết người dùng
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>User</returns>
        public Sys_Users ViewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.Find(id);
            }
        }
        /// <summary>
        /// lấy ra user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Sys_Users GetById(string userName)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.SingleOrDefault(x => x.User_Name == userName);
            }
        }
        /// <summary>
        /// Tạo người dùng
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>string</returns>
        public string CreateUser(Sys_Users user)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_Users.Add(user);
                    _db.SaveChanges();
                    return user.User_ID;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        /// <summary>
        /// Cập nhật người dùng
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>bool</returns>
        public bool UpdateUser(Sys_Users user)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Users.Find(user.User_ID);
                    c.User_Name = user.User_Name;
                    c.IsPassword = user.IsPassword;
                    c.IsName = user.IsName;
                    c.IsAdds = user.IsAdds;
                    c.IsEmail = user.IsEmail;
                    c.IsMobile = user.IsMobile;
                    c.IsFoto = user.IsFoto;
                    c.IsLocked = user.IsLocked;
                    c.IsSex = user.IsSex;
                    c.IsDes = user.IsDes;
                    c.IsLevel = user.IsLevel;
                    c.CreateDate = user.CreateDate;
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteUser(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Users.Find(id);
                    _db.Sys_Users.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Đăng Nhập
        /// </summary>
        /// <param name="userName">tên tài khoản</param>
        /// <param name="password">mật khẩu</param>
        /// <returns> int</returns>
        public int Login(string userName, string password)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                var result = _db.Sys_Users.SingleOrDefault(x => x.User_Name == userName && x.IsPassword == password);//lấy giá trị của User Name
                if (result == null)//Nếu bằng null
                {
                    return 0;//Nhập Tài Khoản Và Mật Khẩu
                }
                else    //Khác Null
                {
                    if (result.IsLocked == false)//Trạng Thaí = False
                    {
                        return -1;  //Tài Khoản Đang Bị Khóa
                    }
                    else  //Trạng Thái == true
                    {
                        if (result.IsPassword == password)  //Nếu Password đúng
                            return 1; //Đăng Nhập Thành Công
                        else
                            return -2; //Sai tài khoản và mật khẩu
                    }
                }
            }
        }
        /// <summary>
        /// Đăng kí Tài Khoản
        /// </summary>
        /// <param name="user">tài khoản</param>
        /// <returns>bool</returns>
        public bool Register(Sys_Users user)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                if (user != null)
                {
                    var User = _db.Sys_Users.Add(user);
                    _db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// kích hoạt tài khoản
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="status">trạng thái</param>
        public void Active(string id, bool status)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                var data = _db.Sys_Users.SingleOrDefault(x => x.User_ID == id);
                data.IsLocked = true;
                _db.SaveChanges();
            }
        }
        /// <summary>
        /// kiểm tra tào khoản
        /// </summary>
        /// <param name="userName">tên tài khoản</param>
        /// <returns></returns>
        public bool CheckUserName(string userName)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.Count(x => x.User_Name == userName) > 0;
            }
        }
        /// <summary>
        /// kiểm tra email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.Count(x => x.IsEmail == email) > 0;
            }
        }
        /// <summary>
        /// Đăng Nhập Với Facebook
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string InsertForFacebook(Sys_Users entity)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                var user = _db.Sys_Users.SingleOrDefault(x => x.User_Name == entity.User_Name);
                if (user == null)
                {
                    _db.Sys_Users.Add(entity);
                    _db.SaveChanges();
                    return entity.User_ID;
                }
                else
                {
                    return user.User_ID;
                }
            }
        }

        public List<Sys_Users> GetUserById(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Users.Where(x => x.User_ID == id).ToList();
            }
        }
    }
}
