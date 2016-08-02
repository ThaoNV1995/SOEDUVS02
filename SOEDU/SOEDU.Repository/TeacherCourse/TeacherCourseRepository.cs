using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TeacherCourse
{
    public class TeacherCourseRepository : ITeacherCourseRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TeacherCourse> getAllTeacherCourse()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TeacherCourse> lst = new List<Sys_TeacherCourse>();
                lst = _db.Sys_TeacherCourse.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TeacherCourse viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TeacherCourse.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addTeacherCourse(Sys_TeacherCourse teachercourse)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TeacherCourse.Add(teachercourse);
                    _db.SaveChanges();
                    return teachercourse.User_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa phần học
        /// </summary>
        /// <param name="section">phần học cần sửa</param>
        /// <returns></returns>
        public bool editTeacherCourse(Sys_TeacherCourse teachercourse)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TeacherCourse.Find(teachercourse.User_ID);
                    c.IsSupper = teachercourse.IsSupper;
                    c.IsAdmin = teachercourse.IsAdmin;
                    c.IsStatus = teachercourse.IsStatus;
                    c.CreateDate = teachercourse.CreateDate;
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
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteTeacherCourse(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TeacherCourse.Find(id);
                    _db.Sys_TeacherCourse.Remove(result);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
