using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestLessonQuestion
{
    public class TestLessonQuestionRepository: ITestLessonQuestionRepository
    {
        /// <summary>
        /// Lấy ra tất cả các phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TestLessonQuestion> getAllTestLessonQuestion()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TestLessonQuestion> lst = new List<Sys_TestLessonQuestion>();
                lst = _db.Sys_TestLessonQuestion.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TestLessonQuestion viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TestLessonQuestion.Find(id);
            }
        }
        /// <summary>
        /// Thêm phần học
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public string addTestLessonQuestion(Sys_TestLessonQuestion testslessonquestion)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TestLessonQuestion.Add(testslessonquestion);
                    _db.SaveChanges();
                    return testslessonquestion.Question_ID;
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
        public bool editTestLessonQuestion(Sys_TestLessonQuestion testslessonquestion)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TestLessonQuestion.Find(testslessonquestion.Question_ID);
                    c.Question_Name = testslessonquestion.Question_Name;
                    c.IsSupper = testslessonquestion.IsSupper;
                    c.IsOK = testslessonquestion.IsOK;
                    c.Answer_ID = testslessonquestion.Answer_ID;
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
        public bool deleteTestLessonQuestion(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TestLessonQuestion.Find(id);
                    _db.Sys_TestLessonQuestion.Remove(result);
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
