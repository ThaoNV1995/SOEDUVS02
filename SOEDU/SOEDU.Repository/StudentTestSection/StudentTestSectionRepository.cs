using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentTestSection
{
    public class StudentTestSectionRepository : IStudentTestSectionRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_StudentTestSection> getAllStudentTestSection()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_StudentTestSection> lst = new List<Sys_StudentTestSection>();
                lst = _db.Sys_StudentTestSection.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_StudentTestSection viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_StudentTestSection.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addStudentTestSection(Sys_StudentTestSection studenttestsection)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_StudentTestSection.Add(studenttestsection);
                    _db.SaveChanges();
                    return studenttestsection.TestSection_ID;
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
        public bool editStudentTestSection(Sys_StudentTestSection studenttestsection)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_StudentTestSection.Find(studenttestsection.TestSection_ID);
                    c.IsDate = studenttestsection.IsDate;
                    c.IsGetTime = studenttestsection.IsGetTime;
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
        public bool deleteStudentTestSection(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_StudentTestSection.Find(id);
                    _db.Sys_StudentTestSection.Remove(result);
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
