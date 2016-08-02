using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSectionAnswer
{
    public class TestSectionAnswerRepository : ITestSectionAnswerRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TestSectionAnswer> getAllTestSectionAnswer()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TestSectionAnswer> lst = new List<Sys_TestSectionAnswer>();
                lst = _db.Sys_TestSectionAnswer.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TestSectionAnswer viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TestSectionAnswer.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addTestSectionAnswer(Sys_TestSectionAnswer testsectionanswer)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TestSectionAnswer.Add(testsectionanswer);
                    _db.SaveChanges();
                    return testsectionanswer.Answer_ID;
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
        public bool editTestSectionAnswer(Sys_TestSectionAnswer testsectionanswer)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TestSectionAnswer.Find(testsectionanswer.Answer_ID);
                    c.Answer_Name = testsectionanswer.Answer_Name;
                    c.TestSection_ID = testsectionanswer.TestSection_ID;
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
        public bool deleteTestSectionAnswer(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TestSectionAnswer.Find(id);
                    _db.Sys_TestSectionAnswer.Remove(result);
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
