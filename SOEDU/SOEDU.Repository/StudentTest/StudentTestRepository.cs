using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.StudentTest
{
    public class StudentTestRepository : IStudentTestRepository
    {
        /// <summary>
        /// Lấy ra tất cả các bài kiem tra hoc sinh
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_StudentTest> getAllStudentTest()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_StudentTest> lst = new List<Sys_StudentTest>();
                lst = _db.Sys_StudentTest.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết bài kiem tra hoc sinh qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_StudentTest viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_StudentTest.Find(id);
            }
        }
        /// <summary>
        /// Thêm bài kiem tra hoc sinh
        /// </summary>
        /// <param name="studentTest"></param>
        /// <returns></returns>
        public string addStudentTest(Sys_StudentTest studentTest)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_StudentTest.Add(studentTest);
                    _db.SaveChanges();
                    return studentTest.Test_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa bài kiem tra hoc sinh
        /// </summary>
        /// <param name="studentTest">bài kiem tra hoc sinh cần sửa</param>
        /// <returns></returns>
        public bool editStudentTest(Sys_StudentTest studentTest)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_StudentTest.Find(studentTest.Test_ID);
                    c.IsDate = studentTest.IsDate;
                    c.IsGetTime = studentTest.IsGetTime;
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
        public bool deleteStudentTest(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_StudentTest.Find(id);
                    _db.Sys_StudentTest.Remove(result);
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
