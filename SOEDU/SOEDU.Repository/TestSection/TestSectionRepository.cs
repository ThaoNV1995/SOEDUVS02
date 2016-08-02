using SOEDU.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEDU.Repository.TestSection
{
    public class TestSectionRepository : ITestSectionRepository
    {
        /// <summary>
        /// Lấy ra tất cả các test phần học
        /// </summary>
        /// <returns>List danh sách phần học</returns>
        public List<Sys_TestSection> getAllTestSection()
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                List<Sys_TestSection> lst = new List<Sys_TestSection>();
                lst = _db.Sys_TestSection.ToList();
                return lst;
            }
        }
        /// <summary>
        /// Xem Chi tiết test phần học qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> section</returns>
        public Sys_TestSection viewDetail(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                return _db.Sys_TestSection.Find(id);
            }
        }
        /// <summary>
        /// Thêm test phần học
        /// </summary>
        /// <param name="testSection"></param>
        /// <returns></returns>
        public string addTestSection(Sys_TestSection testSection)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    _db.Sys_TestSection.Add(testSection);
                    _db.SaveChanges();
                    return testSection.TestSection_ID;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// Sửa test phần học
        /// </summary>
        /// <param name="testSection">phần học cần sửa</param>
        /// <returns></returns>
        public bool editTestSection(Sys_TestSection testSection)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var c = _db.Sys_TestSection.Find(testSection.Section_ID);
                    c.Test_Name = testSection.Test_Name;
                    c.IsSetTime = testSection.IsSetTime;
                    c.Section_ID = testSection.Section_ID;
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
        public bool deleteTestSection(string id)
        {
            using (SOEDUEntities _db = new SOEDUEntities())
            {
                try
                {
                    var result = _db.Sys_TestSection.Find(id);
                    _db.Sys_TestSection.Remove(result);
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
