using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentCourse
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_StudentCourse> getAllStudentCourse()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_StudentCourse> lst = new List<Sys_StudentCourse>();
                lst = _db.Sys_StudentCourse.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_StudentCourse viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_StudentCourse.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addStudentCourse(Sys_StudentCourse studentcourse)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_StudentCourse.Add(studentcourse);
                    _db.SaveChanges();
                    return studentcourse.User_ID;
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
        public bool editStudentCourse(Sys_StudentCourse studentcourse)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_StudentCourse.Find(studentcourse.User_ID);
                    c.IsStatus = studentcourse.IsStatus;
                    c.CreateDate = studentcourse.CreateDate;
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
        public bool deleteStudentCourse(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_StudentCourse.Find(id);
                    _db.Sys_StudentCourse.Remove(result);
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
