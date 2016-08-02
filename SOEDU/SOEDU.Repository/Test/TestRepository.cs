using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.Test
{
    public class TestRepository:ITestRepository
    {
        /// <summary>
        /// Lấy ra tất cả các bài test
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_Test> getAllTest()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_Test> lst = new List<Sys_Test>();
                lst = _db.Sys_Test.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết bài test qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_Test viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_Test.Find(id);
            }
        }
        /// <summary>
        /// Thêm bài test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public string addTest(Sys_Test test)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_Test.Add(test);
                    _db.SaveChanges();
                    return test.Test_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa bài test
        /// </summary>
        /// <param name="test">bài testc cần sửa</param>
        /// <returns></returns>
        public bool editTest(Sys_Test test)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_Test.Find(test.Test_ID);
                    c.Test_Name = test.Test_Name;
                    c.IsSetTime = test.IsSetTime;
                    c.Lesson_ID = test.Lesson_ID;
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
        public bool deleteTest(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_Test.Find(id);
                    _db.Sys_Test.Remove(result);
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
