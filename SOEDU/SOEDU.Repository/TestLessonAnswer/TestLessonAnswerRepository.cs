using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestLessonAnswer
{
    public class TestLessonAnswerRepository : ITestLessonAnswerRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TestLessonAnswer> getAllTestLessonAnswer()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TestLessonAnswer> lst = new List<Sys_TestLessonAnswer>();
                lst = _db.Sys_TestLessonAnswer.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TestLessonAnswer viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TestLessonAnswer.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addTestLessonAnswer(Sys_TestLessonAnswer testlessonanswer)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TestLessonAnswer.Add(testlessonanswer);
                    _db.SaveChanges();
                    return testlessonanswer.Answer_ID;
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
        public bool editTestLessonAnswer(Sys_TestLessonAnswer testlessonanswer)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TestLessonAnswer.Find(testlessonanswer.Answer_ID);
                    c.Answer_Name = testlessonanswer.Answer_Name;
                    c.Test_ID = testlessonanswer.Test_ID;
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
        public bool deleteTestLessonAnswer(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TestLessonAnswer.Find(id);
                    _db.Sys_TestLessonAnswer.Remove(result);
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
