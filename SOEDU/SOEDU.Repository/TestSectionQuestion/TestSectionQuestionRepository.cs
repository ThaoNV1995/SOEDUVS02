using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSectionQuestion
{
    public class TestSectionQuestionRepository : ITestSectionQuestionRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TestSectionQuestion> getAllTestSectionQuestion()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TestSectionQuestion> lst = new List<Sys_TestSectionQuestion>();
                lst = _db.Sys_TestSectionQuestion.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TestSectionQuestion viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TestSectionQuestion.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addTestSectionQuestion(Sys_TestSectionQuestion testsectionquestion)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TestSectionQuestion.Add(testsectionquestion);
                    _db.SaveChanges();
                    return testsectionquestion.Question_ID;
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
        public bool editTestSectionQuestion(Sys_TestSectionQuestion testsectionquestion)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TestSectionQuestion.Find(testsectionquestion.Question_ID);
                    c.Question_Name = testsectionquestion.Question_Name;
                    c.IsSupper = testsectionquestion.IsSupper;
                    c.IsOK = testsectionquestion.IsOK;
                    c.Answer_ID = testsectionquestion.Answer_ID;
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
        public bool deleteTestSectionQuestion(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TestSectionQuestion.Find(id);
                    _db.Sys_TestSectionQuestion.Remove(result);
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
